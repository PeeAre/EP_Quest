using EP_Quest.Models;
using EP_Quest.Services;
using EP_Quest.Services.Classes;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            services.AddLogging();
            services.AddTransient<IQuestRepository, QuestRepository>();
            services.AddDatabaseService();
            services.AddDropboxService(Configuration);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            QuestDbContext dbContext, DatabaseService dbService)
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
            });
            dbService.EnsurePopulated(dbContext);
        }
    }
}