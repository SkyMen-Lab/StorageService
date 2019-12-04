using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStorage.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStorage.Domain.Repositories
{
    public class TeamRepository : BaseRepository<Team>
    {
        private ConfigRepository _configRepository;

        public TeamRepository(DomainContext context, ConfigRepository configRepository) : base(context)
        {
            _configRepository = configRepository;
        }

        public Team Find(Func<Team, bool> expression)
        {
            return GetListQueryable.Include(t => t.Config).FirstOrDefault(expression);
        }

        public Team FindByName(string name)
        {
            return Find(x => string.Equals(x.Name, name));
        }

        public Team CreateNew(string name, string ip, int port, ConnectionType connectionType)
        {
            var existingTeam = FindByName(name);
            if (existingTeam != null)
                return null;

            var config = _configRepository.CreateNew(ip, port, connectionType);
            var team = new Team
            {
                Code = Utils.GenerateRamdomCode(5),
                Name = name,
                Config = config
            };
            
            base.Add(team);
            UpdateDatabase();
            return team;
        }

        public Team CreatNewWithConfig(string name, Config config)
        {
            var existingTeam = FindByName(name);
            if (existingTeam != null)
                return null;
            
            var team = new Team
            {
                Code = Utils.GenerateRamdomCode(5),
                Name = name,
                Config = config,
                WinningRate = 0
            };
            
            base.Add(team);
            UpdateDatabase();
            return team;
        }

        public void UpdateRecord(Team team)
        {
            base.Update(team);
            UpdateDatabase();
        }

        public Team DeleteRecord(Team team)
        {
            var teamConfig = team.Config;
            _configRepository.Delete(teamConfig);
            team.GamesWon = null;
            team.TeamGameSummaries = null;
            base.Delete(team);
            UpdateDatabase();
            return team;
        }

        public Team DeleteByName(string name)
        {
            var team = FindByName(name);
            return team == null ? null : DeleteRecord(team);
        }
        
    }
}