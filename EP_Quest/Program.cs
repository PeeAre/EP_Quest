namespace EP_Quest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(options =>
                    {
                        options.ListenAnyIP(443, listenOptions =>
                        {
                            listenOptions.UseHttps("4yana.pl.certificate.pem", "4yana.pl.key.txt");
                        });
                    });
                });
    }
}
