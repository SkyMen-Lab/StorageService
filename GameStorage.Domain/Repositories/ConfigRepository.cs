using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStorage.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStorage.Domain.Repositories
{
    public class ConfigRepository : BaseRepository<Config>
    {

        public ConfigRepository(DomainContext context) : base(context) { }
        
        public Config CreateNew(string ip, int port, ConnectionType connectionType)
        {
            if (IsIpUsed(ip))
                return null;
            Config config = new Config
            {
                RouterIpAddress = ip, RouterPort = port, ConnectionType = connectionType
            };
            base.Add(config);
            return config;
        }

        public bool CheckAndUpdate(Config config)
        {
            if (IsIpUsed(config.RouterIpAddress)) return false;
            base.Update(config);
            return true;
        }

        public Config Delete(Team team)
        {
            var config = GetList.FirstOrDefault(x => x.Team.Equals(team));
            if (config == null) return null;
            base.Delete(config);
            return config;
        }

        public bool IsIpUsed(string ip)
        {
            var existingConfig = GetList.FirstOrDefault(x => string.Equals(x.RouterIpAddress, ip));
            return existingConfig != null;
        }
        
    }
}