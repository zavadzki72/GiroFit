using Domain.Interfaces.Repositories.Base;
using Domain.Models.PostgreSql.Entities;

namespace Domain.Interfaces.PostgreSql.Repositories {
    public interface IModuleRepository : IBaseRepository<Module> {
    }
}
