using System;

namespace PlexInfo.Services
{
    public interface IUtilities
    {
        DateTime UnixTimestampToDateTime(double unixTime);
        double DateTimeToUnixTimestamp(DateTime dateTime);
    }


    public class Utilities : IUtilities
    {
        public DateTime UnixTimestampToDateTime(double unixTime)
        {
            var unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            var unixTimeStampInTicks = (long)(unixTime * TimeSpan.TicksPerSecond);
            return new DateTime(unixStart.Ticks + unixTimeStampInTicks, System.DateTimeKind.Utc);
        }

        public double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            var unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            var unixTimeStampInTicks = (dateTime.ToUniversalTime() - unixStart).Ticks;
            return (double)unixTimeStampInTicks / TimeSpan.TicksPerSecond;
        }
    }
}
