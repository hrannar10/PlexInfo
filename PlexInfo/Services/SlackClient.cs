using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace PlexInfo.Services
{
    public interface ISlackClient
    {
        Task<HttpResponseMessage> Send(string message, string channel = null);
    }
    public class SlackClient : ISlackClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public SlackClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<HttpResponseMessage> Send(string message, string channel = null)
        {

            // Read configuration
            string myKey1 = _configuration["myKey1"];
            Console.WriteLine(myKey1);

            string foo = _configuration.GetSection("foo").Value;
            Console.WriteLine(foo);

            var webhookUrl = new Uri("https://hooks.slack.com/services/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");

            var payload = new
            {
                text = message,
                channel,
                username = "PlexInfo",
                icon_emoji = ":alien:",
                message
            };
            var serializedPayload = JsonConvert.SerializeObject(payload);
            var response = await _httpClient.PostAsync(webhookUrl,
                new StringContent(serializedPayload, Encoding.UTF8, "application/json"));

            return response;
        }
    }
}
