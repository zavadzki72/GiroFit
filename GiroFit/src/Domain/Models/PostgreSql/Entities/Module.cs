using Domain.Enumerators;
using Domain.Models.PostgreSql.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class Module : BaseEntity {

        [Required()]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required()]
        [Column("type")]
        public ModuleType Type { get; set; }

        /* EF Relations */
        public virtual List<UserModule> UserModules { get; set; }

    }
}
