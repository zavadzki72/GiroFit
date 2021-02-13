using Domain.Models.PostgreSql.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class ExerciseTrain : BaseEntity {

        [ForeignKey("Exercise"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdExercise { get; set; }

        public Exercise Exercise { get; set; }

        [ForeignKey("Train"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTrain { get; set; }

        public Train Train { get; set; }

    }
}
