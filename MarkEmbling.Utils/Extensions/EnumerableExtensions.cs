﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkEmbling.Utils.Extensions {
    public static class EnumerableExtensions {
        /// <summary>
        /// Return a shuffled version of an IEnumerable collection
        /// 
        /// This method internally buffers source using ToList and thus will trigger
        /// any deferred linq execution. Based upon http://stackoverflow.com/questions/273313/randomize-a-listt/1262619#1262619
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="source">Source collection</param>
        /// <param name="rng">Random number generator</param>
        /// <returns>Collection containing the shuffled contents of source</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng) {
            if (source == null) throw new ArgumentNullException("source");
            if (rng == null) throw new ArgumentNullException("rng");
            
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
        /// Return a shuffled version of an IEnumerable collection
        /// 
        /// This method internally buffers source using ToList and thus will trigger
        /// any deferred linq execution. It will create an instance of System.Random
        /// to handle the randomness of the shuffling; if you'd like to provide your
        /// own, use the overload which takes a System.Random.
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="source">Source collection</param>
        /// <returns>Collection containing the shuffled contents of source</returns>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) {
            return source.Shuffle(new Random());
        }
    }
}
