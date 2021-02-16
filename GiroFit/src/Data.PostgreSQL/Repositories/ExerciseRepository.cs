using Data.PostgreSQL.Context;
using Data.PostgreSQL.Repositories.Base;
using Domain.Core.Bus;
using Domain.Interfaces.PostgreSql.Repositories;
using Domain.Models.PostgreSql.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.PostgreSQL.Repositories {

    public class ExerciseRepository : BaseRepository<Exercise>, IExerciseRepository {

        private readonly ApplicationDbContext _dbContext;

        public ExerciseRepository(ApplicationDbContext db, IMediatorHandler bus) : base(db, bus) {
            _dbContext = db;
        }

        public async Task<List<Exercise>> GetExercisesByTrain(int trainId) {

            return await DbSet
                .Where(x => x.IdTrain == trainId)
                .Include("TemplateExercise")
                .ToListAsync();

        }
    }
}
