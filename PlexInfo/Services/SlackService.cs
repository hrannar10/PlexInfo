using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PlexInfo.Models;

namespace PlexInfo.Services
{
    public interface ISlackService
    {
        Task<HttpResponseMessage> SendMessage(string message, string channel = null);
    }

    class SlackService : ISlackService
    {
        private readonly ILogger<SlackService> _logger;
        private readonly AppSettings _config;
        private readonly HttpClient _httpClient = new HttpClient();

        public SlackService(
            ILogger<SlackService> logger,
            IOptions<AppSettings> config)
        {
            _logger = logger;
            _config = config.Value;
        }

        public async Task<HttpResponseMessage> SendMessage(string message, string channel = null)
        {
            _logger.LogInformation("Sending message to slack.");

            var payload = new
            {
                text = message,
                channel,
                username = _config.Slack.Username,
                icon_emoji = _config.Slack.IconEmoji,
                message
            };
            var serializedPayload = JsonConvert.SerializeObject(payload);

            return await _httpClient.PostAsync(_config.Slack.WebHookUrl,
                new StringContent(serializedPayload, Encoding.UTF8, "application/json"));
        }
    }
}
