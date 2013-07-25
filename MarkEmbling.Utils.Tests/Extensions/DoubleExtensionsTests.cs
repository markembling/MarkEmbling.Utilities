using MarkEmbling.Utils.Extensions;
using NUnit.Framework;

namespace MarkEmbling.Utils.Tests.Extensions {
    [TestFixture]
    public class DoubleExtensionsTests {
        [Test]
        public void ToInt_returns_integer_representation() {
            const double test = 5;
            Assert.AreEqual(5, test.ToInt(ToIntMethod.IgnoreFraction));
        }

        [Test]
        public void ToInt_with_IgnoreFraction_discards_fractional_component() {
            const double test = 5.879;
            Assert.AreEqual(5, test.ToInt(ToIntMethod.IgnoreFraction));
        }

        [Test]
        public void ToInt_with_Round_rounds_number_up_as_expected() {
            const double test = 5.879;
            Assert.AreEqual(6, test.ToInt(ToIntMethod.Round));
        }

        [Test]
        public void ToInt_with_Round_rounds_number_down_as_expected() {
            const double test = 5.378;
            Assert.AreEqual(5, test.ToInt(ToIntMethod.Round));
        }
    }
}