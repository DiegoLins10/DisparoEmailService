using EmailDominios.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmailDominios.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly EmailContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(EmailContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<List<TEntity>> ObterTodos(int pageCount, int pageSize)
        {
            return await DbSet.Skip(pageCount).Take(pageSize).ToListAsync();
        }

        public async Task Adicionar(TEntity entity)
        {
            try
            {
                DbSet.Add(entity);
                await SaveChanges();
                Db.Entry(entity).State = EntityState.Detached;
            }
            catch (Exception ex)
            {
                Db.RemoveRange(entity);
                throw ex;
            }
        }

        public async Task Atualizar(TEntity entity)
        {
            try
            {
                DbSet.Update(entity);
                await SaveChanges();
                Db.Entry(entity).State = EntityState.Detached;
            }
            catch (Exception ex)
            {
                Db.RemoveRange(entity);
                throw ex;
            }
        }

        public async Task Remover(TEntity entity)
        {
            try
            {
                DbSet.Remove(entity);
                await SaveChanges();
                Db.Entry(entity).State = EntityState.Detached;
            }
            catch (Exception ex)
            {
                //Db.RemoveRange(entity);
                throw ex;
            }
        }

        public async Task<int> SaveChanges()
        {
            try
            {
                return await Db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                //Db.RemoveRange(entity);
                throw ex;
            }
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }

}
