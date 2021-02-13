using Domain.Models.PostgreSql.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class TemplateExercise : BaseEntityWithoutDate {

        [Required()]
        [Column("frequency")]
        public int Frequency { get; set; }

        [Required()]
        [Column("sets")]
        public int Sets { get; set; }

        [Required()]
        [Column("time")]
        public int Time { get; set; }

        [Required()]
        [Column("break_time")]
        public int BreakTime { get; set; }

        //EF Relations

        [ForeignKey("TemplateTrain"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTemplateTrain { get; set; }

        public TemplateTrain TemplateTrain { get; set; }


        [ForeignKey("ExerciseType"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdExerciseType { get; set; }

        public ExerciseType ExerciseType { get; set; }


        public virtual List<Exercise> Modules { get; set; }

    }

}
