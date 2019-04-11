using System;
using System.Linq;
using Xunit;

namespace MarkEmbling.Utilities.Tests {
    public class EnumHelperTests {
        private enum TestEnum {
            One,
            Two
        }

        [Fact]
        public void GetValuesList_returns_list_of_enum_values() {
            var result = EnumHelper.GetValuesList<TestEnum>();
            Assert.Equal(result.Count(), 2);
            Assert.Equal(result.ElementAt(0), TestEnum.One);
            Assert.Equal(result.ElementAt(1), TestEnum.Two);
        }

        [Fact]
        public void GetValuesList_throws_on_non_enum_type() {
            // Required due to the fact that it's currently impossible to set a type constraint
            // for enums.
            Assert.Throws<InvalidOperationException>(() => EnumHelper.GetValuesList<string>());
        }
    }
}