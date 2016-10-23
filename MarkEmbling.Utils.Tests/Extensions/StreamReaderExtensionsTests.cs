using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MarkEmbling.Utils.Extensions;
using NUnit.Framework;

namespace MarkEmbling.Utils.Tests.Extensions {
    [TestFixture]
    public class StreamReaderExtensionsTests {
        [Test]
        public void ReadAllLines_returns_all_lines_in_stream() {
            using (var stream = StreamWithLines())
            using (var reader = new StreamReader(stream)) {
                var lines = reader.ReadAllLines().ToArray();

                Assert.AreEqual(4, lines.Length);
                Assert.AreEqual("Line 1", lines[0]);
                Assert.AreEqual("Line 2", lines[1]);
                Assert.AreEqual("Line 3", lines[2]);
                Assert.AreEqual("Line 4", lines[3]);
            }
        }

        /// <summary>
        /// Create a stream with some test lines inside
        /// </summary>
        private static Stream StreamWithLines() {
            var stream = new MemoryStream();

            var writer = new StreamWriter(stream);
            writer.WriteLine("Line 1");
            writer.WriteLine("Line 2");
            writer.WriteLine("Line 3");
            writer.WriteLine("Line 4");
            writer.Flush();

            stream.Position = 0;
            return stream;
        }
    }
}