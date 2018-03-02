using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PlexInfo.Models;


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
        private readonly ITvShowService _tvShowService;

        public StatisticsService(
            ILogger<StatisticsService> logger,
            IOptions<AppSettings> config, 
            IUtilities utilities, 
            ITvShowService tvShowService)
        {
            _logger = logger;
            _utilities = utilities;
            _tvShowService = tvShowService;
            _config = config.Value;
        }

        public string MostViewedTvShows()
        {
            using (var db = new PlexInfoContext())
            {
                var mvts = (from sh in db.session_history
                    join shm in db.session_history_metadata on sh.rating_key equals shm.rating_key
                    where _utilities.UnixTimestampToDateTime(sh.started) > DateTime.Now.AddDays(-7)
                    where shm.section_id == 1
                    group shm by shm.rating_key
                    into g
                    select new
                    {
                        rating_key = g.Key,
                        count = g.Count()
                    }).Take(5);

                var result = "Most viewed tv shows\n";
                foreach (var show in mvts.OrderByDescending(x => x.count))
                {
                    var showInfo = _tvShowService.GetTvShowInfo(show.rating_key);

                    result = result + (showInfo.grandparent_title + 
                                    " - " + showInfo.parent_title +
                                    " - " + showInfo.title +
                                    " | views: " + show.count + "\n");
                }
                return result;
            }
        }

        public string MostViewedMovies()
        {
            using (var db = new PlexInfoContext())
            {
                var mvm = (from sh in db.session_history
                    join shm in db.session_history_metadata on sh.rating_key equals shm.rating_key
                    where _utilities.UnixTimestampToDateTime(sh.started) > DateTime.Now.AddDays(-7)
                    where shm.section_id == 3
                    group shm by shm.title
                    into g
                    select new
                    {
                        title = g.Key,
                        count = g.Count()
                    }).Take(5);

                var result = "Most viewed movies\n";
                foreach (var movie in mvm.OrderByDescending(x => x.count))
                {
                    result = result + (movie.title + " views: " + movie.count + "\n");
                }
                return result;
            }
        }

        public string MostActiveUser()
        {
            using (var db = new PlexInfoContext())
            {
                var mau = (from sh in db.session_history
                    join u in db.users on sh.user_id equals u.user_id
                    where _utilities.UnixTimestampToDateTime(sh.started) > DateTime.Now.AddDays(-7)
                    group u by u.username
                    into g
                    select new
                    {
                        username = g.Key,
                        count = g.Count()
                    }).Take(5);

                var result = "Most active users\n";
                foreach (var user in mau.OrderByDescending(x => x.count))
                    result = result + (user.username + " views: " + user.count + "\n");
                return result;
            }
        }
    }
}
