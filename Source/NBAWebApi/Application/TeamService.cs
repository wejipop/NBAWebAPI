using NBAWebApi.Adapters;
using NBAWebApi.DataAccess;
using System.Threading.Tasks;

namespace NBAWebApi.Application
{
    public interface ITeamService
    {
        Task<bool> LoadTeams();
    }

    public class TeamService : ITeamService
    {
        private readonly ITeamServiceAdapter teamAdapter;
        private readonly ITeamRepository repository;

        public TeamService(ITeamServiceAdapter teamAdapter, ITeamRepository repository)
        {
            this.teamAdapter = teamAdapter;
            this.repository = repository;
        }

        public async Task<bool> LoadTeams()
        {
            var teams = await teamAdapter.GetAllTeams();
            if (teams.Count == 0) {
                return false;
            }

            return await this.repository.Add(teams);
        }
    }
}
