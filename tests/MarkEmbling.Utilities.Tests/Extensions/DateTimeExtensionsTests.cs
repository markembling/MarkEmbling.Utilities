using System;
using MarkEmbling.Utilities.Extensions;
using Xunit;

namespace MarkEmbling.Utilities.Tests.Extensions {
    public class DateTimeExtensionsTests {
        [Fact]
        public void GetShortYear_returns_correct_integer_representation() {
            Assert.Equal(15, new DateTime(2015, 1, 1).GetShortYear());
        }

        [Fact]
        public void GetUnixTimeSeconds_returns_correct_value_for_epoch_date() {
            Assert.Equal(0, new DateTime(1970, 1, 1).GetUnixTimeSeconds());
        }

        [Fact]
        public void GetUnixTimeSeconds_returns_correct_value_for_before_epoch_date() {
            Assert.Equal(-86400, new DateTime(1969, 12, 31).GetUnixTimeSeconds());
        }

        [Fact]
        public void GetUnixTimeSeconds_returns_correct_value_for_after_epoch_date() {
            Assert.Equal(86400, new DateTime(1970, 1, 2).GetUnixTimeSeconds());
        }

        [Fact]
        public void GetUnixTimeMilliseconds_returns_correct_value_for_epoch_date() {
            Assert.Equal(0, new DateTime(1970, 1, 1).GetUnixTimeMilliseconds());
        }

        [Fact]
        public void GetUnixTimeMilliseconds_returns_correct_value_for_before_epoch_date() {
            Assert.Equal(-86400000, new DateTime(1969, 12, 31).GetUnixTimeMilliseconds());
        }

        [Fact]
        public void GetUnixTimeMilliseconds_returns_correct_value_for_after_epoch_date() {
            Assert.Equal(86400000, new DateTime(1970, 1, 2).GetUnixTimeMilliseconds());
        }
    }
}