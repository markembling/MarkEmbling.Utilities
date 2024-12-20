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
        /// Determines whether a sequence contains no elements
        /// </summary>
        /// <typeparam name="T">The type of the collection elements</typeparam>
        /// <param name="source">The collection to check</param>
        /// <returns>Whether or not the collection contains no elements</returns>
        public static bool None<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        /// <summary>
        /// Determines whether a sequence contains no elements or is null
        /// </summary>
        /// <typeparam name="T">The type of the collection elements</typeparam>
        /// <param name="source">The collection to check</param>
        /// <returns>Whether or not the collection contains no elements or is null</returns>
        public static bool NoneOrNull<T>(this IEnumerable<T> source)
        {
            return source == null || None(source);
        }
    }
}
