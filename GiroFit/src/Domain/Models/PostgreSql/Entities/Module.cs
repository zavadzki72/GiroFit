using Domain.Models.PostgreSql.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class Module : BaseEntityWithoutDate {

        [Column("dta_start")]
        public DateTime? DtaStart { get; set; }

        [Column("dta_end")]
        public DateTime? DtaEnd { get; set; }

        [Required()]
        [Column("dta_creation")]
        public DateTime CreationDate { get; set; }

        [Required()]
        [Column("dta_updated")]
        public DateTime UpdateDate { get; set; }

        /* EF Relations */

        [ForeignKey("User"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUser { get; set; }

        public User User { get; set; }

        [ForeignKey("TemplateModule"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTemplateModule { get; set; }

        public TemplateModule TemplateModule { get; set; }


        public virtual List<Train> Trains { get; set; }
    }
}
