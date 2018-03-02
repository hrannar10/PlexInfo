using System;

namespace PlexInfo.Models
{
    public class SessionHistoryMetadata
    {
        public int id { get; set; }
        public int rating_key { get; set; }
        public int parent_rating_key { get; set; }
        public int grandparent_rating_key { get; set; }
        public string title { get; set; }
        public string parent_title { get; set; }
        public string grandparent_title { get; set; }
        public string full_title { get; set; }
        public int media_index { get; set; }
        public int parent_media_index { get; set; }
        public int section_id { get; set; }
        public string thumb { get; set; }
        public string parent_Thumb { get; set; }
        public string grandparent_thumb { get; set; }
        public string art { get; set; }
        public string media_type { get; set; }
        public int year { get; set; }
        public double originally_available_at { get; set; }
        public double added_at { get; set; }
        public double updated_at { get; set; }
        public double last_viewed_at { get; set; }
        public string content_rating { get; set; }
        public string summary { get; set; }
        public string tagline { get; set; }
        public string rating { get; set; }
        public int duration { get; set; }
        public string guid { get; set; }
        public string directors { get; set; }
        public string writers { get; set; }
        public string actors { get; set; }
        public string genres { get; set; }
        public string studio { get; set; }
        public string labels { get; set; }
    }
}
