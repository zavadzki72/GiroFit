using Domain.Models.PostgreSql.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities {

    public class TrainModule : BaseEntity {

        [ForeignKey("Train"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTrain { get; set; }

        public Train Train { get; set; }

        [ForeignKey("Module"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdModule { get; set; }

        public Module Module { get; set; }

    }
}
