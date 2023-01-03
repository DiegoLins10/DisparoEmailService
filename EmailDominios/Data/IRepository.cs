using EmailDominios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmailDominios.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);

        Task<TEntity> ObterPorId(int id);

        Task<List<TEntity>> ObterTodos();

        Task<List<TEntity>> ObterTodos(int pageCount, int pageSize);

        Task Atualizar(TEntity entity);

        Task Remover(TEntity entity);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}
