using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GameStorage.Domain.Repositories
{
    public class ConfigRepository : BaseRepository<Config>
    {

        public ConfigRepository(DomainContext context) : base(context) { }
        
        //TODO: develop API and data validation

        public Config CreateNew(string ip, int port, ConnectionType connectionType)
        {
            if (IsIpUsed(ip))
                return null;
            Config config = new Config
            {
                RouterIpAdress = ip, RouterPort = port, ConnectionType = connectionType
            };
            base.Add(config);
            return config;
        }

        public bool IsIpUsed(string ip)
        {
            var existingConfig = GetList.FirstOrDefault(x => string.Equals(x.RouterIpAdress, ip));
            return existingConfig != null;
        }
        
    }
}