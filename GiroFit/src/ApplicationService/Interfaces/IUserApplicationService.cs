using ApplicationService.ViewModels.Request.User;
using ApplicationService.ViewModels.Response;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces {

    public interface IUserApplicationService {

        Task<UserResponseViewModel> GetById(int id);

        Task<UserResponseViewModel> GetByIdWithModules(int id);

        Task<UserResponseViewModel> Create(CreateUserViewModel userViewModel);
    }
}
