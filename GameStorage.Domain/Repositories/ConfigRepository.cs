using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStorage.Domain
{
    public class ConfigRepository : IRepository<Config>
    {
        private IEnumerable<Config> _getList;

        IEnumerable<Config> IRepository<Config>.GetList => _getList;

        async Task IRepository<Config>.Add(Config item)
        {
            throw new System.NotImplementedException();
        }

        async Task IRepository<Config>.Delete(Config item)
        {
            throw new System.NotImplementedException();
        }

        async Task IRepository<Config>.Update(Config item)
        {
            throw new System.NotImplementedException();
        }

        Config IRepository<Config>.FindById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}