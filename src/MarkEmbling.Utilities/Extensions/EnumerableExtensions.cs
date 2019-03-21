using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkEmbling.Utilities.Extensions {
    public static class EnumerableExtensions {
        /// <summary>
        /// Return a shuffled version of this collection
        /// 
        /// This method internally buffers source using ToList and thus will trigger
        /// any deferred linq execution. Based upon http://stackoverflow.com/questions/273313/randomize-a-listt/1262619#1262619
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="source">Current collection instance</param>
        /// <param name="rng">Random number generator</param>
        /// <returns>Collection containing the shuffled contents of source</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (rng == null) throw new ArgumentNullException(nameof(rng));
            
            var buffer = source.ToList();  // Buffer the entire collection so we can shuffle it. Breaks linq deferral though.
            int k = buffer.Count;
            while (k > 1) {
                k--;
                int k2 = rng.Next(k + 1);
                T temp = buffer[k2];
                buffer[k2] = buffer[k];
                buffer[k] = temp;
            }

            return buffer;
        }

        /// <summary>
        /// Return a shuffled version of this collection
        /// 
        /// This method internally buffers source using ToList and thus will trigger
        /// any deferred linq execution. It will create an instance of System.Random
        /// to handle the randomness of the shuffling; if you'd like to provide your
        /// own, use the overload which takes a System.Random.
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="source">Current collection instance</param>
        /// <returns>Collection containing the shuffled contents of source</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) {
            return source.Shuffle(new Random());
        }

        /// <summary>
        /// Converts a list of integers into a list of range tuples
        /// 
        /// E.g. 1,3,5,6,7,8,9,10,12 becomes (1,1),(3,3),(5,10),(12,12).
        /// From https://stackoverflow.com/a/7689095/6844 by Corey Kosak.
        /// </summary>
        /// <param name="numList">List of numbers to convert to ranges</param>
        /// <returns>List of range tuples</returns>
        public static IEnumerable<Tuple<int, int>> ToRangeTuples(this IEnumerable<int> numList) {
            List<Tuple<int, int>> rangeTuples = new List<Tuple<int, int>>();
            Tuple<int, int> currentRange = null;
            foreach (var num in numList) {
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
