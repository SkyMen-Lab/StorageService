using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameStorage.Domain.Repositories
{
    public class TeamRepository : BaseRepository<Team>
    {
        private ConfigRepository _configRepository;

        public TeamRepository(DomainContext context, ConfigRepository configRepository) : base(context)
        {
            _configRepository = configRepository;
        }

        public Team? Find(Func<Team, bool> expression)
        {
            return GetList.FirstOrDefault(expression);
        }

        public Team? FindByName(string name)
        {
            return Find(x => string.Equals(x.Name, name));
        }

        public Team CreateNew(string name, string ip, int port, ConnectionType connectionType)
        {
            var existingTeam = Find(x => string.Equals(x.Name, name));
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

        public void Update(Team team)
        {
            base.Update(team);
            UpdateDatabase();
        }

        public new Team Delete(Team team)
        {
            var teamConfig = team.Config;
            _configRepository.Delete(teamConfig);
            base.Delete(team);
            UpdateDatabase();
            return team;
        }

        public Team? Delete(string name)
        {
            var team = FindByName(name);
            return team == null ? null : Delete(team);
        }
        
    }
}