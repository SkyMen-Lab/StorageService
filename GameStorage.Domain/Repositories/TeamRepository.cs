using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStorage.Domain
{
    public class TeamRepository : IRepository<Team>
    {
        public IEnumerable<Team> GetList { get; }
        public async Task Add(Team item)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(Team item)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(Team item)
        {
            throw new System.NotImplementedException();
        }

        public Team FindById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}