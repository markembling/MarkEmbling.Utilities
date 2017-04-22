using MarkEmbling.Utilities.Extensions;
using Xunit;

namespace MarkEmbling.Utilities.Tests.Extensions {
    public class DecimalExtensionsTests {
        [Fact]
        public void ToInt_returns_integer_representation() {
            const decimal test = 5;
            Assert.Equal(5, test.ToInt(ToIntMethod.IgnoreFraction));
        }

        [Fact]
        public void ToInt_with_IgnoreFraction_discards_fractional_component() {
            const decimal test = 5.879m;
            Assert.Equal(5, test.ToInt(ToIntMethod.IgnoreFraction));
        }

        [Fact]
        public void ToInt_with_Round_rounds_number_up_as_expected() {
            const decimal test = 5.879m;
            Assert.Equal(6, test.ToInt(ToIntMethod.Round));
        }

        [Fact]
        public void ToInt_with_Round_rounds_number_down_as_expected() {
            const decimal test = 5.378m;
            Assert.Equal(5, test.ToInt(ToIntMethod.Round));
        }
    }
}