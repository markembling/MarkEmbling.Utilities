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

        [Test]
        public void Equivalent_returns_true_when_difference_is_smaller_than_precision_value() {
            const double test = 1.3333334;
            Assert.IsTrue(test.Equivalent(1.3333333, 0.000001));
        }

        [Test]
        public void Equivalent_returns_false_when_difference_is_larger_than_precision_value() {
            const double test = 1.3333334;
            Assert.IsTrue(test.Equivalent(1.3333335, 0.000001));
        }
    }
}