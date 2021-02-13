using Domain.Interfaces.PostgreSql.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.PostgreSql.Entities.Base {

    public abstract class BaseEntity : IBaseEntity {

        public BaseEntity() {
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required()]
        [Column("dta_creation")]
        public DateTime CreationDate { get; set; }

        [Required()]
        [Column("dta_updated")]
        public DateTime UpdateDate { get; set; }

    }
}
