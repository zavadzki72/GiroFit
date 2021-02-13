using Domain.Interfaces.Repositories.Base;
using Domain.Models.PostgreSql.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.PostgreSql.Repositories {
    public interface ITemplateTrainRepository : IBaseRepository<TemplateTrain> {

        Task<List<TemplateTrain>> GetTemplateTrainsByTemplateModule(TemplateModule templateModule);

    }
}
