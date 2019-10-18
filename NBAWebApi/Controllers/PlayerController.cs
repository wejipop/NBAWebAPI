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
        private readonly IPlayerServiceAdapter playerAdapter;
        private readonly IPlayerService playerService;
        
        public PlayerController(IPlayerServiceAdapter playerAdapter,IPlayerService playerService)
        {
            this.playerAdapter = playerAdapter;
            this.playerService = playerService;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<List<Player>> GetPlayer()
        {
            var players = await this.playerAdapter.GetAllPlayers();
            return players;
        }
        
        [HttpGet]
        [Route("load-player")]
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