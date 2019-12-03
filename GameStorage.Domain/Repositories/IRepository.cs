using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStorage.Domain
{
    public interface IRepository<T> 
    {
        IEnumerable<T> GetList { get; }
        IEnumerable<T> GetFromQuery(Expression<Func<T, bool>> expression);
        Task Add(T item);
        Task Delete(T item);
        Task Update(T item);
        T FindById(int id);
    }
}