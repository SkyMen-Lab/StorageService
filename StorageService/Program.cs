using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace StorageService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .ConfigureAppConfiguration((hosting, config) =>
                    {
                        var env = hosting.HostingEnvironment;
                        config.AddJsonFile("appsettings.json", true, true);
                        config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
                    });
                }).UseSerilog((hostingCtx, logger) => {
                    logger
                        .ReadFrom.Configuration(hostingCtx.Configuration)
                        .Enrich.FromLogContext()
                        .WriteTo.Console();
                });
    }
}