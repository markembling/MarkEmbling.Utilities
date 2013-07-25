using System.Collections.Generic;
using MarkEmbling.Utils.Grammar;
using MarkEmbling.Utils.Grammar.Rules;
using NUnit.Framework;

namespace MarkEmbling.Utils.Tests.Grammar {
    [TestFixture]
    public class GrammarTransformerTests {
        [Test]
        public void Rules_are_persisted_in_transformer() {
            var rules = new List<IGrammarTransformRule>();
            var transformer = new GrammarTransformer(rules);
            Assert.AreSame(rules, transformer.Rules);
        }

        [Test]
        public void Rules_are_used_to_transform_string() {
            var rules = new List<IGrammarTransformRule> {new TestRule()};
            var transformer = new GrammarTransformer(rules);
            var result = transformer.Transform("foo");

            Assert.AreEqual("bar", result);
        }

        [Test]
        public void Throws_on_no_applicable_rule() {
            var rules = new List<IGrammarTransformRule>();
            var transformer = new GrammarTransformer(rules);
            Assert.Throws<NoMatchingGrammarRuleException>(
                () => transformer.Transform("foo"));
        }

        [Test]
        public void Does_not_use_non_applicable_rule() {
            var rules = new List<IGrammarTransformRule> { new TestUselessRule() };
            var transformer = new GrammarTransformer(rules);
            Assert.Throws<NoMatchingGrammarRuleException>(
                () => transformer.Transform("foo"));
        }
    }
}