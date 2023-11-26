﻿using EP_Quest.Models;
using EP_Quest.Services;
using Microsoft.EntityFrameworkCore;

namespace EP_Quest
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddServerSideBlazor();
            services.AddDbContext<QuestDbContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:PostgreSQL_Connection"]);
            });
            services.AddScoped<IQuestRepository, QuestRepository>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, QuestDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapDefaultControllerRoute();
            });
            DatabaseService.EnsurePopulated(dbContext);
        }
    }
}