using ASP.Net_Core_RazorPages_Learn.Models;

using System.Diagnostics;

namespace ASP.Net_Core_RazorPages_Learn.BackgraundServices;

public sealed class ServerStartingNotifier : BackgroundService
{
    private readonly IEmailSender _emailSender;
    private readonly ILogger<ServerStartingNotifier> _logger;
    
    PerformanceCounter cpuCounter;


    public ServerStartingNotifier(
        IEmailSender? emailSender,
        ILogger<ServerStartingNotifier> logger)
    {
        _emailSender = emailSender;
        _logger = logger;
        _logger.LogDebug(nameof(ServerStartingNotifier));
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Сервер запущен");

        await SendNotificationEverySecond();

        try
        {
            await _emailSender.SendAsync(
                "admin@sevice.ru",
                "Сервер запущен",
                "Сервер запущен в " + DateTime.Now,
                "my-email@yandex.ru",
                stoppingToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Ошибка при попытке отправить Email");
        }

    }

    public async Task SendNotificationEverySecond()
    {
        var cpuCounter = new PerformanceCounter(
            categoryName:"Processor",
            counterName:"% Processor Time",
            instanceName:"_Total");
        
        var ramCounter = new PerformanceCounter(
            categoryName:"Memory",
            counterName:"Available MBytes");
        
        while (true)
        {
            
            try
            {
                var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

                string body = "Сервер работает.\n" +
                              $"CPU:\n{cpuCounter.NextValue()}\n" +
                              $"RAM:\n{ramCounter.NextValue()}" ;
                
                await _emailSender.SendAsync(
                    "admin@sevice.ru",
                    "Сервер работает",
                    body,
                    "my-email@yandex.ru",
                    cts.Token);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ошибка при попытке отправить Email");
            }

            await Task.Delay(TimeSpan.FromSeconds(5));
        }
    }

}