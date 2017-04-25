using System;
using MarkEmbling.Utilities.Extensions;
using Xunit;

namespace MarkEmbling.Utilities.Tests.Extensions {
    public class DateTimeExtensionsTests {
        [Fact]
        public void GetShortYear_returns_correct_integer_representation() {
            Assert.Equal(15, new DateTime(2015, 1, 1).GetShortYear());
        }
    }
}