using Microsoft.EntityFrameworkCore;
using PlexInfo.Models;

namespace PlexInfo
{
    public class PlexInfoContext : DbContext
    {
        public DbSet<LibrarySections> library_sections { get; set; }
        public DbSet<SessionHistory> session_history { get; set; }
        public DbSet<SessionHistoryMediaInfo> session_history_media_info { get; set; }
        public DbSet<SessionHistoryMetadata> session_history_metadata { get; set; }
        public DbSet<Users> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=plexpy.db");
        }
    }
}
