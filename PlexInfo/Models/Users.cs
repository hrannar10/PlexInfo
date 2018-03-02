namespace PlexInfo.Models
{
    public class Users
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string username { get; set; }
        public string friendly_name { get; set; }
        public string thumb { get; set; }
        public string custom_avatar_url { get; set; }
        public string email { get; set; }
        public int? is_home_user { get; set; }
        public int? is_allow_sync { get; set; }
        public int? is_restricted { get; set; }
        public int do_notify { get; set; }
        public int keep_history { get; set; }
        public int deleted_user { get; set; }
        public int allow_guest { get; set; }
        public string user_token { get; set; }
        public string server_token { get; set; }
        public string shared_libraries { get; set; }
        public string filter_all { get; set; }
        public string filter_movies { get; set; }
        public string filter_tv { get; set; }
        public string filter_music { get; set; }
        public string filter_photos { get; set; }
    }
}
