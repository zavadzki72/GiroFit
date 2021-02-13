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
        private readonly IMediatorHandler _bus;

        public UserApplicationService(
            IMapper mapper,
            IUserRepository userRepository,
            IMediatorHandler bus
        ) {
            _mapper = mapper;
            _userRepository = userRepository;
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
    }
}
