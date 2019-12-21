using System;
using System.Collections.Generic;
using System.Linq;
using GameStorage.Domain;
using GameStorage.Domain.DTOs;
using GameStorage.Domain.Models;
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
        
        // GET the most recent game record
        public IActionResult Index()
        {
            var games = _repositoryWrapper.GameRepository.GetListQueryable
                .Include(g => g.TeamGameSummaries)
                .ThenInclude(t => t.Team)
                .FirstOrDefault(g => g.State == GameState.Created);
            return Ok(games);
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