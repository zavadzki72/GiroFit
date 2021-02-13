using Data.PostgreSQL.Context;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using Domain.Interfaces.Repositories.Base;
using Domain.Models.PostgreSql.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.PostgreSQL.Repositories.Base {

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntityWithoutDate, new() {

        protected readonly ApplicationDbContext DbContext;
        private readonly IMediatorHandler _bus;

        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(ApplicationDbContext db, IMediatorHandler bus) {
            DbContext = db;
            _bus = bus;

            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<List<TEntity>> GetAll() {

            try {
                return await DbSet.ToListAsync();
            } catch(Exception ex) {
                await _bus.RaiseEvent(new DomainNotification("SQL_ERROR", $"Um erro ocorreu durante a listagem de todas as entidades! ExMessage: {ex.Message}"));
            }

            return null;
        }

        public virtual async Task<TEntity> GetById(int id) {

            try {
                return await DbSet.FindAsync(id);
            } catch(Exception ex) {
                await _bus.RaiseEvent(new DomainNotification("SQL_ERROR", $"Um erro ocorreu durante a consulta de um dado por id! ExMessage: {ex.Message}"));
            }

            return null;

        }

        public async Task<TEntity> Insert(TEntity item) {

            try {
                DbSet.Add(item);
                await SaveChanges();
                return item;
            } catch(Exception ex) {
                await _bus.RaiseEvent(new DomainNotification("SQL_ERROR", $"Um erro ocorreu ao inserir a entidade! ExMessage: {ex.Message}"));
            }

            return null;
        }

        public async Task<TEntity> Update(TEntity item) {

            try {

                TEntity result = await GetById(item.Id);

                if(result == null)
                    return null;

                DbContext.Entry(result).State = EntityState.Detached;

                var entry = DbContext.Entry(item);
                if(entry.State == EntityState.Detached)
                    DbContext.Attach(item);

                DbContext.Entry(item).State = EntityState.Modified;
                await SaveChanges();

                return item;
            } catch(Exception ex) {
                await _bus.RaiseEvent(new DomainNotification("SQL_ERROR", $"Um erro ocorreu ao atualizar a entidade! ExMessage: {ex.Message}"));
            }

            return null;
        }

        public virtual async Task Delete(int id) {

            try {
                DbSet.Remove(new TEntity { Id = id });
                await SaveChanges();
            } catch(Exception ex) {
                await _bus.RaiseEvent(new DomainNotification("SQL_ERROR", $"Um erro ocorreu ao deletar a entidade! ExMessage: {ex.Message}"));
            }

        }

        public async Task<int> SaveChanges() {
            return await DbContext.SaveChangesAsync();
        }

        public void Dispose() {
            DbContext?.Dispose();
        }

    }
}
