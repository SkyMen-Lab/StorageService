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
        // GET
        //TODO: Validation, authorisation, creating/deleting
        public IEnumerable<Team> Index()
        {
            //Get the first ten teams depending on the rating
            var teams = _repositoryWrapper.TeamRepository.GetListQueryable
                .Include(t => t.Config)
                .ToList();
            return teams;
        }

        [HttpGet]
        [Route("create/{teamName?}")]
        public IActionResult Create(string teamName)
        {
            if (_repositoryWrapper.TeamRepository.FindByName(teamName) != null) return Problem();
            Random rnd = new Random();
            var config = _repositoryWrapper.ConfigRepository.CreateNew("95.130.97." + rnd.Next(0, 300),
                rnd.Next(1000, 3000), ConnectionType.UDP);
            var team = _repositoryWrapper.TeamRepository.CreateNew(teamName, config);
            _repositoryWrapper.UpdateDB();
            var objectList = _repositoryWrapper.TeamRepository.GetList.Where(t =>
                t.Name == teamName).ToList();
            return Ok(objectList);
        }

        [HttpGet]
        [Route("get/{teamName?}")]
        public IActionResult Get(string teamName)
        {
            var ob = _repositoryWrapper.TeamRepository.FindByName(teamName);
            if (ob == null) return NotFound();
            return Ok(ob);
        }
    }
}