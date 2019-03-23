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
        public void RangeStringToTuples_creates_intersecting_ranges_when_string_defines_intersections() {
            var result = "1-10,5,5-15".RangeStringToTuples().ToArray();

            Assert.Equal(3, result.Length);
            Assert.Equal(Tuple.Create(1, 10), result[0]);
            Assert.Equal(Tuple.Create(5, 5), result[1]);
            Assert.Equal(Tuple.Create(5, 15), result[2]);
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







        [Fact]
        public void RangeTupleToString_converts_single_number_range_to_single_number_string() {
            var range = Tuple.Create(1, 1);
            var result = range.RangeTupleToString();
            Assert.Equal("1", result);
        }

        [Fact]
        public void RangeTupleToString_converts_larger_spanning_range_to_range_string() {
            var range = Tuple.Create(1, 100);
            var result = range.RangeTupleToString();
            Assert.Equal("1-100", result);
        }


        [Fact]
        public void RangeTuplesToString_matches_RangeTupleToString_for_single_range_lists() {
            var testRangeArrays = new[] {
                new List<Tuple<int, int>> { Tuple.Create(1, 1) },
                new List<Tuple<int, int>> { Tuple.Create(1, 5) }
            };

            foreach (var testArray in testRangeArrays) {
                var expected = testArray[0].RangeTupleToString();
                var actual = testArray.RangeTuplesToString();
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void RangeTuplesToString_joins_single_numbers_with_comma() {
            var ranges = new List<Tuple<int, int>> {
                Tuple.Create(1, 1),
                Tuple.Create(2, 2),
                Tuple.Create(3, 3)
            };
            var result = ranges.RangeTuplesToString();
            Assert.Equal("1,2,3", result);
        }

        [Fact]
        public void RangeTuplesToString_joins_ranges_with_commas() {
            var ranges = new List<Tuple<int, int>> {
                Tuple.Create(1, 5),
                Tuple.Create(10, 15),
                Tuple.Create(20, 25)
            };
            var result = ranges.RangeTuplesToString();
            Assert.Equal("1-5,10-15,20-25", result);
        }

        [Fact]
        public void RangeTuplesToString_handles_combination_correctly() {
            var ranges = new List<Tuple<int, int>> {
                Tuple.Create(1, 1),
                Tuple.Create(3, 3),
                Tuple.Create(5, 5),
                Tuple.Create(10, 15)
            };
            var result = ranges.RangeTuplesToString();
            Assert.Equal("1,3,5,10-15", result);
        }

        [Fact]
        public void RangeTupleToInts_converts_single_number_range() {
            var range = Tuple.Create(1, 1);
            var result = range.RangeTupleToInts().ToArray();
            Assert.Equal(1, result.Length);
            Assert.Equal(new[] { 1 }, result);
        }

        [Fact]
        public void RangeTupleToInts_converts_multi_number_range() {
            var range = Tuple.Create(1, 10);
            var result = range.RangeTupleToInts().ToArray();
            Assert.Equal(10, result.Length);
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, result);
        }

        [Fact]
        public void RangeTuplesToInts_output_matches_RangeTupleToInts_for_single_range_lists() {
            var testRangeArrays = new[] {
                new List<Tuple<int, int>> { Tuple.Create(1, 1) },
                new List<Tuple<int, int>> { Tuple.Create(1, 5) }
            };

            foreach (var testArray in testRangeArrays) {
                var expected = testArray[0].RangeTupleToInts();
                var actual = testArray.RangeTuplesToInts();
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void RangeTuplesToInts_handles_multiple_ranges_correctly() {
            var ranges = new List<Tuple<int, int>> {
                Tuple.Create(1, 1),
                Tuple.Create(3, 3),
                Tuple.Create(5, 5),
                Tuple.Create(10, 15)
            };
            var result = ranges.RangeTuplesToInts().ToArray();
            Assert.Equal(9, result.Length);
            Assert.Equal(new[] { 1, 3, 5, 10, 11, 12, 13, 14, 15 }, result);
        }

        [Fact]
        public void RangeTuplesToInts_duplicates_numbers_when_the_ranges_intersect() {
            var ranges = new List<Tuple<int, int>> {
                Tuple.Create(1, 10),
                Tuple.Create(5, 15)
            };
            var result = ranges.RangeTuplesToInts().ToArray();
            Assert.Equal(21, result.Length);
            Assert.Equal(
                new[] {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 
                result);
        }
    }
}
