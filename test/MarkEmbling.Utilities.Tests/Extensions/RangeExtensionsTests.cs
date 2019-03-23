using MarkEmbling.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarkEmbling.Utilities.Tests.Extensions {
    public class RangeExtensionsTests {
        [Fact]
        public void RangeStringToTuples_converts_single_range_to_single_tuple() {
            var result = "1-10".RangeStringToTuples().ToArray();
            Assert.Equal(1, result.Length);
            Assert.Equal(Tuple.Create(1, 10), result[0]);
        }

        [Fact]
        public void RangeStringToTuples_converts_single_number_to_single_tuple() {
            var result = "1".RangeStringToTuples().ToArray();

            Assert.Equal(1, result.Length);
            Assert.Equal(Tuple.Create(1, 1), result[0]);
        }

        [Fact]
        public void RangeStringToTuples_converts_non_contiguous_comma_separated_numbers_to_separate_tuples() {
            var result = "1,5,10".RangeStringToTuples().ToArray();

            Assert.Equal(3, result.Length);
            Assert.Equal(Tuple.Create(1, 1), result[0]);
            Assert.Equal(Tuple.Create(5, 5), result[1]);
            Assert.Equal(Tuple.Create(10, 10), result[2]);
        }

        [Fact]
        public void RangeStringToTuples_converts_combination_of_ranges_and_numbers_list() {
            var result = "1,3,5,10-15".RangeStringToTuples().ToArray();

            Assert.Equal(4, result.Length);
            Assert.Equal(Tuple.Create(1, 1), result[0]);
            Assert.Equal(Tuple.Create(3, 3), result[1]);
            Assert.Equal(Tuple.Create(5, 5), result[2]);
            Assert.Equal(Tuple.Create(10, 15), result[3]);
        }

        [Fact]
        public void RangeStringToTuples_converts_contiguous_comma_separated_numbers_to_separate_tuples() {
            var result = "1,2,3".RangeStringToTuples().ToArray();

            Assert.Equal(3, result.Length);
            Assert.Equal(Tuple.Create(1, 1), result[0]);
            Assert.Equal(Tuple.Create(2, 2), result[1]);
            Assert.Equal(Tuple.Create(3, 3), result[2]);
        }







        [Fact]
        public void RangeStringToList_converts_single_range_to_list() {
            var result = "1-10".RangeStringToList();

            Assert.Equal(10, result.Count());
            Assert.Equal(1, result.First());
            Assert.Equal(10, result.Last());
        }

        [Fact]
        public void RangeStringToList_converts_comma_separated_numbers_to_list() {
            var result = "1,2,3".RangeStringToList();

            Assert.Equal(3, result.Count());
            Assert.Equal(1, result.First());
            Assert.Equal(3, result.Last());
        }

        [Fact]
        public void RangeStringToList_converts_multiple_ranges_to_list() {
            var result = "1-5,10-15".RangeStringToList();

            Assert.Equal(11, result.Count());
            Assert.Equal(1, result.First());
            Assert.Equal(15, result.Last());
        }

        [Fact]
        public void RangeStringToList_converts_combination_of_ranges_and_numbers_list() {
            var result = "1,3,5,10-15".RangeStringToList();

            Assert.Equal(9, result.Count());
            Assert.Equal(1, result.First());
            Assert.Equal(15, result.Last());
        }

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
