using System;
using System.Collections.Generic;
using System.Linq;
using GameStorage.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStorage.Infrastructure.Repositories
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
                .Include(y => y.TeamGameSummaries)
                .FirstOrDefault(x => string.Equals(x.Code, code));
        }

        public Game CreateNew(DateTime date,
            TeamGameSummary teamGameSummary1, TeamGameSummary teamGameSummary2,
            int duration, string createdBy = "SkymanOne")
        {
            string code = Utils.GenerateRamdomCode(5);
            var game = new Game
            {
                Code = code,
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