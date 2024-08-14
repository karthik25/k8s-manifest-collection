public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IHostApplicationLifetime _lifetime;
    private readonly IConfiguration _configuration;

    public Worker(ILogger<Worker> logger, IHostApplicationLifetime lifetime, IConfiguration configuration)
    {
        _logger = logger;
        _lifetime = lifetime;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        await Task.Delay(1000, stoppingToken);

        _logger.LogInformation($"Environment identified as {_configuration["ASPNETCORE_ENVIRONMENT"]}");
        _logger.LogInformation($"Received email identified as {_configuration["RECEIVER_EMAIL"]}");

        // TODO: Perform the activities intended

        _logger.LogInformation("Worker stopping at {time}", DateTimeOffset.Now);
        _lifetime.StopApplication();
    }
}
