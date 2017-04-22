using MarkEmbling.Utilities.Extensions;
using Xunit;

namespace MarkEmbling.Utilities.Tests.Extensions {
    public class DoubleExtensionsTests {
        [Fact]
        public void ToInt_returns_integer_representation() {
            const double test = 5;
            Assert.Equal(5, test.ToInt(ToIntMethod.IgnoreFraction));
        }

        [Fact]
        public void ToInt_with_IgnoreFraction_discards_fractional_component() {
            const double test = 5.879;
            Assert.Equal(5, test.ToInt(ToIntMethod.IgnoreFraction));
        }

        [Fact]
        public void ToInt_with_Round_rounds_number_up_as_expected() {
            const double test = 5.879;
            Assert.Equal(6, test.ToInt(ToIntMethod.Round));
        }

        [Fact]
        public void ToInt_with_Round_rounds_number_down_as_expected() {
            const double test = 5.378;
            Assert.Equal(5, test.ToInt(ToIntMethod.Round));
        }

        [Fact]
        public void Equivalent_returns_true_when_difference_is_smaller_than_precision_value() {
            const double test = 1.3333334;
            Assert.True(test.Equivalent(1.3333333, 0.000001));
        }

        [Fact]
        public void Equivalent_returns_false_when_difference_is_larger_than_precision_value() {
            const double test = 1.3333334;
            Assert.True(test.Equivalent(1.3333335, 0.000001));
        }
    }
}