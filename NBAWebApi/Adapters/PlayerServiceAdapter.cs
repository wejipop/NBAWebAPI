using System;
using System.Collections.Generic;
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
            return value.League.Standard;
        }
    }
}
