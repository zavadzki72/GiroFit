using Domain.Models.PostgreSql.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class Train : BaseEntityWithoutDate {

        [Required()]
        [Column("is_finished")]
        public bool IsFinished { get; set; }

        [Column("dta_finished")]
        public DateTime? DtaFinished { get; set; }

        [Required()]
        [Column("dta_creation")]
        public DateTime CreationDate { get; set; }

        [Required()]
        [Column("dta_updated")]
        public DateTime UpdateDate { get; set; }

        /* EF Relations */

        [ForeignKey("Module"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdModule { get; set; }

        public Module Module { get; set; }
        

        [ForeignKey("TemplateTrain"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTemplateTrain { get; set; }

        public TemplateTrain TemplateTrain { get; set; }


        public virtual List<Exercise> Exercises { get; set; }

    }
}
