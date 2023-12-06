﻿using EP_Quest.Services.Classes;

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
    }
}