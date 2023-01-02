using Microsoft.EntityFrameworkCore;
using ProjeAPI.Core.RepositoryConcrete.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Repository
{
    public class EFBaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public EFBaseRepository(ProjeDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            var iq = _dbSet.AsQueryable().AsNoTracking();
            foreach (var item in includes)
                iq = iq.Include(item);

            iq = iq.Where(predicate);

            return iq;
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            var iq = _dbSet.AsQueryable();

            foreach (var item in includes)
                iq = iq.Include(item);

            return await iq.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            var iq = _dbSet.AsQueryable().AsNoTracking();

            foreach (var item in includes)
                iq = iq.Include(item);

            iq = iq.Where(predicate);

            var res = await iq.ToListAsync();
            return res.Count > 0 ? res.FirstOrDefault() : null;
        }

    }
}
