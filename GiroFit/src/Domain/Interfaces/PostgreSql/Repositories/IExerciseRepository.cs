using Domain.Interfaces.Repositories.Base;
using Domain.Models.PostgreSql.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.PostgreSql.Repositories {
    public interface IExerciseRepository : IBaseRepository<Exercise> {

        Task<List<Exercise>> GetExercisesByTrain(int trainId);

    }
}
