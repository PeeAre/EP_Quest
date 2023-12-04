using EP_Quest.Models;
using EP_Quest.Services;
using Microsoft.EntityFrameworkCore;

namespace EP_Quest
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddServerSideBlazor();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddDbContext<QuestDbContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:PostgreSQL_Connection"]);
            }, ServiceLifetime.Transient);
            services.AddTransient<IQuestRepository, QuestRepository>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, QuestDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/Error");
            }

            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseRouting();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true
            });
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToFile("/Components/Routing");
            });
            DatabaseService.EnsurePopulated(dbContext);
        }
    }
}