using System;

namespace PlexInfo.Models
{
    public class SessionHistory
    {
        public int id { get; set; }
        public int reference_id { get; set; }
        public double started { get; set; }
        public double stopped { get; set; }
        public int rating_key { get; set; }
        public int user_id { get; set; }
        public string user { get; set; }
        public string ip_address { get; set; }
        public int paused_counter { get; set; }
        public string player { get; set; }
        public string platform { get; set; }
        public string machine_id { get; set; }
        public int parent_rating_key { get; set; }
        public int grandparent_rating_key { get; set; }
        public string media_type { get; set; }
        public int view_offset { get; set; }
    }
}
