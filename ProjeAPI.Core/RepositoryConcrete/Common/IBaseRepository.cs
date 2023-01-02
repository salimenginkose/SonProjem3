using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjeAPI.Core.RepositoryConcrete.Common
{
    public interface IBaseRepository<T> where T : class
    {
        //Ekleme
        public Task Add(T entity);
        public Task AddRange(IEnumerable<T> entities);

        //Güncelleme
        public Task Update(T entity);
        public Task UpdateRange(IEnumerable<T> entities);

        //Silme
        public Task Delete(T entity);
        public Task DeleteRange(IEnumerable<T> entities);

        //Tekli yada Değerlere Uyan Verileri Listeleme
        public Task<T> FindOneAsync(Expression<Func<T, bool>> predicate, params string[] includes);
        public Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, params string[] includes);
        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, params string[] includes);
    }
}
