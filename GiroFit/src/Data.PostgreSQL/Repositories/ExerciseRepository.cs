using Data.PostgreSQL.Context;
using Data.PostgreSQL.Repositories.Base;
using Domain.Core.Bus;
using Domain.Interfaces.PostgreSql.Repositories;
using Domain.Models.PostgreSql.Entities;

namespace Data.PostgreSQL.Repositories {
    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository {
        public ExerciseRepository(ApplicationDbContext db, IMediatorHandler bus) : base(db, bus) {
        }
    }
}
