namespace PlexInfo.Models
{
    public class LibrarySections
    {
        public int id { get; set; }
        public string server_id { get; set; }
        public int section_id { get; set; }
        public string section_name { get; set; }
        public string section_type { get; set; }
        public string thumb { get; set; }
        public string custom_thumb_url { get; set; }
        public string art { get; set; }
        public int count { get; set; }
        public int? parent_count { get; set; }
        public int? child_count { get; set; }
        public int do_notify { get; set; }
        public int do_notify_created { get; set; }
        public int keep_history { get; set; }
        public int deleted_section { get; set; }
    }
}
