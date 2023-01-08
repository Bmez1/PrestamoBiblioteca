using Microsoft.EntityFrameworkCore;
using PruebaIngresoBibliotecario.Infraestructura.Context;
using PruebaIngresoblibliotecario.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIngresoBibliotecario.Infraestructura.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly PersistenceContext _context;
        private readonly DbSet<TEntity> _db;

        public BaseRepository(PersistenceContext context)
        {
            _context = context;
            _db = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _db.ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(Guid id) => await _db.FindAsync(id);
    }
}
