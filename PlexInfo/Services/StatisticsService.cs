using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PlexInfo.Models;

namespace PlexInfo.Services
{
    public interface IStatisticsService
    {
        
    }

    class StatisticsService : IStatisticsService
    {
        private readonly ILogger<StatisticsService> _logger;
        private readonly AppSettings _config;

        public StatisticsService(
            ILogger<StatisticsService> logger,
            IOptions<AppSettings> config)
        {
            _logger = logger;
            _config = config.Value;
        }
    }
}
