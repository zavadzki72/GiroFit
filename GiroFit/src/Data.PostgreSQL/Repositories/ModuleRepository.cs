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
    public class ModuleRepository : BaseRepository<Module>, IModuleRepository {
        public ModuleRepository(ApplicationDbContext db, IMediatorHandler bus) : base(db, bus) {
        }

        public async Task<List<Module>> GetModulesByUser(int userId) {

            return await DbSet
                .Where(x => x.IdUser == userId)
                .Include("TemplateModule")
                .ToListAsync();

        }
    }
}
