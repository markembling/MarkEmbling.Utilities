using MarkEmbling.Utils.Extensions;
using NUnit.Framework;

namespace MarkEmbling.Utils.Tests.Extensions {
    [TestFixture]
    public class DecimalExtensionsTests {
        [Test]
        public void ToInt_returns_integer_representation() {
            const decimal test = 5;
            Assert.AreEqual(5, test.ToInt(ToIntMethod.IgnoreFraction));
        }

        [Test]
        public void ToInt_with_IgnoreFraction_discards_fractional_component() {
            const decimal test = 5.879m;
            Assert.AreEqual(5, test.ToInt(ToIntMethod.IgnoreFraction));
        }

        [Test]
        public void ToInt_with_Round_rounds_number_up_as_expected() {
            const decimal test = 5.879m;
            Assert.AreEqual(6, test.ToInt(ToIntMethod.Round));
        }

        [Test]
        public void ToInt_with_Round_rounds_number_down_as_expected() {
            const decimal test = 5.378m;
            Assert.AreEqual(5, test.ToInt(ToIntMethod.Round));
        }
    }
}