using System;
using MarkEmbling.Utils.Extensions;
using NUnit.Framework;

namespace MarkEmbling.Utils.Tests.Extensions {
    [TestFixture]
    public class DateTimeExtensionsTests {
        [Test]
        public void GetShortDate_returns_correct_integer_representation() {
            Assert.AreEqual(15, new DateTime(2015, 1, 1).GetShortYear());
        }
    }
}