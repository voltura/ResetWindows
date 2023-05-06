using ResetWindows;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<NotifyService>();
        services.AddSingleton<ResetForm>();
    })
    .Build();

host.Run();
