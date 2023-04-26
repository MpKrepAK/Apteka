using Microsoft.AspNetCore;

namespace UIL;

public class Program
{
    public static void Main(string[] args)
    {
        Create(args).Build().Run();
    }
    public static IWebHostBuilder Create(string[] args) =>
        WebHost.CreateDefaultBuilder(args).ConfigureLogging(logBuilder =>
            {
                logBuilder.ClearProviders();
                logBuilder.AddConsole();
                logBuilder.AddTraceSource("Information, ActivityTracing");
                logBuilder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);
            })
            .UseStartup<Startup>();
}