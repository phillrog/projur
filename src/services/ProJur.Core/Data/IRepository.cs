using ProJur.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProJur.Core.Data
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
	{
		IUnitOfWork UnitOfWork { get; }
		Task AdicionarAsync(TEntity entity);
		Task<TEntity> ObterPorIdAsync(Guid id);
		Task<List<TEntity>> ObterTodosAsync();
		Task AtualizarAsync(TEntity entity);
		Task RemoverAsync(Guid id);
		Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);
	}
}
