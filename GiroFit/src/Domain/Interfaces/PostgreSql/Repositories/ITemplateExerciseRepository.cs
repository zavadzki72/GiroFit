using Domain.Interfaces.Repositories.Base;
using Domain.Models.PostgreSql.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.PostgreSql.Repositories {

    public interface ITemplateExerciseRepository : IBaseRepository<TemplateExercise>{

        Task<List<TemplateExercise>> GetTemplateExercisesByTemplateTrain(TemplateTrain templateTrain);

    }
}
