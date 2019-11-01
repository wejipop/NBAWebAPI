using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBAWebApi.Models;

namespace NBAWebApi.DataAccess.SqlRepositories
{
    public class SqlTeamRepository : ITeamRepository
    {
        private AppDbContext context;

        public SqlTeamRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Add(Team team)
        {
            this.context.Teams.Add(team);
            return await this.ProcessSaveResultAsync();
        }

        public async Task<bool> Add(IEnumerable<Team> teams)
        {
            this.context.Teams.AddRange(teams);
            return await this.ProcessSaveResultAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var team = this.context.Teams.FindAsync(id);
            if (team != null)
            {
                this.context.Remove(team);
            }

            return await this.ProcessSaveResultAsync();
        }

        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            return await this.context.Teams.ToListAsync();
        }

        public async Task<Team> GetTeam(int id)
        {
            return await this.context.Teams.FindAsync(id);
        }

        public async Task<bool> Update(Team updatedTeam)
        {
            var team = this.context.Teams.Attach(updatedTeam);
            team.State = EntityState.Modified;
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
    }
}
