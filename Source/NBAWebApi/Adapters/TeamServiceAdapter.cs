using NBAWebApi.Acl;
using NBAWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NBAWebApi.Adapters
{
    public interface ITeamServiceAdapter
    {
        Task<List<Team>> GetAllTeams();
    }

    public class TeamServiceAdapter : ITeamServiceAdapter
    {
        private static readonly int currentSeason = DateTime.Now.Year;
        private readonly IHttpClientFactory clientFactory;
        private static readonly string RequestUrl = $"http://data.nba.net/prod/v2/{currentSeason}/teams.json";

        public TeamServiceAdapter(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<List<Team>> GetAllTeams()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, RequestUrl);

            var client = this.clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await this.ReadAsJsonAsync(response.Content);
                return result;
            }

            return new List<Team>();
        }

        private async Task<List<Team>> ReadAsJsonAsync(HttpContent content)
        {
            var jsonString = await content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<NBAResultFormat<ExternalTeam>>(jsonString);
            return this.MapToInternalModel(value.League.Standard);
        }

        private List<Team> MapToInternalModel(List<ExternalTeam> externalTeams)
        {

            return externalTeams.Select(et =>
            {
                int.TryParse(et.TeamId, out var id);

                return new Team
                {
                    Id = id,
                    IsNBAFranchise = et.IsNBAFranchise,
                    IsAllStar = et.IsAllStar,
                    City = et.City,
                    FullName = et.FullName,
                    Tricode = et.Tricode,
                    Nickname = et.Nickname,
                    ConfName = et.ConfName
                };
            }
            ).ToList();
        }
    }
}
