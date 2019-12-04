using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GameStorage.Domain.Models;

namespace GameStorage.Domain.Repositories
{
    public class GameRepository : BaseRepository<Game>
    {
        private TeamGameSummaryRepository _summaryRepository;

        public GameRepository(DomainContext context, TeamGameSummaryRepository teamGameSummaryRepository) :
            base(context)
        {
            _summaryRepository = teamGameSummaryRepository;
        }

        public Game FindByCode(string code)
        {
            return GetList.FirstOrDefault(x => string.Equals(x.Code, code));
        }

        public Game CreateNew(DateTime date, Team team1, Team team2, int numberOfPlayers1, int numberOfPlayers2,
            int duration, string createdBy = "SkymanOne", bool isStarted = false)
        {
            TeamGameSummary teamGameSummary1, teamGameSummary2;
            string code = Utils.GenerateRamdomCode(5);
            teamGameSummary1 = new TeamGameSummary
            {
                Team = team1,
                NumberOfPlayers = numberOfPlayers1
            };
            teamGameSummary2 = new TeamGameSummary
            {
                Team = team2,
                NumberOfPlayers = numberOfPlayers2
            };
            var game = new Game
            {
                Code = code,
                IsStarted = isStarted,
                IsFinished = false,
                TeamOneGameSummary = teamGameSummary1,
                TeamTwoGameSummary = teamGameSummary2,
                Date = date,
                DurationMinutes = duration,
                CreatedBy = createdBy
            };
            base.Add(game);
            UpdateDatabase();
            return game;
        }

        public void UpdateRecord(Game game)
        {
            base.Update(game);
            UpdateDatabase();
        }

        public Game DeleteRecord(Game game)
        {
            _summaryRepository.DeleteRecord(game.TeamOneGameSummary);
            _summaryRepository.DeleteRecord(game.TeamTwoGameSummary);
            Delete(game);
            UpdateDatabase();
            return game;
        }

        public Game DeleteRecordByCode(string code)
        {
            if (string.IsNullOrEmpty(code)) return null;
            var game = FindByCode(code);
            return DeleteRecord(game);
        }
        
    }
}