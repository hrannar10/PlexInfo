using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlexInfo.Services;

namespace PlexInfo
{
    public class Program
    {
        private static IConfigurationRoot _configuration;
        public static void Main(string[] args)
        {
            // Adding JSON file into IConfiguration.
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();

            // setup out DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IUtilities, Utilities>()
                .AddSingleton<ISlackClient, SlackClient>()
                .BuildServiceProvider();
            var utilities = serviceProvider.GetService<IUtilities>();
            var bleh = serviceProvider.GetService<IConfiguration>();
            var slackClient = serviceProvider.GetService<ISlackClient>();

            using (var db = new PlexInfoContext())
            {
                foreach (var section in db.session_history)
                {
                    Console.WriteLine(" - {0}", utilities.UnixTimestampToDateTime(section.started));
                }
            }



            slackClient.Send("new message");

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
