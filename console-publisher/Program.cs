using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Azure.SignalR.Management;
using Microsoft.Extensions.Configuration;

class Program
{
    static async Task Main(string[] args)
    {
        // Build configuration
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration config = builder.Build();
        var connectionString = config["SignalR:ConnectionString"];
        var hubName = config["SignalR:HubName"];

        // Create a ServiceManager instance
        var serviceManager = new ServiceManagerBuilder()
            .WithOptions(option =>
            {
                option.ConnectionString = connectionString;
            })
            .Build();

        // Create a HubContext
        var hubContext = await serviceManager.CreateHubContextAsync(hubName);
        Console.WriteLine("Connected to the SignalR hub");

        while (true)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            await hubContext.Clients.All.SendAsync("ReceiveMessage", "ConsoleApp", timestamp);
            Console.WriteLine($"Message sent: {timestamp}");
            await Task.Delay(10000); // Send a message every 10 seconds
        }
    }
}
