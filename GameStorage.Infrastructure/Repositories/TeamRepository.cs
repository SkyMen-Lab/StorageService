using System;
using System.Collections.Generic;
using System.Linq;
using GameStorage.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStorage.Infrastructure.Repositories
{
    public class TeamRepository : BaseRepository<Team>
    {

        public TeamRepository(DomainContext context) : base(context)
        { }

        public Team FindOneByExpression(Func<Team, bool> expression)
        {
            return GetListQueryable
                .Include(t => t.Config)
                .Include(t => t.GamesWon)
                .Include(t => t.TeamGameSummaries)
                .FirstOrDefault(expression);
        }

        public IEnumerable<Team> FindByExpression(Func<Team, bool> expression)
        {
            return GetListQueryable.Include(t => t.Config).Where(expression);
        }

        public Team FindByName(string name)
        {
            return FindOneByExpression(x => string.Equals(x.Name, name));
        }

        public Team FindByCode(string code)
        {
            return FindOneByExpression(x => string.Equals(x.Code, code));
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
                WinningRate = 0,
                Rank = GetList.Count() + 1
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