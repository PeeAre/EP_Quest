using EP_Quest.Services.Common;

namespace EP_Quest.Services
{
    public static class ServiceProvider
    {
        public static void AddDatabaseService(this IServiceCollection services)
        {
            services.AddTransient<DatabaseService>();
        }
        public static void AddNotificationService(this IServiceCollection services)
        {
            services.AddScoped<NotificationService>();
        }
        public static void AddDropboxService(this IServiceCollection services, IConfiguration configuration)
        {
            var refreshToken = configuration["DropboxAccess:RefreshAccessToken"];
            var appKey = configuration["DropboxAccess:ApplicationKey"];
            var appSecret = configuration["DropboxAccess:ApplicationSecret"];

            services.AddSingleton(new DropboxService(refreshToken, appKey, appSecret));
        }
    }
}
