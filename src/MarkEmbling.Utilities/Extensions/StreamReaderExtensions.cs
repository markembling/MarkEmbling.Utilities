using System.Collections.Generic;
using System.IO;

namespace MarkEmbling.Utilities.Extensions {
    public static class StreamReaderExtensions {
        /// <summary>
        /// Reads all available lines from the current stream
        /// </summary>
        /// <param name="reader">Current StreamReader instance</param>
        /// <returns>All lines read from the stream</returns>
        public static IEnumerable<string> ReadAllLines(this StreamReader reader) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                yield return line;
            }
        }
    }
}