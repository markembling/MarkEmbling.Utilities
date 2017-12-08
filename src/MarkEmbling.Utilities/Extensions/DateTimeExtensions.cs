using System;

namespace MarkEmbling.Utilities.Extensions {
    public static class DateTimeExtensions {
        private static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Gets the two digit version of the year from a DateTime instance
        /// </summary>
        /// <param name="dt">Current DateTime instance</param>
        /// <returns>Short year (e.g. 15 for 2015)</returns>
        public static int GetShortYear(this DateTime dt) {
            return Convert.ToInt32(dt.ToString("yy"));
        }

        /// <summary>
        /// Get the Unix timestamp (seconds since 1970-01-01 00:00:00) from a DateTime instance
        /// </summary>
        /// <param name="dt">Current DateTime instance</param>
        /// <returns>Seconds since Unix epoch</returns>
        public static long GetUnixTimeSeconds(this DateTime dt) {
            return Convert.ToInt64((dt.ToUniversalTime() - UNIX_EPOCH).TotalSeconds);
        }

        /// <summary>
        /// Get the Unix timestamp in milliseconds (total milliseconds since 1970-01-01 00:00:00) from a DateTime
        /// instance
        /// </summary>
        /// <param name="dt">Current DateTime instance</param>
        /// <returns>Milliseconds since Unix epoch</returns>
        public static long GetUnixTimeMilliseconds(this DateTime dt) {
            return Convert.ToInt64((dt.ToUniversalTime() - UNIX_EPOCH).TotalMilliseconds);
        }
    }
}