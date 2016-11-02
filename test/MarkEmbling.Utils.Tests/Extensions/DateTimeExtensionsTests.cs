using System;
using MarkEmbling.Utils.Extensions;
using Xunit;

namespace MarkEmbling.Utils.Tests.Extensions {
    public class DateTimeExtensionsTests {
        [Fact]
        public void GetShortDate_returns_correct_integer_representation() {
            Assert.Equal(15, new DateTime(2015, 1, 1).GetShortYear());
        }
    }
}