using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NBAWebApi.Acl;
using NBAWebApi.Models;
using Newtonsoft.Json;

namespace NBAWebApi.Adapters
{
    public interface IPlayerServiceAdapter
    {
        Task<List<Player>> GetAllPlayers();
    }
    
    public class PlayerServiceAdapter : IPlayerServiceAdapter
    {
        private readonly IHttpClientFactory clientFactory;
        private static readonly string RequestUrl = $"http://data.nba.net/prod/v1/{DateTime.Now.Year}/players.json";

        public PlayerServiceAdapter(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<List<Player>> GetAllPlayers()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, RequestUrl);
            
            var client = this.clientFactory.CreateClient();
            
            var response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await this.ReadAsJsonAsync(response.Content);
                return result;
            }
            
            return new List<Player>();
        }
        
        private async Task<List<Player>> ReadAsJsonAsync(HttpContent content)
        {
            var jsonString = await content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<NBAPlayerResultFormat>(jsonString);
            return this.MapToInternalModel(value.League.Standard);
        }

        private List<Player> MapToInternalModel(List<ExternalPlayer> externalPlayers)
        {
            return externalPlayers.Select(ep =>
            {
                int.TryParse(ep.PersonId, out var id);
                int.TryParse(ep.TeamId, out var teamId);
                int.TryParse(ep.HeightFeet, out var heightFeet);
                int.TryParse(ep.HeightInches, out var heightInches);
                int.TryParse(ep.WeightPounds, out var weightPounds);
                DateTime.TryParse(ep.DateOfBirthUTC, out var dob);
                
                return new Player
                {
                    Id = id,
                    FirstName = ep.FirstName,
                    LastName = ep.LastName,
                    HeightInches = heightInches,
                    HeightFeet = heightFeet,
                    TeamId = teamId,
                    WeightPounds = weightPounds,
                    Country = ep.Country,
                    DateOfBirthUTC = dob
                };
            }
            ).ToList();
        }
    }
}
