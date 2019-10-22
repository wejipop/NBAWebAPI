using System.Collections.Generic;
using System.Threading.Tasks;
using NBAWebApi.Adapters;
using NBAWebApi.DataAccess;
using NBAWebApi.Models;

namespace NBAWebApi.Application
{
    /// <summary>
    /// Service for anything related to player
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Loads player into system from NBA Database
        /// </summary>
        /// <returns>True if task was successful, else false</returns>
        Task<bool> LoadPlayers();

        /// <summary>
        /// Gets all players from the database
        /// </summary>
        /// <returns>Returns a collection of players.</returns>
        Task<IEnumerable<Player>> GetAllPlayers();
    }
    
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerServiceAdapter playerAdapter;
        private readonly IPlayerRepository repository;

        /// <summary>
        /// Initializes a new instance of <see cref="PlayerService"/> class
        /// </summary>
        /// <param name="playerAdapter"></param>
        /// <param name="repository"></param>
        public PlayerService(IPlayerServiceAdapter playerAdapter, IPlayerRepository repository)
        {
            this.playerAdapter = playerAdapter;
            this.repository = repository;
        }
        
        public async Task<bool> LoadPlayers()
        {
            var players = await playerAdapter.GetAllPlayers();
            if (players.Count == 0)
            {
                return false;
            }

            return await this.repository.Add(players);
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await this.repository.GetAllPlayers();
        }
    }
}