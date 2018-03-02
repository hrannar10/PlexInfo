namespace PlexInfo.Models
{
    public class AppSettings
    {
        public string Title { get; set; }
        public Slack Slack { get; set; }
    }

    public class Slack
    {
        public string WebHookUrl { get; set; }
        public string Username { get; set; }
        public string IconEmoji { get; set; }
    }
}
