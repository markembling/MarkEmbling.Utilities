using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarkEmbling.Utilities.Extensions {
    public static class RangeExtensions {
        /// <summary>
        /// Convert a string containing ranges to a collection of range tuples.
        /// </summary>
        /// <param name="str">Range string (e.g. "1-4,6,9,10-12")</param>
        /// <returns>Range tuples</returns>
        public static IEnumerable<Tuple<int, int>> RangeStringToTuples(this string str) {
            var matches = Regex.Matches(str, @"(?<f>-?\d+)-(?<s>-?\d+)|(-?\d+)");
            foreach (var match in matches.OfType<Match>()) {
                if (match.Groups[1].Success) {
                    if (int.TryParse(match.Value, out int convertedRef))
                        yield return Tuple.Create(convertedRef, convertedRef);
                    continue;
                }

                var start = Convert.ToInt32(match.Groups["f"].Value);
                var end = Convert.ToInt32(match.Groups["s"].Value);
                yield return Tuple.Create(start, end);
            }
        }

        /// <summary>
        /// Converts a collection of integers into a collection of range tuples.
        /// 
        /// E.g. 1,3,5,6,7,8,9,10,12 becomes (1,1),(3,3),(5,10),(12,12).
        /// From https://stackoverflow.com/a/7689095/6844 by Corey Kosak.
        /// </summary>
        /// <param name="integers">Collection of integers</param>
        /// <returns>Range tuples</returns>
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

        /// <summary>
        /// Normalise a collection of range tuples to ensure the most succinct representation is used.
        /// 
        /// E.g. [(1,1),(2,2),(3,3),(10,15)] will be converted to [(1,3),(10,15)].
        /// </summary>
        /// <param name="ranges">Range tuples</param>
        /// <returns>Normalised range tuples</returns>
        public static IEnumerable<Tuple<int, int>> NormaliseRanges(this IEnumerable<Tuple<int, int>> ranges) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a friendly string representation of a range tuple.
        /// 
        /// E.g. (1,1) becomes "1" and (1,3) becomes "1-3".
        /// From https://stackoverflow.com/a/7689095/6844 by Corey Kosak.
        /// </summary>
        /// <param name="range">Range tuple</param>
        /// <returns>String representation of range</returns>
        public static string RangeTupleToString(this Tuple<int, int> range) {
            return range.Item1 == range.Item2
                ? range.Item1.ToString()
                : string.Format("{0}-{1}", range.Item1, range.Item2);
        }

        /// <summary>
        /// Return a string representation of a collection of range tuples.
        /// </summary>
        /// <param name="ranges">Range tuples</param>
        /// <returns>String representation of ranges</returns>
        public static string RangeTuplesToString(this IEnumerable<Tuple<int, int>> ranges) {
            return string.Join(",", ranges.Select(x => x.RangeTupleToString()));
        }

        /// <summary>
        /// Returns a list of integers defined by the given range tuple.
        /// </summary>
        /// <param name="range">Range tuple</param>
        /// <returns>Collection of integers</returns>
        public static IEnumerable<int> RangeTupleToInts(this Tuple<int, int> range) {
            if (range.Item1 == range.Item2) {
                yield return range.Item1;
            } else {
                var size = (range.Item2 - range.Item1) + 1;
                var integers = Enumerable.Range(range.Item1, size);
                foreach (var integer in integers) {
                    yield return integer;
                }
            }
        }

        /// <summary>
        /// Converts a collection of range tuples into a collection of integers contained in the ranges.
        /// </summary>
        /// <param name="tuples">Collection of range tuples</param>
        /// <returns>Collection of integers</returns>
        public static IEnumerable<int> RangeTuplesToInts(this IEnumerable<Tuple<int, int>> ranges) {
            return ranges.SelectMany(x => x.RangeTupleToInts());
        }
    }
}
