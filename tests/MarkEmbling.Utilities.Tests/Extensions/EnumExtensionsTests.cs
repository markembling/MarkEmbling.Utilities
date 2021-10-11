using MarkEmbling.Utilities.Extensions;
using System;
using Xunit;

namespace MarkEmbling.Utilities.Tests.Extensions {
    public class EnumExtensionsTests {
        private enum TestEnum {
            [System.ComponentModel.Description("Item one")]
            [System.ComponentModel.DataAnnotations.Display(Name = "Artikel eins", Description = "First item in the enum")]
            One,

            Two,

            [System.ComponentModel.DataAnnotations.Display()]
            Three
        }

        [Fact]
        public void GetDisplayName_returns_display_attribute_name_value()
        {
            var result = TestEnum.One.GetDisplayName();
            Assert.Equal("Artikel eins", result);
        }

        [Fact]
        public void GetDisplayDescription_returns_null_if_display_attribute_name_value_is_not_set()
        {
            var result = TestEnum.Three.GetDisplayName();
            Assert.Null(result);
        }

        [Fact]
        public void GetDisplayName_returns_literal_string_value_when_no_display_attribute()
        {
            var result = TestEnum.Two.GetDisplayName();
            Assert.Equal("Two", result);
        }

        [Fact]
        public void GetDisplayDescription_returns_display_attribute_description_value()
        {
            var result = TestEnum.One.GetDisplayDescription();
            Assert.Equal("First item in the enum", result);
        }

        [Fact]
        public void GetDisplayDescription_returns_null_if_display_attribute_description_value_is_not_set()
        {
            var result = TestEnum.Three.GetDisplayDescription();
            Assert.Null( result);
        }

        [Fact]
        public void GetDisplayDescription_returns_literal_string_value_when_no_display_attribute()
        {
            var result = TestEnum.Two.GetDisplayDescription();
            Assert.Equal("Two", result);
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

        [Fact]
        public void GetNumericValue_gets_underlying_numeric_value() {
            var result = TestEnum.One.GetNumericValue();
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetNumericValue_gets_correct_underlying_type() {
            var result = TestEnum.One.GetNumericValue();
            Assert.IsType<int>(result);
        }

        [Fact]
        public void GetNumericValueGeneric_gets_underlying_numeric_value() {
            var result = TestEnum.One.GetNumericValue<int>();
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetNumericValueGeneric_throws_appropriate_exception_if_types_mismatch() {
            var exception = Assert.Throws<InvalidOperationException>(
               () => TestEnum.One.GetNumericValue<long>());
            Assert.Equal(
                "TestEnum has the underlying type of Int32 instead of Int64", 
                exception.Message);
        }
    }
}