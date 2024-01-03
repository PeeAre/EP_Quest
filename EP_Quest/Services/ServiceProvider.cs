using EP_Quest.Services.Common;

namespace EP_Quest.Services
{
    public static class ServiceProvider
    {
        public static void AddDatabaseService(this IServiceCollection services)
        {
            services.AddTransient<DatabaseService>();
        }
    }
}
