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
    public class TrainRepository : BaseRepository<Train>, ITrainRepository {
        public TrainRepository(ApplicationDbContext db, IMediatorHandler bus) : base(db, bus) {
        }

        public async Task<List<Train>> GetTrainsByModule(int moduleId) {

            return await DbSet
                .Where(x => x.IdModule == moduleId)
                .Include("TemplateTrain")
                .ToListAsync();

        }

    }
}
