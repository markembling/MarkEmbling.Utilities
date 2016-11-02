using MarkEmbling.Utils.Extensions;
using Xunit;

namespace MarkEmbling.Utils.Tests.Extensions {
    public class FloatExtensionsTests {
        [Fact]
        public void ToInt_returns_integer_representation() {
            const float test = 5;
            Assert.Equal(5, test.ToInt(ToIntMethod.IgnoreFraction));
        }

        [Fact]
        public void ToInt_with_IgnoreFraction_discards_fractional_component() {
            const float test = 5.879f;
            Assert.Equal(5, test.ToInt(ToIntMethod.IgnoreFraction));
        }

        [Fact]
        public void ToInt_with_Round_rounds_number_up_as_expected() {
            const float test = 5.879f;
            Assert.Equal(6, test.ToInt(ToIntMethod.Round));
        }

        [Fact]
        public void ToInt_with_Round_rounds_number_down_as_expected() {
            const float test = 5.378f;
            Assert.Equal(5, test.ToInt(ToIntMethod.Round));
        }

        [Fact]
        public void Equivalent_returns_true_when_difference_is_smaller_than_precision_value() {
            const float test = 1.33345f;
            Assert.True(test.Equivalent(1.33311f, 0.001f));
        }

        [Fact]
        public void Equivalent_returns_false_when_difference_is_larger_than_precision_value() {
            const float test = 1.33345f;
            Assert.False(test.Equivalent(1.33511f, 0.001f));
        }
    }
}