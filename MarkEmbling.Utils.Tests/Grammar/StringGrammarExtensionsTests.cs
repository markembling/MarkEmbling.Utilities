using System.Collections.Generic;
using MarkEmbling.Utils.Extensions;
using MarkEmbling.Utils.Grammar.Rules;
using NUnit.Framework;

namespace MarkEmbling.Utils.Tests.Grammar {
    [TestFixture]
    public class StringGrammarExtensionsTests {
        [Test]
        public void PerformGrammarTransformation_transforms_with_given_rules() {
            const string input = "foo";
            var rules = new List<IGrammarTransformRule> {new TestRule()};
            var result = input.PerformGrammarTransformation(rules);
            Assert.AreEqual("bar", result);
        }

        [Test]
        public void ToPlural_returns_plural_form_when_multiple() {
            const string singular = "item";
            var result = singular.ToPlural(2);
            Assert.AreEqual("items", result);
        }

        [Test]
        public void ToPlural_returns_plural_form_when_zero() {
            const string singular = "item";
            var result = singular.ToPlural(0);
            Assert.AreEqual("items", result);
        }

        [Test]
        public void ToPlural_returns_single_form_when_1() {
            const string singular = "item";
            var result = singular.ToPlural(1);
            Assert.AreEqual("item", result);
        }

        [Test]
        public void ToPlural_returns_given_plural_form_when_multiple() {
            const string singular = "foo";
            var result = singular.ToPlural(2, "bar");
            Assert.AreEqual("bar", result);
        }

        [Test]
        public void ToPlural_returns_single_form_when_single_and_plural_given() {
            const string singular = "foo";
            var result = singular.ToPlural(1, "bar");
            Assert.AreEqual("foo", result);
        }

        [Test]
        public void ToPossessive_returns_possessive_form() {
            const string singular = "John";
            var result = singular.ToPossessive();
            Assert.AreEqual("John's", result);
        }
    }
}