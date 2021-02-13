using Domain.Enumerators;
using Domain.Models.PostgreSql.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class TemplateModule : BaseEntityWithoutDate {

        [Required()]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required()]
        [Column("order")]
        public int Order { get; set; }

        [Required()]
        [Column("type")]
        public ModuleType Type { get; set; }

        [Required()]
        [Column("is_locked")]
        public bool IsLocked { get; set; }

        [Required()]
        [Column("user_sexo")]
        public UserSexo UserSexo { get; set; }

        [Required()]
        [Column("user_level")]
        public UserLevel UserLevel { get; set; }

        [Required()]
        [Column("user_objective")]
        public UserObjective UserObjective { get; set; }

        [Required()]
        [Column("user_frenquency")]
        public UserFrenquency UserFrenquency { get; set; }

        /* EF Relations */
        public virtual List<TemplateTrain> TemplateTrains { get; set; }
        public virtual List<Module> Modules { get; set; }
    }

}
