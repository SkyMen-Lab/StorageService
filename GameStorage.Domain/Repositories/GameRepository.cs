using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStorage.Domain
{
    public class GameRepository : IRepository<Game>
    {
        public IEnumerable<Game> GetList { get; }
        public async Task Add(Game item)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(Game item)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(Game item)
        {
            throw new System.NotImplementedException();
        }

        public Game FindById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}