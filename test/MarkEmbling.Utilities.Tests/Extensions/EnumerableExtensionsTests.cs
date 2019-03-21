using MarkEmbling.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarkEmbling.Utilities.Tests.Extensions {
    public class EnumerableExtensionsTests {
        [Fact]
        public void ToRangeTuples_converts_contiguous_range_to_single_tuple() {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var result = numbers.ToRangeTuples();

            Assert.Equal(1, result.Count());
            Assert.Equal(Tuple.Create(1, 5), result.First());
        }

        [Fact]
        public void ToRangeTuples_converts_single_number_to_single_tuple() {
            var numbers = new List<int> { 1 };
            var result = numbers.ToRangeTuples();

            Assert.Equal(1, result.Count());
            Assert.Equal(Tuple.Create(1, 1), result.First());
        }

        [Fact]
        public void ToRangeTuples_converts_non_contiguous_sequence_to_multiple_single_tuples() {
            var numbers = new List<int> { 1, 3, 5 };
            var result = numbers.ToRangeTuples();

            Assert.Equal(3, result.Count());
            Assert.Equal(Tuple.Create(1, 1), result.ElementAt(0));
            Assert.Equal(Tuple.Create(3, 3), result.ElementAt(1));
            Assert.Equal(Tuple.Create(5, 5), result.ElementAt(2));
        }

        [Fact]
        public void ToRangeTuples_converts_empty_list_to_empty_tuple_list() {
            var numbers = new List<int>();
            var result = numbers.ToRangeTuples();
            Assert.False(result.Any());
        }
    }
}
