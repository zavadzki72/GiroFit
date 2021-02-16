using ApplicationService.Interfaces;
using ApplicationService.ViewModels.Request.User;
using ApplicationService.ViewModels.Response;
using AutoMapper;
using Domain.Core.Bus;
using Domain.Interfaces.PostgreSql.Repositories;
using Domain.Models.PostgreSql.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationService.Services {

    public class UserApplicationService : IUserApplicationService {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly ITemplateModuleRepository _templateModuleRepository;
        private readonly ITemplateTrainRepository _templateTrainRepository;
        private readonly ITemplateExerciseRepository _templateExerciseRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly ITrainRepository _trainRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IExerciseTypeRepository _exerciseTypeRepository;
        private readonly IMediatorHandler _bus;

        public UserApplicationService(
            IMapper mapper,
            IUserRepository userRepository,
            ITemplateModuleRepository templateModuleRepository,
            ITemplateTrainRepository templateTrainRepository,
            ITemplateExerciseRepository templateExerciseRepository,
            IModuleRepository moduleRepository,
            ITrainRepository trainRepository,
            IExerciseRepository exerciseRepository,
            IExerciseTypeRepository exerciseTypeRepository,
            IMediatorHandler bus
        ) {
            _mapper = mapper;
            _userRepository = userRepository;
            _templateModuleRepository = templateModuleRepository;
            _templateTrainRepository = templateTrainRepository;
            _templateExerciseRepository = templateExerciseRepository;
            _moduleRepository = moduleRepository;
            _trainRepository = trainRepository;
            _exerciseRepository = exerciseRepository;
            _exerciseTypeRepository = exerciseTypeRepository;
            _bus = bus;
        }

        public async Task<UserResponseViewModel> GetById(int id) {

            var result = await _userRepository.GetById(id);

            var resultMapped = _mapper.Map<UserResponseViewModel>(result);

            return resultMapped;
        }

        public async Task<UserResponseViewModel> GetByIdWithModules(int id) {

            var user = await _userRepository.GetById(id);
            
            var resultMapped = _mapper.Map<UserResponseViewModel>(user);

            var modules = await MapModules(user.Id);

            resultMapped.Modules = modules;

            return resultMapped;
        }

        private async Task<List<ModuleResponse>> MapModules(int userId) {

            List<ModuleResponse> resp = new List<ModuleResponse>();

            var modules = await _moduleRepository.GetModulesByUser(userId);

            foreach(var module in modules) {

                var trains = await MapTrain(module.Id);

                var moduleResp = new ModuleResponse {
                    Id = module.Id,
                    DtaCreated = module.CreationDate,
                    DtaUpdated = module.UpdateDate,
                    DtaStart = module.DtaStart,
                    DtaEnd = module.DtaEnd,
                    IsLocked = module.IsLocked,
                    Name = module.TemplateModule.Name,
                    Order = module.TemplateModule.Order,
                    Trains = trains
                };

                resp.Add(moduleResp);

            }

            return resp;
        }

        private async Task<List<TrainResponse>> MapTrain(int moduleId) {

            List<TrainResponse> response = new List<TrainResponse>();

            var trains = await _trainRepository.GetTrainsByModule(moduleId);

            foreach(var train in trains) {

                var exercises = await MapExercise(train.Id);

                var trainResp = new TrainResponse {
                    Id = train.Id,
                    Name = train.TemplateTrain.Name,
                    CoverPage = train.TemplateTrain.Cover_Page,
                    DtaEnd = train.DtaFinished,
                    DtaCreated = train.CreationDate,
                    DtaUpdated = train.UpdateDate,
                    Exercises = exercises
                };

                response.Add(trainResp);
            }

            return response;
        }

        private async Task<List<ExerciseResponse>> MapExercise(int trainId) {

            List<ExerciseResponse> response = new List<ExerciseResponse>();

            var exercises = await _exerciseRepository.GetExercisesByTrain(trainId);

            foreach(var exercise in exercises) {

                var exerciseType = await _exerciseTypeRepository.GetById(exercise.TemplateExercise.IdExerciseType);

                var exerciseResp = new ExerciseResponse {
                    Id = exercise.Id,
                    Name = exerciseType.Name,
                    UrlVideo = exerciseType.UrlVideo,
                    BreakTime = exercise.TemplateExercise.BreakTime,
                    Frequency = exercise.TemplateExercise.Frequency,
                    Sets = exercise.TemplateExercise.Sets,
                    Time = exercise.TemplateExercise.Time,
                    IsWatched = exercise.IsWatched,
                    DtaCreated = exercise.CreationDate,
                    DtaUpdated = exercise.UpdateDate
                };

                response.Add(exerciseResp);
            }

            return response;
        }

        public async Task<UserResponseViewModel> Create(CreateUserViewModel userViewModel) {

            var modelToInsert = _mapper.Map<User>(userViewModel);

            var result = await _userRepository.Insert(modelToInsert);

            var userModules = await ConfigureUser(result);

            var resultMapped = _mapper.Map<UserResponseViewModel>(result);

            resultMapped.Modules = userModules;

            return resultMapped;
        }

        private async Task<List<ModuleResponse>> ConfigureUser(User user) {
            var list = await SetModulesToUser(user);

            return list;
        }

        private async Task<List<ModuleResponse>> SetModulesToUser(User user) {

            List<ModuleResponse> response = new List<ModuleResponse>();

            var tempModules = await _templateModuleRepository.GetTemplateModuleByUser(user);

            foreach(var tempModule in tempModules) {

                ModuleResponse moduleResp;

                Module moduleToInsert = new Module {
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DtaEnd = null,
                    DtaStart = null,
                    IdTemplateModule = tempModule.Id,
                    IdUser = user.Id
                };

                var resultModuleInsert = await _moduleRepository.Insert(moduleToInsert);

                moduleResp = new ModuleResponse {
                    Id = resultModuleInsert.Id,
                    DtaCreated = resultModuleInsert.CreationDate,
                    DtaUpdated = resultModuleInsert.UpdateDate,
                    DtaEnd = resultModuleInsert.DtaEnd,
                    DtaStart = resultModuleInsert.DtaStart,
                    IsLocked = tempModule.IsLocked,
                    Name = tempModule.Name,
                    Order = tempModule.Order,
                    Trains = new List<TrainResponse>()
                };

                var trainsResponse = await SetTrainsToUser(tempModule, resultModuleInsert.Id);

                moduleResp.Trains = trainsResponse;

                response.Add(moduleResp);

            }

            return response;
        }

        private async Task<List<TrainResponse>> SetTrainsToUser(TemplateModule templateModule, int idModuleInserted) {

            List<TrainResponse> response = new List<TrainResponse>();

            var tempTrains = await _templateTrainRepository.GetTemplateTrainsByTemplateModule(templateModule);

            foreach(var tempTrain in tempTrains) {

                TrainResponse trainResp;

                Train trainToInsert = new Train {
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DtaFinished = null,
                    IdModule = idModuleInserted,
                    IdTemplateTrain = tempTrain.Id,
                    IsFinished = false
                };

                var resultTrainInsert = await _trainRepository.Insert(trainToInsert);

                trainResp = new TrainResponse {
                    Id = resultTrainInsert.Id,
                    DtaCreated = resultTrainInsert.CreationDate,
                    DtaUpdated = resultTrainInsert.UpdateDate,
                    DtaEnd = resultTrainInsert.DtaFinished,
                    CoverPage = tempTrain.Cover_Page,
                    Name = tempTrain.Name,
                    Exercises = new List<ExerciseResponse>()
                };

                var exercisesResponse = await SetExercisesToUser(tempTrain, resultTrainInsert.Id);

                trainResp.Exercises = exercisesResponse;

                response.Add(trainResp);
            }

            return response;
        }

        private async Task<List<ExerciseResponse>> SetExercisesToUser(TemplateTrain templateTrain, int idTrainInserted) {

            List<ExerciseResponse> retorno = new List<ExerciseResponse>();

            var tempExercises = await _templateExerciseRepository.GetTemplateExercisesByTemplateTrain(templateTrain);

            foreach(var tempEx in tempExercises) {

                ExerciseResponse exResp;

                Exercise exToInsert = new Exercise {
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    IsWatched = false,
                    IdTrain = idTrainInserted,
                    IdTemplateExercise = tempEx.Id
                };

                var resultExInsert = await _exerciseRepository.Insert(exToInsert);

                exResp = new ExerciseResponse {
                    Id = resultExInsert.Id,
                    Name = tempEx.ExerciseType.Name,
                    UrlVideo = tempEx.ExerciseType.UrlVideo,
                    DtaCreated = resultExInsert.CreationDate,
                    DtaUpdated = resultExInsert.UpdateDate,
                    IsWatched = resultExInsert.IsWatched,
                    BreakTime = tempEx.BreakTime,
                    Sets = tempEx.Sets,
                    Time = tempEx.Time,
                    Frequency = tempEx.Frequency
                };

                retorno.Add(exResp);
            }

            return retorno;
        }

    }
}
