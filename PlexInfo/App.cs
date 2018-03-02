using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PlexInfo.Models;
using PlexInfo.Services;

namespace PlexInfo
{
    public class App
    {
        private readonly ITestService _testService;
        private readonly ISlackService _slack;
        private readonly ILogger<App> _logger;
        private readonly AppSettings _config;

        public App(ITestService testService,
            ISlackService slack,
            IOptions<AppSettings> config,
            ILogger<App> logger)
        {
            _testService = testService;
            _slack = slack;
            _logger = logger;
            _config = config.Value;
        }

        public void Run()
        {
            _logger.LogInformation($"This is a console application for {_config.Title}");
            _testService.Run();
            _slack.SendMessage("New test message");
            System.Console.ReadKey();
        }
    }
}
