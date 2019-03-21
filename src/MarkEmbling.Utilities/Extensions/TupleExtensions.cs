using System;

namespace MarkEmbling.Utilities.Extensions {
    public static class TupleExtensions {
        /// <summary>
        /// Formats a range tuple to be a friendly string representation of the range.
        /// 
        /// E.g. (1,1) becomes "1" and (1,3) becomes "1-3".
        /// From https://stackoverflow.com/a/7689095/6844 by Corey Kosak.
        /// </summary>
        /// <param name="range">The range tuple</param>
        /// <returns>String representation of range</returns>
        public static string ToRangeString(this Tuple<int, int> range) {
            return range.Item1 == range.Item2
                ? range.Item1.ToString()
                : string.Format("{0}-{1}", range.Item1, range.Item2);
        }
    }
}
