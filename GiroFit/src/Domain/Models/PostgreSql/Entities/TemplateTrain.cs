using Domain.Models.PostgreSql.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class TemplateTrain : BaseEntityWithoutDate {

        [Required()]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required()]
        [Column("cover_page")]
        public string Cover_Page { get; set; }

        //EF Relations

        [ForeignKey("TemplateModule"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTemplateModule { get; set; }

        public TemplateModule TemplateModule { get; set; }


        public virtual List<TemplateExercise> TemplateExercises { get; set; }
        public virtual List<Train> Trains { get; set; }

    }
}
