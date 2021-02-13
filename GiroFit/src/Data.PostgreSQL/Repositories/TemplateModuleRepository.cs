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

    public class TemplateModuleRepository : BaseRepository<TemplateModule>, ITemplateModuleRepository {

        public TemplateModuleRepository(ApplicationDbContext db, IMediatorHandler bus) : base(db, bus) {
        }

        public async Task<List<TemplateModule>> GetTemplateModuleByUser(User user) {

            return await DbSet
                .Where(x => x.UserSexo == user.Sexo && x.UserLevel == user.Level && x.UserObjective == user.Objective && x.UserFrenquency == user.Frequency)
                //.Include("TemplateTrain")
                //.Include("Module")
                .ToListAsync();

        }
    }

}
