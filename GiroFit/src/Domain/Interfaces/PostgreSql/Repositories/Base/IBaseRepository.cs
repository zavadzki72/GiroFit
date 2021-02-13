using Domain.Models.PostgreSql.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Base {

    public interface IBaseRepository<TEntity> : IDisposable where TEntity : BaseEntity {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Insert(TEntity item);
        Task<TEntity> Update(TEntity item);
        Task Delete(int id);
    }

}
