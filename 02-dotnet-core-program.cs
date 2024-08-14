IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, builder) =>
    {
        var hostingEnvironment = hostContext.HostingEnvironment;
        var envName = hostingEnvironment.EnvironmentName;
        builder.AddJsonFile($"appsettings.json")
               .AddJsonFile($"appsettings.{envName}.json", optional: true, reloadOnChange: true);
        builder.AddEnvironmentVariables();
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
