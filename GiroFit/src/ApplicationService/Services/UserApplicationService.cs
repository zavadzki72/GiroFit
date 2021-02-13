using ApplicationService.Interfaces;
using ApplicationService.ViewModels.Request.User;
using ApplicationService.ViewModels.Response;
using AutoMapper;
using Domain.Core.Bus;
using Domain.Interfaces.PostgreSql.Repositories;
using Domain.Models.PostgreSql.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            _bus = bus;
        }

        public async Task<UserResponseViewModel> GetById(int id) {

            var result = await _userRepository.GetById(id);

            var resultMapped = _mapper.Map<UserResponseViewModel>(result);

            return resultMapped;
        }

        public async Task<UserResponseViewModel> Create(CreateUserViewModel userViewModel) {

            var modelToInsert = _mapper.Map<User>(userViewModel);

            var result = await _userRepository.Insert(modelToInsert);

            var resultMapped = _mapper.Map<UserResponseViewModel>(result);

            return resultMapped;
        }

        private async Task<List<ModuleResponse>> ConfigureUser(User user) {

            List<ModuleResponse> listaRet = new List<ModuleResponse>();

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

                var tempTrains = await _templateTrainRepository.GetTemplateTrainsByTemplateModule(tempModule);

                foreach(var tempTrain in tempTrains) {

                    TrainResponse trainResp;

                    Train trainToInsert = new Train {
                        CreationDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        DtaFinished = null,
                        IdModule = resultModuleInsert.Id,
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

                    var tempExercises = await _templateExerciseRepository.GetTemplateExercisesByTemplateTrain(tempTrain);

                    foreach(var tempEx in tempExercises) {

                        ExerciseResponse exResp;

                        Exercise exToInsert = new Exercise {
                            CreationDate = DateTime.Now,
                            UpdateDate = DateTime.Now,
                            IsWatched = false,
                            IdTrain = resultTrainInsert.Id,
                            IdTemplateExercise = tempEx.Id
                        };

                        var resultExInsert = await _exerciseRepository.Insert(exToInsert);

                        exResp = new ExerciseResponse {
                            Id = resultExInsert.Id,
                            DtaCreated = resultExInsert.CreationDate,
                            DtaUpdated = resultExInsert.UpdateDate,
                            IsWatched = resultExInsert.IsWatched,
                            BreakTime = tempEx.BreakTime,
                            Sets = tempEx.Sets,
                            Time = tempEx.Time,
                            Frequency = tempEx.Frequency
                        };

                        trainResp.Exercises.Add(exResp);
                        moduleResp.Trains.Add(trainResp);
                    }

                }

                listaRet.Add(moduleResp);
            }

            return listaRet;

        }

        private async Task<List<TemplateTrain>> GetTemplateTrainsByTemplateModules(List<TemplateModule> templateModules) {

            var result = await _templateTrainRepository.GetTemplateTrainsByTemplateModule(templateModules[0]);

            return result;

        }

        private async Task<List<TemplateExercise>> GetTemplateExercisesByTemplateTrain(List<TemplateTrain> templatesTrains) {

            var result = await _templateExerciseRepository.GetTemplateExercisesByTemplateTrain(templatesTrains[0]);

            return result;

        }

    }
}
