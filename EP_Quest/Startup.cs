using EP_Quest.Models;
using EP_Quest.Services;
using EP_Quest.Services.Common;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            services.AddCors();
            services.AddSendersService();
            services.AddHttpContextAccessor();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<QuestDbContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:PostgreSQL_Connection"]);
            }, ServiceLifetime.Transient);
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Logs/log.txt",
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            services.AddLogging();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.SlidingExpiration = true;
                });
            services.AddTransient<IQuestRepository, QuestRepository>();
            services.AddDatabaseService();
            services.AddNotificationService();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
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
            app.UseAuthentication();
            app.UseCors(corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapDefaultControllerRoute();
            });
            dbService.EnsurePopulated(dbContext);
        }
    }
}