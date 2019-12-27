using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storage.Domain.DTOs;
using Storage.Domain.Models;
using Storage.Infrastructure;

namespace StorageService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly RepositoryWrapper _repositoryWrapper;
        
        //TODO: finish the the game via POST request from the GameService

        public GameController(RepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        
        // GET the most recent game record
        public IActionResult Index()
        {
            var games = _repositoryWrapper.GameRepository.GetListQueryable
                .Include(g => g.TeamGameSummaries)
                .ThenInclude(t => t.Team)
                .OrderByDescending(g => g.Id)
                .FirstOrDefault(g => g.State == GameState.Created);
            return Ok(games);
        }
        
        
        [HttpGet("list/{page:int}")]
        public IActionResult GetPageList(int page = 1)
        {
            if (page < 1) return BadRequest();

            var list = _repositoryWrapper
                .GameRepository
                .GetListQueryable
                .Include(x => x.TeamGameSummaries)
                .Skip((page - 1) * 10)
                .Take(10);
            return Ok(list);
        }
        
        [HttpPost("create")]
        public IActionResult SetUp(SetUpGameDTO game)
        {
            var date = game.Date;
            TimeSpan timeFromNow = date - DateTime.Now;
            if (timeFromNow.TotalMinutes < 1) return BadRequest();

            Team firstTeam = _repositoryWrapper.TeamRepository.FindByCode(game.FirstTeamCode);
            if (firstTeam == null) return BadRequest();

            Team secondTeam = _repositoryWrapper.TeamRepository.FindByCode(game.SecondTeamCode);
            if (secondTeam == null) return BadRequest();

            TeamGameSummary firstTeamGameSummary = _repositoryWrapper.TeamGameSummaryRepository.CreateNew(firstTeam);
            TeamGameSummary secondTeamGameSummary = _repositoryWrapper.TeamGameSummaryRepository.CreateNew(secondTeam);

            var gameCreated = _repositoryWrapper.GameRepository.CreateNew(game.Date, firstTeamGameSummary,
                secondTeamGameSummary, game.DurationMinutes);
            
            _repositoryWrapper.UpdateDB();

            return CreatedAtAction(nameof(FindGame), new {code = gameCreated.Code}, gameCreated);
        }

        [HttpGet("start/{code}")]
        public IActionResult StartTheGame(string code)
        {
            var game = _repositoryWrapper.GameRepository.FindByCodeDetailed(code);
            if (game == null) return NotFound();
            game.State = GameState.Going;
            
            //TODO: send request to the GameService to start the game
            
            _repositoryWrapper.UpdateDB();

            return Ok();
        }

        [HttpGet("{code}")]
        public IActionResult FindGame(string code)
        {
            var game = _repositoryWrapper.GameRepository.FindByCodeDetailed(code);
            if (game == null) return NotFound();

            return Ok(game);
        }
    }
}