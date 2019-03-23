using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarkEmbling.Utilities.Extensions {
    public static class RangeExtensions {
        /// <summary>
        /// Convert a string containing ranges to a list of all the integers it defines
        /// </summary>
        /// <param name="str">Range string (e.g. "1-4,6,9,10-12")</param>
        /// <returns>All integers in the range</returns>
        public static IEnumerable<int> RangeStringToList(this string str) {
            var matches = Regex.Matches(str, @"(?<f>-?\d+)-(?<s>-?\d+)|(-?\d+)");
            var refs = new List<int>();

            foreach (var match in matches.OfType<Match>()) {
                if (match.Groups[1].Success) {
                    if (int.TryParse(match.Value, out int convertedRef))
                        refs.Add(convertedRef);
                    continue;
                }

                var start = Convert.ToInt32(match.Groups["f"].Value);
                var end = Convert.ToInt32(match.Groups["s"].Value) + 1;
                refs.AddRange(Enumerable.Range(start, end - start));
            }

            return refs;
        }

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

        /// <summary>
        /// Converts a collection of integers into a collection of range tuples
        /// 
        /// E.g. 1,3,5,6,7,8,9,10,12 becomes (1,1),(3,3),(5,10),(12,12).
        /// From https://stackoverflow.com/a/7689095/6844 by Corey Kosak.
        /// </summary>
        /// <param name="integers">Collection of integers</param>
        /// <returns>Collection of range tuples</returns>
        public static IEnumerable<Tuple<int, int>> ToRangeTuples(this IEnumerable<int> integers) {
            List<Tuple<int, int>> rangeTuples = new List<Tuple<int, int>>();
            Tuple<int, int> currentRange = null;
            foreach (var num in integers) {
                if (currentRange == null) {
                    currentRange = Tuple.Create(num, num);
                } else if (currentRange.Item2 == num - 1) {
                    currentRange = Tuple.Create(currentRange.Item1, num);
                } else {
                    yield return currentRange;
                    currentRange = Tuple.Create(num, num);
                }
            }
            if (currentRange != null) {
                yield return currentRange;
            }
        }
    }
}
