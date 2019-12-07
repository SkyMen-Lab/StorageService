using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStorage.Domain.Models;

namespace GameStorage.Domain.Repositories
{
    public class TeamGameSummaryRepository : BaseRepository<TeamGameSummary>
    {
        public TeamGameSummaryRepository(DomainContext context) : base(context) { }

        public IEnumerable<TeamGameSummary> FindSummaries(Team team)
        {
            return GetList.Where(x => x.Team.Equals(team)).AsEnumerable();
        }

        public TeamGameSummary CreateNew(Team team, bool isWinner = false, int score = 0, int numberOfPlayers = 1)
        {
            if (score < 0 || numberOfPlayers < 1 || team == null) return null;
            var summary = new TeamGameSummary
            {
                Team = team,
                IsWinner = isWinner,
                Score = score,
                NumberOfPlayers = numberOfPlayers
            };
            base.Add(summary);
            return summary;
        }
    }
}