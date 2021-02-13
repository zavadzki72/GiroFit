using Data.PostgreSQL.Context;
using Data.PostgreSQL.Repositories.Base;
using Domain.Core.Bus;
using Domain.Interfaces.PostgreSql.Repositories;
using Domain.Models.PostgreSql.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.PostgreSQL.Repositories {

    public class TemplateExerciseRepository : BaseRepository<TemplateExercise>, ITemplateExerciseRepository {

        public TemplateExerciseRepository(ApplicationDbContext db, IMediatorHandler bus) : base(db, bus) {
        }

        public async Task<List<TemplateExercise>> GetTemplateExercisesByTemplateTrain(TemplateTrain templateTrain) {

            return await DbSet
                .Where(x => x.IdTemplateTrain == templateTrain.Id)
                .Include("ExerciseType")
                //.Include("Module")
                .ToListAsync();

        }

    }
}
