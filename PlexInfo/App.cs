using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PlexInfo.Models;
using PlexInfo.Services;

namespace PlexInfo
{
    public class App
    {
        private readonly ISlackService _slack;
        private readonly IStatisticsService _statistics;
        private readonly ILogger<App> _logger;
        private readonly AppSettings _config;

        public App(
            ISlackService slack,
            IStatisticsService statistics,
            IOptions<AppSettings> config,
            ILogger<App> logger)
        {
            _slack = slack;
            _statistics = statistics;
            _logger = logger;
            _config = config.Value;
        }

        public void Run()
        {
            _logger.LogInformation($"This is a console application for {_config.Title}");

            _slack.SendMessage(_statistics.MostActiveUser());
            //_slack.SendMessage(_statistics.MostViewedMovies());
            //_slack.SendMessage(_statistics.MostViewedTvShows());
            
            System.Console.ReadKey();
        }
    }
}
