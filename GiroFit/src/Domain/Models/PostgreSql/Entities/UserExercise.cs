using Domain.Models.PostgreSql.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class UserExercise : BaseEntity {

        [Required()]
        [Column("dta_start")]
        public DateTime DtaStart { get; set; }

        [Required()]
        [Column("dta_end")]
        public DateTime DtaEnd { get; set; }

        [Required()]
        [Column("watched")]
        public bool Watched { get; set; }

        /* EF Relations */
        [ForeignKey("Exercise"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdExercise { get; set; }

        public Exercise Exercise { get; set; }

        [ForeignKey("UserTrain"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUserTrain { get; set; }

        public UserTrain UserTrain { get; set; }

        [ForeignKey("User"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUser { get; set; }

        public User User { get; set; }

    }
}
