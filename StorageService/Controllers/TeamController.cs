using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Storage.Domain.DTOs;
using Storage.Infrastructure.Repositories;
using Storage.Domain.Models;
using Storage.Infrastructure;
using Serilog;

namespace StorageService.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class TeamController : Controller
    {
        private readonly RepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public TeamController(RepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public IEnumerable<Team> Index()
        {
            //GetTeam the first ten teams depending on the rating
            var teams = _repositoryWrapper.TeamRepository.GetListQueryable
                .Include(t => t.Config)
                .Include(t => t.GamesWon)
                .Take(10)
                .ToList();
            Log.Information("Team index requested. Returned {0} teams", teams.Count);
            return teams;
        }


        [HttpGet("list/{page:int}")]
        public IActionResult GetPageList(int page = 1)
        {
            if (page < 1)
            {
                Log.Error("Bad request on GetPageList. Requested page <1.");
                return BadRequest();
            }


            var list = _repositoryWrapper
                .TeamRepository
                .GetListQueryable
                .Include(t => t.Config)
                .Include(t => t.GamesWon)
                .Skip((page - 1) * 10)
                .Take(10);
            Log.Information("Returned team page {0}.", page);
            return Ok(list);
        }

        [HttpPost("create")]
        public IActionResult Register(Team team)
        {
            Log.Information("Team creation request started. Team name = {0}, RouterIpAddress = {1}, Port = {2}, ConnectionType = {3}.", team.Name, team.Config.RouterIpAddress, team.Config.RouterPort, team.Config.ConnectionType);

            var teams = _repositoryWrapper
                .TeamRepository
                .FindByExpression(x => x.Name == team.Name || x.Code == team.Code).ToList();
            var cfg = team.Config;
            //check whether there are teams with the same names of same router configs
            if (teams.Count() != 0 ||
                _repositoryWrapper.ConfigRepository.IsIpAndPortUsed(cfg.RouterIpAddress, cfg.RouterPort))
            {
                Log.Error("Team creation request failure: Conflict request.");
                return Conflict();
            }


            //unix requires special permission for port below 1024 and below
            if (team.Config.RouterPort < 1025)
            {
                Log.Error("Team creation request failure: RouterPort < 1025");
                return BadRequest();
            }

            //create new team
            var createdTeam = _repositoryWrapper.TeamRepository.CreateNew(team.Name, team.Config);
            _repositoryWrapper.UpdateDB();
            Log.Information("Team creation request finished.");
            //redirect to the GET method
            return CreatedAtAction(nameof(GetByName), new { teamName = createdTeam.Name }, createdTeam);
        }

        //Update only core properties of the team object
        //To update config, use UpdateConfig
        [HttpPut("update/{code}")]
        public IActionResult Update(string code, [FromBody]TeamDTO updatedTeam)
        {
            Log.Information("Received team update request on team {0}", code);
            if (code != updatedTeam.Code)
            {
                Log.Error("Invalid team update request: Team {0} not found", code);
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                Log.Error("Invalid team update request: Invalid objects properties");
                return BadRequest("Invalid objects properties");
            }

            var teamEntity = _repositoryWrapper.TeamRepository.GetListQueryable
                .AsNoTracking().FirstOrDefault(x => x.Code == code);
            if (teamEntity == null)
            {
                Log.Error("Invalid team update request: Team {0} not found", code);
                return NotFound();
            }
            _mapper.Map(updatedTeam, teamEntity);

            _repositoryWrapper.TeamRepository.Update(teamEntity);
            _repositoryWrapper.UpdateDB();
            Log.Information("The team {0} has been updated.", code);
            return NoContent();
        }

        [HttpPut("config/update/{code}")]
        public IActionResult UpdateConfig(string code, [FromBody] ConfigDTO updatedConfig)
        {
            Log.Information("Received team config update request on team {0}", code);
            //find the team according to its code
            var team = _repositoryWrapper
                .TeamRepository
                .GetListQueryable
                .Include(t => t.Config)
                .FirstOrDefault(x => x.Code == code);
            if (team == null)
            {
                Log.Error("Invalid team config update request: Team {0} not found", code);
                return NotFound();
            }

            //check whether the port and ip provided by DTO object are already used
            var isSuccessful = _repositoryWrapper.ConfigRepository.CheckObject(updatedConfig);
            if (!isSuccessful)
            {
                Log.Error("Invalid team config update request: Conflict config.");
                return Conflict();
            }
            //map DTO values to team.config values
            _mapper.Map(updatedConfig, team.Config);

            _repositoryWrapper.TeamRepository.Update(team);

            _repositoryWrapper.UpdateDB();
            Log.Information("Finished team config update request on team {0}.");
            return NoContent();
        }

        [HttpGet("name/{teamName}")]
        public IActionResult GetByName(string teamName)
        {
            Log.Information("Get team by name request started on given name: {0}", teamName);
            var team = _repositoryWrapper.TeamRepository.FindByName(teamName);
            if (team == null)
            {
                Log.Error("Team name {0} not found", teamName);
                return NotFound();
            }
            Log.Information("Finshed get team by nane request on team {0}.", teamName);
            return Ok(team);
        }

        [HttpGet("code/{code}")]
        public IActionResult GetByCode(string code)
        {
            Log.Information("Get team by code request started on given code: {0}", code);
            var team = _repositoryWrapper.TeamRepository.FindByCode(code);
            if (team == null)
            {
                Log.Error("Team code {0} not found", code);
                return NotFound();
            }
            Log.Information("Finshed get team by code request on team {0}.", code);
            return Ok(team);
        }

        [HttpDelete("delete/{code}")]
        public ActionResult<Team> Delete(string code)
        {
            Log.Warning("Team DELETE request started on team {0}.", code);
            var team = _repositoryWrapper.TeamRepository.FindByCode(code);
            if (team == null)
            {
                Log.Error("Invalid team delete request: Team {0} not found.", code);
                return NotFound();
            }
            var config = team.Config;

            _repositoryWrapper.ConfigRepository.Delete(config);
            _repositoryWrapper.TeamRepository.DeleteRecord(team);
            _repositoryWrapper.UpdateDB();
            Log.Warning("Finished team delete request: Team {0} has been deleted.", code);
            return team;
        }
    }
}