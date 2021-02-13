using Domain.Models.PostgreSql.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class ExerciseType : BaseEntityWithoutDate {

        [Required()]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required()]
        [Column("url_video")]
        public string UrlVideo { get; set; }

        //Ef relations
        public virtual List<TemplateExercise> TemplateExercises { get; set; }
    }
}
