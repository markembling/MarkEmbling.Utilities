using MarkEmbling.Utilities.Extensions;
using System;
using Xunit;

namespace MarkEmbling.Utilities.Tests.Extensions {
    public class TupleExtensionsTests {
        [Fact]
        public void ToRangeString_converts_single_number_range_to_single_number_string() {
            var range = Tuple.Create(1, 1);
            var result = range.ToRangeString();
            Assert.Equal("1", result);
        }

        [Fact]
        public void ToRangeString_converts_larger_spanning_range_to_range_string() {
            var range = Tuple.Create(1, 100);
            var result = range.ToRangeString();
            Assert.Equal("1-100", result);
        }
    }
}
