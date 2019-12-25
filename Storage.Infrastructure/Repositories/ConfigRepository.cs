using System.Linq;
using Storage.Domain.DTOs;
using Storage.Domain.Models;

namespace Storage.Infrastructure.Repositories
{
    public class ConfigRepository : BaseRepository<Config>
    {

        public ConfigRepository(DomainContext context) : base(context) { }
        
        //TO BE DELETED
        public Config CreateNew(string ip, int port, ConnectionType connectionType)
        {
            if (IsIpAndPortUsed(ip, port))
                return null;
            Config config = new Config
            {
                RouterIpAddress = ip, RouterPort = port, ConnectionType = connectionType
            };
            base.Add(config);
            return config;
        }

        public bool CheckObject(Config config)
        {
            if (IsIpAndPortUsed(config.RouterIpAddress, config.RouterPort)) return false;
            return true;
        }
        
        public bool CheckObject(ConfigDTO config)
        {
            if (IsIpAndPortUsed(config.RouterIpAddress, config.RouterPort)) return false;
            return true;
        }

        public Config Delete(Team team)
        {
            var config = GetList.FirstOrDefault(x => x.Team.Equals(team));
            if (config == null) return null;
            base.Delete(config);
            return config;
        }

        public bool IsIpAndPortUsed(string ip, int port)
        {
            var existingConfig = GetList.FirstOrDefault(x => string.Equals(x.RouterIpAddress, ip) 
                && x.RouterPort == port);
            return existingConfig != null;
        }
        
    }
}