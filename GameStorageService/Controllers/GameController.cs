using System;
using System.Linq;
using GameStorage.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStorageService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly RepositoryWrapper _repositoryWrapper;

        public GameController(RepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        
        // GET
        public IActionResult Index()
        {
            var games = _repositoryWrapper.Game.GetListQueryable
                .Include(g => g.TeamGameSummaries)
                .Where(g => g.IsFinished == false).ToList();
            return Ok(games);
        }

        
        [Route("create")]
        public IActionResult Create()
        {
            var team1 = _repositoryWrapper.TeamRepository.FindById(1);
            var team2 = _repositoryWrapper.TeamRepository.FindById(2);
            //fake data
            //will be replaces with incoming POST-request from the "clint "
            var teamGameSummary1 = _repositoryWrapper.TeamGameSummaryRepository.CreateNew(team1, numberOfPlayers: 100);
            var teamGameSummary2 = _repositoryWrapper.TeamGameSummaryRepository.CreateNew(team2, numberOfPlayers: 100);
            var game = _repositoryWrapper.Game.CreateNew(DateTime.Today,
                teamGameSummary1, teamGameSummary2, 10);
            _repositoryWrapper.UpdateDB();
            return Ok(game);
        }
    }
}