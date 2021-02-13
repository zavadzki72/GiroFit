using Domain.Models.PostgreSql.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class UserModule : BaseEntity {

        [Required()]
        [Column("dta_start")]
        public DateTime DtaStart { get; set; }

        [Required()]
        [Column("dta_end")]
        public DateTime DtaEnd { get; set; }

        [Required()]
        [Column("is_locked")]
        public bool IsLocked { get; set; }

        /* EF Relations */
        [ForeignKey("Module"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdModule { get; set; }

        public Module Module { get; set; }

        [ForeignKey("User"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUser { get; set; }

        public User User { get; set; }

        public virtual List<UserTrain> UserTrains { get; set; }

    }
}
