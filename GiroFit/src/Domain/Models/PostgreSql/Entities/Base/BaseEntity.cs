using Domain.Interfaces.PostgreSql.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities.Base {

    public abstract class BaseEntityWithoutDate : IBaseEntityWihoutDate {

        public BaseEntityWithoutDate() {
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

    }
}
