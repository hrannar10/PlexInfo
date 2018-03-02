using System.Linq;
using PlexInfo.Models;

namespace PlexInfo.Services
{
    public interface ITvShowService
    {
        SessionHistoryMetadata GetTvShowInfo(int rating_key);
    }

    class TvShowService : ITvShowService
    {
        public SessionHistoryMetadata GetTvShowInfo(int rating_key)
        {
            SessionHistoryMetadata show;

            using (var db = new PlexInfoContext())
            {
                show = (from shmi in db.session_history_metadata
                    where shmi.rating_key == rating_key
                            select shmi).FirstOrDefault();
            }
            return show;
        }
    }
}
