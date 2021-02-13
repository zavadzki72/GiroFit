using Domain.Enumerators;
using Domain.Models.PostgreSql.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class User : BaseEntity {

        [Required()]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required()]
        [Column("email")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required()]
        [Column("password")]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required()]
        [Column("height")]
        public decimal Height { get; set; }

        [Required()]
        [Column("weight")]
        public decimal Weight { get; set; }

        [Required()]
        [Column("objective")]
        public UserObjective Objective { get; set; }

        [Required()]
        [Column("nickname")]
        public string Nickname { get; set; }

        [Required()]
        [Column("sexo")]
        public UserSexo Sexo { get; set; }

        [Required()]
        [Column("frequency")]
        public UserFrenquency Frequency { get; set; }

        [Required()]
        [Column("level")]
        public UserLevel Level { get; set; }

        [Column("flg_inativo")]
        public bool FlgInativo { get; set; }

        /* EF Relations */
        public virtual List<UserModule> UserModules { get; set; }

        public virtual List<UserTrain> UserTrains { get; set; }

        public virtual List<UserExercise> UserExercises { get; set; }
    }
}
