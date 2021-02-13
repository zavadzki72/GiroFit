using ApplicationService.ViewModels.Request.User;
using ApplicationService.ViewModels.Response;
using AutoMapper;
using Domain.Models.PostgreSql.Entities;

namespace ApplicationService.AutoMapper {
    public class AutomapperConfig : Profile {

        public AutomapperConfig() {

            //User

            CreateMap<CreateUserViewModel, User>()
                .ConvertUsing(x => new User {
                    Email = x.Email,
                    Password = x.Password,
                    Name = x.Name,
                    Height = x.Height,
                    Weight = x.Weight,
                    Nickname = x.Nickname,
                    Sexo = x.Sexo,
                    Frequency = x.Frequency,
                    Level = x.Level,
                    Objective = x.Objective
                });

            CreateMap<User, UserResponseViewModel>()
                .ConvertUsing(x => new UserResponseViewModel { 
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.Name,
                    Height = x.Height,
                    Weight = x.Weight,
                    Nickname = x.Nickname,
                    Sexo = x.Sexo,
                    Frequency = x.Frequency,
                    Level = x.Level,
                    Objective = x.Objective,
                    FlgInativo = x.FlgInativo
                });

        }
        
    }
}
