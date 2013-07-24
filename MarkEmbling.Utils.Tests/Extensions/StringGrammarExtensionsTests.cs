using System.Collections.Generic;
using MarkEmbling.Utils.Extensions;
using MarkEmbling.Utils.Extensions.Grammar;
using MarkEmbling.Utils.Extensions.Grammar.Rules;
using NUnit.Framework;

namespace MarkEmbling.Utils.Tests.Extensions {
    [TestFixture]
    public class StringGrammarExtensionsTests {
        [Test]
        public void Pluralise_should_add_S_on_multiple() {
            const string singular = "Item";
            var result = singular.Pluralise(2);
            Assert.AreEqual("Items", result);
        }

        [Test]
        public void Pluralize_should_not_add_S_on_single() {
            const string singular = "Item";
            var result = singular.Pluralise(1);
            Assert.AreEqual("Item", result);
        }

        [Test]
        public void Pluralise_should_add_S_on_zero() {
            const string singular = "Item";
            var result = singular.Pluralise(0);
            Assert.AreEqual("Items", result);
        }

        [Test]
        public void Pluralise_should_return_plural_form_on_multiple() {
            const string singular = "Cactus";
            var result = singular.Pluralise(2, "Cacti");
            Assert.AreEqual("Cacti", result);
        }

        [Test]
        public void Pluralize_should_not_return_plural_form_on_single() {
            const string singular = "Cactus";
            var result = singular.Pluralise(1, "Cacti");
            Assert.AreEqual("Cactus", result);
        }

        [Test]
        public void Pluralise_should_return_plural_form_on_zero() {
            const string singular = "Cactus";
            var result = singular.Pluralise(0, "Cacti");
            Assert.AreEqual("Cacti", result);
        }

        [Test]
        public void Possessive_uses_default_rule_set() {
            const string name1 = "John";
            const string name2 = "James";

            var result1 = name1.Possessive();
            var result2 = name2.Possessive();

            Assert.AreEqual("John's", result1);
            Assert.AreEqual("James'", result2);
        }

        [Test]
        public void Possessive_uses_custom_rule_set() {
            const string test = "Test1";

            var customRules = new List<IGrammarTransformRule> {
                new TestPossessionTransformRule()
            };

            var result = test.Possessive(customRules);

            Assert.AreEqual("TESTING", result);
        }

        class TestPossessionTransformRule : IGrammarTransformRule {
            public bool CanTransform(string input) {
                return true;
            }

            public string Transform(string input) {
                return "TESTING";
            }
        }
    }
}