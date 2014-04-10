using System;
using System.Linq;
using NUnit.Framework;

namespace MarkEmbling.Utils.Tests {
    public class EnumHelpersTests {
        private enum TestEnum {
            One,
            Two
        }

        [Test]
        public void GetValuesList_returns_list_of_enum_values() {
            var result = EnumHelpers.GetValuesList<TestEnum>();
            Assert.AreEqual(result.Count(), 2);
            Assert.AreEqual(result.ElementAt(0), TestEnum.One);
            Assert.AreEqual(result.ElementAt(1), TestEnum.Two);
        }

        [Test]
        public void GetValuesList_throws_on_non_enum_type() {
            // Required due to the fact that it's currently impossible to set a type constraint
            // for enums.
            Assert.Throws<InvalidOperationException>(() => EnumHelpers.GetValuesList<string>());
        }
    }
}