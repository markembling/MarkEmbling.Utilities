using System.Linq;
using MarkEmbling.Utils.Extensions;
using NUnit.Framework;

namespace MarkEmbling.Utils.Tests.Extensions {
    [TestFixture]
    public class EnumExtensionsTests {
        enum TestEnum {
            [System.ComponentModel.Description("Item one")]
            One,
            Two
        }
        
        [Test]
        public void GetDescription_returns_description_attribute_value() {
            var result = TestEnum.One.GetDescription();
            Assert.AreEqual("Item one", result);
        }

        [Test]
        public void GetDescription_returns_literal_string_value_when_no_description_attribute() {
            var result = TestEnum.Two.GetDescription();
            Assert.AreEqual("Two", result);
        }
    }
}