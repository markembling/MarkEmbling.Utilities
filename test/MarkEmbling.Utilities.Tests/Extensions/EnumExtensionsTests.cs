using MarkEmbling.Utilities.Extensions;
using Xunit;

namespace MarkEmbling.Utilities.Tests.Extensions {
    public class EnumExtensionsTests {
        private enum TestEnum {
            [System.ComponentModel.Description("Item one")]
            One,
            Two
        }
        
        [Fact]
        public void GetDescription_returns_description_attribute_value() {
            var result = TestEnum.One.GetDescription();
            Assert.Equal("Item one", result);
        }

        [Fact]
        public void GetDescription_returns_literal_string_value_when_no_description_attribute() {
            var result = TestEnum.Two.GetDescription();
            Assert.Equal("Two", result);
        }
    }
}