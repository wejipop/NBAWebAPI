using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NBAWebApi.Adapters;
using NBAWebApi.Application;
using NBAWebApi.DataAccess;
using NBAWebApi.DataAccess.SqlRepositories;
using NBAWebApi.Models;

namespace NBAWebApi
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddHttpClient();
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("NbaLocalDBConnection")));

            services.AddScoped<ITeamServiceAdapter, TeamServiceAdapter>();
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<IPlayerServiceAdapter, PlayerServiceAdapter>();
            services.AddScoped<IPlayerRepository, SqlPlayerRepository>();
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}