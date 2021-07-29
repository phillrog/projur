using Microsoft.EntityFrameworkCore;
using ProJur.Core.Data;
using ProJur.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProJur.Cadastros.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly UsuarioContext _context;
        protected readonly DbSet<TEntity> _dbSet;


        protected Repository(UsuarioContext db)
        {
            _context = db;
            _dbSet = _context.Set<TEntity>();
        }
        public IUnitOfWork UnitOfWork => _context;

        public virtual async Task AdicionarAsync(TEntity entity)
        {
            await Task.Run(() => _dbSet.Add(entity));
        }

        public virtual async Task AtualizarAsync(TEntity entity)
        {
            await Task.Run(() =>
            {
                _context.Entry<TEntity>(entity).State = EntityState.Modified;
                _context.Attach<TEntity>(entity);
                _dbSet.Update(entity);
            });
        }

        public virtual async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public virtual async Task<List<TEntity>> ObterTodosAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task RemoverAsync(Guid id)
        {
            await Task.Run(() => _dbSet.Remove(new TEntity { Id = id }));
        }

        public virtual void Dispose()
        {
            _context?.Dispose();
        }
    }
}
