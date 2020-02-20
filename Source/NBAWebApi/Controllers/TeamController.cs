using Microsoft.AspNetCore.Mvc;
using NBAWebApi.Application;
using System.Threading.Tasks;

namespace NBAWebApi.Controllers
{
    [Route("v1/team")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;

        public TeamController (ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        [Route("load-teams")]
        public async Task<bool> GetTeams()
        {
            var team = await this.teamService.LoadTeams();
            return team;
        }
    }
}
