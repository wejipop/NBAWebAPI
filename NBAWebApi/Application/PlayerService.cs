using System.Threading.Tasks;
using NBAWebApi.Adapters;

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
    }
    
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerServiceAdapter playerAdapter;
        
        /// <summary>
        /// Initializes a new instance of <see cref="PlayerService"/> class
        /// </summary>
        /// <param name="playerAdapter"></param>
        public PlayerService(IPlayerServiceAdapter playerAdapter)
        {
            this.playerAdapter = playerAdapter;
        }
        
        public async Task<bool> LoadPlayers()
        {
            var players = await playerAdapter.GetAllPlayers();
            if (players.Count == 0)
            {
                return false;
            }
            
            return true;
        }
    }
}