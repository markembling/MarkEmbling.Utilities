using MarkEmbling.Utilities.Extensions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarkEmbling.Utilities.Tests.Extensions
{
    public class EnumerableExtensionsTests
    {
        [Fact]
        public void None_returns_true_for_empty_collection()
        {
            var collection = Enumerable.Empty<int>();
            Assert.True(collection.None());
        }

        [Fact]
        public void None_returns_false_for_non_empty_collection()
        {
            var collection = new[] { 1, 2, 3 };
            Assert.False(collection.None());
        }

        [Fact]
        public void NoneOrNull_returns_true_for_empty_collection()
        {
            var collection = Enumerable.Empty<int>();
            Assert.True(collection.NoneOrNull());
        }

        [Fact]
        public void NoneOrNull_returns_true_for_null_collection()
        {
            IEnumerable<int> collection = null;
            Assert.True(collection.NoneOrNull());
        }

        [Fact]
        public void NoneOrNull_returns_false_for_non_empty_collection()
        {
            var collection = new[] { 1, 2, 3 };
            Assert.False(collection.NoneOrNull());
        }
    }
}
