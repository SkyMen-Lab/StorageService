using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStorage.Domain
{
    public interface IRepository<T> 
    {
        IEnumerable<T> GetList { get; }
        Task Add(T item);
        Task Delete(T item);
        Task Update(T item);
        T FindById(int id);
    }
}