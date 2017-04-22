using System;

namespace MarkEmbling.Utilities.Extensions {
    public static class DateTimeExtensions {
        /// <summary>
        /// Gets the two digit version of the year from a DateTime instance
        /// </summary>
        /// <param name="dt">Current DateTime instance</param>
        /// <returns>Short year (e.g. 15 for 2015)</returns>
        public static int GetShortYear(this DateTime dt) {
            return Convert.ToInt32(dt.ToString("yy"));
        }
    }
}