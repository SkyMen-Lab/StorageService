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

        public TeamRepository(DomainContext context) : base(context)
        { }

        public Team Find(Func<Team, bool> expression)
        {
            return GetListQueryable.Include(t => t.Config).FirstOrDefault(expression);
        }

        public Team FindByName(string name)
        {
            return Find(x => string.Equals(x.Name, name));
        }

        public Team CreateNew(string name, Config config)
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
            return team;
        }

        public Team DeleteRecord(Team team)
        {
            team.Config = null;
            team.GamesWon = null;
            team.TeamGameSummaries = null;
            base.Delete(team);
            return team;
        }

        public Team DeleteByName(string name)
        {
            var team = FindByName(name);
            return team == null ? null : DeleteRecord(team);
        }
        
    }
}