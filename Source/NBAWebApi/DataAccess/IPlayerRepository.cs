using System.Collections.Generic;
using System.Threading.Tasks;
using NBAWebApi.Models;

namespace NBAWebApi.DataAccess
{
    public interface IPlayerRepository
    {
        /// <summary>
        /// Gets a players based on Id
        /// </summary>
        /// <param name="id">The player id.</param>
        /// <returns>Player model.</returns>
        Task<Player> GetPlayer(int id);
        
        /// <summary>
        /// Gets all players from db
        /// </summary>
        /// <returns>A collection of all players.</returns>
        Task<IEnumerable<Player>> GetAllPlayers();
        
        /// <summary>
        /// Adds a player to the database
        /// </summary>
        /// <param name="player">The player to add.</param>
        /// <returns>True if operation was successful, false otherwise.</returns>
        Task<bool> Add(Player player);
        
        /// <summary>
        /// Adds a player to the database
        /// </summary>
        /// <param name="players">The players to add.</param>
        /// <returns>True if operation was successful, false otherwise.</returns>
        Task<bool> Add(IEnumerable<Player> players);
        
        /// <summary>
        /// Deletes a player based on id
        /// </summary>
        /// <param name="updatedPlayer">The updated player model.</param>
        /// <returns>True if operation was successful, false otherwise.</returns>
        Task<bool> Update(Player updatedPlayer);
        
        /// <summary>
        /// Deletes a player based on id
        /// </summary>
        /// <param name="id">The id of the player to delete.</param>
        /// <returns>True if operation was successful, false otherwise.</returns>
        Task<bool> Delete(int id);
    }
}