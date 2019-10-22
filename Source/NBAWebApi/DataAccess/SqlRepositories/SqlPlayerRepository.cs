using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBAWebApi.Models;

namespace NBAWebApi.DataAccess.SqlRepositories
{
    public class SqlPlayerRepository : IPlayerRepository
    {
        private readonly DateTime SQL_DATE_MIN_VALUE = DateTime.Parse(System.Data.SqlTypes.SqlDateTime.MinValue.ToString());
        private readonly DateTime SQL_DATE_MAX_VALUE = DateTime.Parse(System.Data.SqlTypes.SqlDateTime.MaxValue.ToString());

        private readonly AppDbContext context;

        public SqlPlayerRepository(AppDbContext context)
        {
            this.context = context;
        }
        
        public async Task<Player> GetPlayer(int id)
        {
            return await this.context.Players.FindAsync(id);
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await this.context.Players.ToListAsync();
        }

        public async Task<bool> Add(Player player)
        {
            this.ValidatePlayer(player);
            this.context.Players.Add(player);
            return await this.ProcessSaveResultAsync();
        }

        public async Task<bool> Add(IEnumerable<Player> players)
        {
            var validatedPlayers = players.Select(this.ValidatePlayer).ToList();
            this.context.Players.AddRange(validatedPlayers);
            return await this.ProcessSaveResultAsync();
        }

        public async Task<bool> Update(Player updatedPlayer)
        {
            var player = this.context.Players.Attach(updatedPlayer);
            this.ValidatePlayer(updatedPlayer);
            player.State = EntityState.Modified;
            return await this.ProcessSaveResultAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var player = await this.context.Players.FindAsync(id);
            if (player != null)
            {
                this.context.Remove(player);
            }

            return await this.ProcessSaveResultAsync();
        }

        private async Task<bool> ProcessSaveResultAsync()
        {
            var resultStateEntries = await context.SaveChangesAsync();
            // If no entries were changed we consider operation failed
            if (resultStateEntries == 0)
            {
                return false;
            }
            
            return true;
        }
        
        private bool IsValidSqlDateTime(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return true;
            }
            
            if (this.SQL_DATE_MIN_VALUE > dateTime.Value || this.SQL_DATE_MAX_VALUE < dateTime.Value)
                return false;

            return true;
        }

        private Player ValidatePlayer(Player player)
        {
            if (!this.IsValidSqlDateTime(player.DateOfBirthUTC))
            {
                player.DateOfBirthUTC = this.SQL_DATE_MIN_VALUE;
            }

            return player;
        }
    }
}