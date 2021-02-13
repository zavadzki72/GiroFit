using Domain.Models.PostgreSql.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class UserTrain : BaseEntity {

        [Required()]
        [Column("last_acess")]
        public DateTime LastAcess { get; set; }

        [Required()]
        [Column("is_finished")]
        public bool IsFinished { get; set; }

        /* EF Relations */
        [ForeignKey("Train"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTrain { get; set; }

        public Train Train { get; set; }

        [ForeignKey("UserModule"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUserModule { get; set; }

        public UserModule UserModule { get; set; }

        [ForeignKey("User"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUser { get; set; }

        public User User { get; set; }

        public virtual List<UserExercise> UserExercises { get; set; }

    }
}
