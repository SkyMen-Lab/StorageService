using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GameStorage.Domain.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DomainContext _domainContext;

        public IEnumerable<T> GetList => _domainContext.Set<T>();
        public BaseRepository(DomainContext context)
        {
            _domainContext = context;
        }

        public IEnumerable<T> GetFromQuery(Expression<Func<T, bool>> expression)
        {
            return _domainContext.Set<T>().Where(expression).AsEnumerable();
        }

        public void Add(T item)
        {
            _domainContext.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _domainContext.Set<T>().Remove(item);
        }

        public void Update(T item)
        {
            _domainContext.Entry(item).State = EntityState.Modified;
        }

        public T FindById(int id)
        {
            return _domainContext.Set<T>().Find(id);
        }
        
        public async Task UpdateDatabaseAsync()
        {
            await _domainContext.SaveChangesAsync();
        }

        public void UpdateDatabase()
        {
            _domainContext.SaveChanges();
        }
    }
}