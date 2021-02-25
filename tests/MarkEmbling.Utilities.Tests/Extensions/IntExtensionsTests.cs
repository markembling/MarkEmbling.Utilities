using MarkEmbling.Utilities.Extensions;
using System.Collections.Generic;
using Xunit;

namespace MarkEmbling.Utilities.Tests.Extensions
{
    public class IntExtensionsTests
    {
        [Fact]
        public void GetOrdinalSuffix_handles_first_correctly()
        {
            Assert.Equal("st", 1.GetOrdinalSuffix());
        }

        [Fact]
        public void GetOrdinalSuffix_handles_second_correctly()
        {
            Assert.Equal("nd", 2.GetOrdinalSuffix());
        }

        [Fact]
        public void GetOrdinalSuffix_handles_third_correctly()
        {
            Assert.Equal("rd", 3.GetOrdinalSuffix());
        }

        [Fact]
        public void GetOrdinalSuffix_returns_th_for_all_single_digits_above_three()
        {
            const string expected = "th";
            Assert.Equal(expected, 4.GetOrdinalSuffix());
            Assert.Equal(expected, 5.GetOrdinalSuffix());
            Assert.Equal(expected, 6.GetOrdinalSuffix());
            Assert.Equal(expected, 7.GetOrdinalSuffix());
            Assert.Equal(expected, 8.GetOrdinalSuffix());
            Assert.Equal(expected, 9.GetOrdinalSuffix());
        }

        [Fact]
        public void GetOrdinalSuffix_returns_st_for_larger_numbers()
        {
            const string expected = "st";
            Assert.Equal(expected, 21.GetOrdinalSuffix());
            Assert.Equal(expected, 31.GetOrdinalSuffix());
            Assert.Equal(expected, 41.GetOrdinalSuffix());
            Assert.Equal(expected, 51.GetOrdinalSuffix());
            Assert.Equal(expected, 61.GetOrdinalSuffix());
            Assert.Equal(expected, 71.GetOrdinalSuffix());
            Assert.Equal(expected, 81.GetOrdinalSuffix());
            Assert.Equal(expected, 91.GetOrdinalSuffix());
            Assert.Equal(expected, 101.GetOrdinalSuffix());
            Assert.Equal(expected, 121.GetOrdinalSuffix());
            Assert.Equal(expected, 991.GetOrdinalSuffix());
        }

        [Fact]
        public void GetOrdinalSuffix_returns_nd_for_larger_numbers()
        {
            const string expected = "nd";
            Assert.Equal(expected, 22.GetOrdinalSuffix());
            Assert.Equal(expected, 32.GetOrdinalSuffix());
            Assert.Equal(expected, 42.GetOrdinalSuffix());
            Assert.Equal(expected, 52.GetOrdinalSuffix());
            Assert.Equal(expected, 62.GetOrdinalSuffix());
            Assert.Equal(expected, 72.GetOrdinalSuffix());
            Assert.Equal(expected, 82.GetOrdinalSuffix());
            Assert.Equal(expected, 92.GetOrdinalSuffix());
            Assert.Equal(expected, 102.GetOrdinalSuffix());
            Assert.Equal(expected, 122.GetOrdinalSuffix());
            Assert.Equal(expected, 992.GetOrdinalSuffix());
        }

        [Fact]
        public void ToOrdinal_returns_rd_suffix_correctly_for_larger_numbers()
        {
            const string expected = "rd";
            Assert.Equal(expected, 23.GetOrdinalSuffix());
            Assert.Equal(expected, 33.GetOrdinalSuffix());
            Assert.Equal(expected, 43.GetOrdinalSuffix());
            Assert.Equal(expected, 53.GetOrdinalSuffix());
            Assert.Equal(expected, 63.GetOrdinalSuffix());
            Assert.Equal(expected, 73.GetOrdinalSuffix());
            Assert.Equal(expected, 83.GetOrdinalSuffix());
            Assert.Equal(expected, 93.GetOrdinalSuffix());
            Assert.Equal(expected, 103.GetOrdinalSuffix());
            Assert.Equal(expected, 123.GetOrdinalSuffix());
            Assert.Equal(expected, 993.GetOrdinalSuffix());
        }

        [Fact]
        public void ToOrdinal_returns_th_for_all_teens()
        {
            const string expected = "th";
            Assert.Equal(expected, 10.GetOrdinalSuffix());
            Assert.Equal(expected, 11.GetOrdinalSuffix());
            Assert.Equal(expected, 12.GetOrdinalSuffix());
            Assert.Equal(expected, 13.GetOrdinalSuffix());
            Assert.Equal(expected, 14.GetOrdinalSuffix());
            Assert.Equal(expected, 15.GetOrdinalSuffix());
            Assert.Equal(expected, 16.GetOrdinalSuffix());
            Assert.Equal(expected, 17.GetOrdinalSuffix());
            Assert.Equal(expected, 18.GetOrdinalSuffix());
            Assert.Equal(expected, 19.GetOrdinalSuffix());
        }

        [Fact]
        public void ToOrdinal_returns_th_for_larger_numbers_ending_in_teens()
        {
            const string expected = "th";
            Assert.Equal(expected, 10010.GetOrdinalSuffix());
            Assert.Equal(expected, 10011.GetOrdinalSuffix());
            Assert.Equal(expected, 10012.GetOrdinalSuffix());
            Assert.Equal(expected, 10013.GetOrdinalSuffix());
            Assert.Equal(expected, 10014.GetOrdinalSuffix());
            Assert.Equal(expected, 10015.GetOrdinalSuffix());
            Assert.Equal(expected, 10016.GetOrdinalSuffix());
            Assert.Equal(expected, 10017.GetOrdinalSuffix());
            Assert.Equal(expected, 10018.GetOrdinalSuffix());
            Assert.Equal(expected, 10019.GetOrdinalSuffix());
        }

        [Fact]
        public void ToOrdinal_uses_whatever_ToString_provides_before_suffix()
        {
            var integerStr = 123456.ToString();
            var ordinalStr = 123456.ToOrdinal();
            var ordinalStrWithoutSuffix = ordinalStr.Substring(0, ordinalStr.Length - 2);
            Assert.Equal(integerStr, ordinalStrWithoutSuffix);
        }

        [Fact]
        public void ToOrdinal_uses_provided_format_string_for_number_before_suffix()
        {
            // The format used in this test is somewhat nonsensical
            var ordinalStr = 123456.ToOrdinal("00000000");
            var ordinalStrWithoutSuffix = ordinalStr.Substring(0, ordinalStr.Length - 2);
            Assert.Equal("00123456", ordinalStrWithoutSuffix);
        }

        [Fact]
        public void ToOrdinal_adds_suffix_when_using_format_string()
        {
            // The format used in this test is somewhat nonsensical
            Assert.Equal("00123456th", 123456.ToOrdinal("00000000"));
        }

        [Fact]
        public void ToOrdinal_uses_expected_suffixes()
        {
            var testCases = new Dictionary<int, string> {
                { 1, "st" },
                { 2, "nd" },
                { 3, "rd" },
                { 4, "th" },
                { 10, "th" },
                { 11, "th" },
                { 21, "st" },
                { 22, "nd" },
                { 23, "rd" },
                { 24, "th" }
            };

            foreach (var test in testCases)
            {
                var expected = test.Key.GetOrdinalSuffix();
                var ordinalStr = test.Key.ToOrdinal();
                var actual = ordinalStr.Last(2);
                Assert.Equal(expected, actual);
            }
        }
    }
}