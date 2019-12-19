using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using GameStorage.Domain;
using GameStorage.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStorageService.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class TeamController : Controller
    {
        private readonly RepositoryWrapper _repositoryWrapper;

        public TeamController(RepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        
        public IEnumerable<Team> Index()
        {
            //GetTeam the first ten teams depending on the rating
            var teams = _repositoryWrapper.TeamRepository.GetListQueryable
                .Include(t => t.Config)
                .ToList();
            return teams;
        }

        [HttpPost("create")]
        public IActionResult Register(Team team)
        {
            var teams = _repositoryWrapper
                .TeamRepository
                .FindByExpression(x => x.Name == team.Name || x.Code == team.Code).ToList();
            var cfg = team.Config;
            //check whether there are teams with the same names of same router configs
            if (teams.Count() != 0 ||
                _repositoryWrapper.ConfigRepository.IsIpAndPortUsed(cfg.RouterIpAddress, cfg.RouterPort))
                return Conflict();
            
            //unix requires special permission for port below 1024 and below
            if (team.Config.RouterPort < 1025) return BadRequest();

            //create new team
            var createdTeam = _repositoryWrapper.TeamRepository.CreateNew(team.Name, team.Config);
            _repositoryWrapper.UpdateDB();
            //redirect to the GET method
            return CreatedAtAction(nameof(GetTeam), new {teamName = createdTeam.Name },createdTeam);
        }

        [HttpGet("{teamName}")]
        public IActionResult GetTeam(string teamName)
        {
            var ob = _repositoryWrapper.TeamRepository.FindByName(teamName);
            if (ob == null) return NotFound();
            return Ok(ob);
        }
    }
}