using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NBAWebApi.Adapters;
using NBAWebApi.Application;
using NBAWebApi.Models;



namespace NBAWebApi.Controllers
{
    [Route("v1/player")]
    [ApiController]
    public class PlayerController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }
        
        [HttpGet]
        [Route("")]
        public Task<IEnumerable<Player>> GetPlayer()
        {
            var players = this.playerService.GetAllPlayers();
            return players;
        }
        
        [HttpGet]
        [Route("load-players")]
        public async Task<string> LoadPlayers()
        {
            var result = await this.playerService.LoadPlayers();

            if (result == false)
            {
                return "System Failed";
            }

            return "Yay";
        }
    }
}