using Domain.Models.PostgreSql.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class Train : BaseEntity {

        [Required()]
        [Column("name")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required()]
        [Column("cover_page")]
        public string CoverPage { get; set; }

        /* EF Relations */
        public virtual List<TrainModule> TrainModules { get; set; }

    }
}
