using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace firstConsoleApp
{
    public class Worker(ILogger<Worker> logger, IConfiguration config) : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("--------------");
            logger.LogInformation("Hellow Mikrus");
            int doInterval = Convert.ToInt32(config["DoInterval"]);
            logger.LogInformation($"DoInterval: {doInterval}");
            Random rnd = new Random();
            int i = 1;
            while (!stoppingToken.IsCancellationRequested)
            {
                i = rnd.Next(30, 91);
                logger.LogInformation($"Random {i}");
                await Task.Delay((doInterval + i) * 200, stoppingToken);
            }
        }
    }
}
