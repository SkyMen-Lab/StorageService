using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStorage.Domain
{
    public class TeamGameSummaryRepository : IRepository<TeamGameSummary>
    {
        public IEnumerable<TeamGameSummary> GetList { get; }
        public async Task Add(TeamGameSummary item)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(TeamGameSummary item)
        {
            throw new System.NotImplementedException();
        }

        public async Task Update(TeamGameSummary item)
        {
            throw new System.NotImplementedException();
        }

        public TeamGameSummary FindById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}