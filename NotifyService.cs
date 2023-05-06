namespace ResetWindows
{
    public class NotifyService : BackgroundService
    {
        private readonly ILogger<NotifyService> _logger;
        private readonly IServiceProvider _services;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("NotifyService started at: {time}", DateTimeOffset.Now);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ResetForm theForm = (ResetForm)_services.GetService(typeof(ResetForm))!;
            theForm.Lifetime = _hostApplicationLifetime;
            Application.Run(theForm);
            return Task.CompletedTask;
        }

        public NotifyService(ILogger<NotifyService> logger, IServiceProvider services, IHostApplicationLifetime hostApplicationLifetime)
        {
            _logger = logger;
            _services = services;
            _hostApplicationLifetime = hostApplicationLifetime;
        }
    }
}
