namespace PlexInfo.Models
{
    public class SessionHistoryMediaInfo
    {
        public int id { get; set; }
        public int rating_key { get; set; }
        public string video_decision { get; set; }
        public string audio_decision { get; set; }
        public string transcode_decision { get; set; }
        public int duration { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string container { get; set; }
        public string video_codec { get; set; }
        public int bitrate { get; set; }
        public string video_resolution { get; set; }
        public string video_framerate { get; set; }
        public string aspect_ratio { get; set; }
        public int audio_channels { get; set; }
        public string transcode_protocol { get; set; }
        public string transcode_container { get; set; }
        public string transcode_video_codec { get; set; }
        public string transcode_audio_codec { get; set; }
        public int transcode_audio_channels { get; set; }
        public int transcode_width { get; set; }
        public int transcode_height { get; set; }
    }
}
