using Domain.Models.PostgreSql.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class Exercise : BaseEntity {

        [Required()]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required()]
        [Column("time")]
        public string Time { get; set; }

        [Required()]
        [Column("break_time")]
        public string BreakTime { get; set; }

        [Required()]
        [Column("sets")]
        public int Sets { get; set; }

        [Required()]
        [Column("frequecy")]
        public int Frequecy { get; set; }

        /* EF Relations */
        public virtual List<ExerciseTrain> ExerciseTrains { get; set; }

    }
}
