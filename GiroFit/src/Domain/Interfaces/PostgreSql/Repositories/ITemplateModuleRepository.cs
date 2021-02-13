using Domain.Interfaces.Repositories.Base;
using Domain.Models.PostgreSql.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.PostgreSql.Repositories {

    public interface ITemplateModuleRepository : IBaseRepository<TemplateModule> {

        Task<List<TemplateModule>> GetTemplateModuleByUser(User user);

    }

}
