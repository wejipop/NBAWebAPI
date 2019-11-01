using NBAWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBAWebApi.DataAccess
{
    public interface ITeamRepository
    {
        /// <summary>
        /// Gets a team based on Id
        /// </summary>
        /// <param name="id">The team id.</param>
        /// <returns>Team model.</returns>
        Task<Team> GetTeam(int id);

        /// <summary>
        /// Gets all team from db
        /// </summary>
        /// <returns>A collection of all teams.</returns>
        Task<IEnumerable<Team>> GetAllTeams();

        /// <summary>
        /// Adds a team to the database
        /// </summary>
        /// <param name="Team">The team to add.</param>
        /// <returns>True if operation was successful, false otherwise.</returns>
        Task<bool> Add(Team team);

        /// <summary>
        /// Adds a team to the database
        /// </summary>
        /// <param name="teams">The teams to add.</param>
        /// <returns>True if operation was successful, false otherwise.</returns>
        Task<bool> Add(IEnumerable<Team> teams);

        /// <summary>
        /// Deletes a team based on id
        /// </summary>
        /// <param name="updatedTeam">The updated team model.</param>
        /// <returns>True if operation was successful, false otherwise.</returns>
        Task<bool> Update(Team updatedTeam);

        /// <summary>
        /// Deletes a team based on id
        /// </summary>
        /// <param name="id">The id of the team to delete.</param>
        /// <returns>True if operation was successful, false otherwise.</returns>
        Task<bool> Delete(int id);
    }
}
