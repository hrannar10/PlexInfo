using System;
using System.Linq;
using System.Transactions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PlexInfo.Models;
using Remotion.Linq.Clauses;
using Remotion.Linq.Parsing.Structure.IntermediateModel;


// https://stackoverflow.com/questions/21051612/entity-framework-join-3-tables
namespace PlexInfo.Services
{
    public interface IStatisticsService
    {
        string MostViewedTvShows();
        string MostViewedMovies();
        string MostActiveUser();
    }

    class StatisticsService : IStatisticsService
    {
        private readonly ILogger<StatisticsService> _logger;
        private readonly AppSettings _config;
        private readonly IUtilities _utilities;

        public StatisticsService(
            ILogger<StatisticsService> logger,
            IOptions<AppSettings> config, 
            IUtilities utilities)
        {
            _logger = logger;
            _utilities = utilities;
            _config = config.Value;
        }

        public string MostViewedTvShows()
        {
            throw new System.NotImplementedException();
        }

        public string MostViewedMovies()
        {
            throw new System.NotImplementedException();
        }

        public string MostActiveUser()
        {
            using (var db = new PlexInfoContext())
            {
                var mvm = (from sh in db.session_history
                    join u in db.users on sh.user_id equals u.user_id
                    where _utilities.UnixTimestampToDateTime(sh.started) > DateTime.Now.AddDays(-2)
                    group u by u.username
                    into g
                    select new
                    {
                        username = g.Key,
                        count = g.Count()
                    });

                return Enumerable.Aggregate(mvm.OrderByDescending(x => x.count), "Most active users:\n", (current, user) => current + (user.username + " views: " + user.count + "" + "\n"));
            }
        }
    }
}
