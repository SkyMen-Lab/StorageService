using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStorage.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStorage.Domain.Repositories
{
    public class GameRepository : BaseRepository<Game>
    {

        public GameRepository(DomainContext context) :
            base(context)
        {
        }

        public Game FindByCodeDetailed(string code)
        {
            return GetListQueryable
                .Include(x => x.Winner)
                .ThenInclude(y => y.TeamGameSummaries)
                .FirstOrDefault(x => string.Equals(x.Code, code));
        }

        public Game CreateNew(DateTime date, Team team1, Team team2, int numberOfPlayers1, int numberOfPlayers2,
            int duration, string createdBy = "SkymanOne", bool isStarted = false)
        {
            string code = Utils.GenerateRamdomCode(5);
            var teamGameSummary1 = new TeamGameSummary
            {
                Team = team1,
                NumberOfPlayers = numberOfPlayers1
            };
            var teamGameSummary2 = new TeamGameSummary
            {
                Team = team2,
                NumberOfPlayers = numberOfPlayers2
            };
            var game = new Game
            {
                Code = code,
                IsStarted = isStarted,
                IsFinished = false,
                TeamGameSummaries = new List<TeamGameSummary>{teamGameSummary1, teamGameSummary2},
                Date = date,
                DurationMinutes = duration,
                CreatedBy = createdBy
            };
            base.Add(game);
            return game;
        }
        

        public Game DeleteRecord(Game game)
        {
            game.TeamGameSummaries = null;
            game.Winner = null;
            Delete(game);
            return game;
        }

        public Game DeleteRecordByCode(string code)
        {
            if (string.IsNullOrEmpty(code)) return null;
            var game = FindByCodeDetailed(code);
            return DeleteRecord(game);
        }
        
    }
}