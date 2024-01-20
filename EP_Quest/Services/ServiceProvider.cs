using EP_Quest.Services.Common;

namespace EP_Quest.Services
{
    public static class ServiceProvider
    {
        public static void AddDatabaseService(this IServiceCollection services)
        {
            services.AddSingleton<DatabaseService>();
        }
        public static void AddNotificationService(this IServiceCollection services)
        {
            services.AddSingleton<NotificationService>();
        }
        public static void AddSendersService(this IServiceCollection services)
        {
            services.AddTransient<TelegramSender>();
        }
    }
}
