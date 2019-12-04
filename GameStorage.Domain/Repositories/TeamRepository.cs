using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GameStorage.Domain.Repositories
{
    public class TeamRepository : BaseRepository<Team>
    {
        private ConfigRepository _configRepository;

        public TeamRepository(DomainContext context, ConfigRepository configRepository) : base(context)
        {
            _configRepository = configRepository;
        }
        
        //TODO: develop API and data validation

        public Team CreateNew(string name, string ip, int port, ConnectionType connectionType)
        {
            var existingTeam = GetList.FirstOrDefault(x => string.Equals(x.Name, name));
            if (existingTeam != null)
                return null;

            var config = _configRepository.CreateNew(ip, port, connectionType);
            var team = new Team
            {
                Code = Utils.GenerateRamdomCode(5),
                Name = name,
                Config = config
            };
            config.Team = team;
            UpdateDatabase();
            return team;
        }
    }
}