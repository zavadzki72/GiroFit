using System;

namespace Domain.Interfaces.PostgreSql.Entity {

    public interface IBaseEntity {

        int Id { get; set; }
        DateTime CreationDate { get; set; }
        DateTime UpdateDate { get; set; }

    }
}
