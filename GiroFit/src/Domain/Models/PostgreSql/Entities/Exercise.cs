using Domain.Models.PostgreSql.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class Exercise : BaseEntityWithoutDate {

        [Required()]
        [Column("is_watched")]
        public bool IsWatched { get; set; }

        [Required()]
        [Column("dta_creation")]
        public DateTime CreationDate { get; set; }

        [Required()]
        [Column("dta_updated")]
        public DateTime UpdateDate { get; set; }

        /* EF Relations */

        [ForeignKey("Train"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTrain { get; set; }

        public Train Train { get; set; }

        [ForeignKey("TemplateExercise"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTemplateExercise { get; set; }

        public TemplateExercise TemplateExercise { get; set; }
    }
}
