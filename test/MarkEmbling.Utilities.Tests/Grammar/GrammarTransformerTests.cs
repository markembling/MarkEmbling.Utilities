using System.Collections.Generic;
using MarkEmbling.Utilities.Grammar;
using MarkEmbling.Utilities.Grammar.Rules;
using Xunit;

namespace MarkEmbling.Utilities.Tests.Grammar {
    public class GrammarTransformerTests {
        [Fact]
        public void Rules_are_persisted_in_transformer() {
            var rules = new List<IGrammarTransformRule>();
            var transformer = new GrammarTransformer(rules);
            Assert.Same(rules, transformer.Rules);
        }

        [Fact]
        public void Rules_are_used_to_transform_string() {
            var rules = new List<IGrammarTransformRule> {new TestRule()};
            var transformer = new GrammarTransformer(rules);
            var result = transformer.Transform("foo");

            Assert.Equal("bar", result);
        }

        [Fact]
        public void Throws_on_no_applicable_rule() {
            var rules = new List<IGrammarTransformRule>();
            var transformer = new GrammarTransformer(rules);
            Assert.Throws<NoMatchingGrammarRuleException>(
                () => transformer.Transform("foo"));
        }

        [Fact]
        public void Does_not_use_non_applicable_rule() {
            var rules = new List<IGrammarTransformRule> { new TestUselessRule() };
            var transformer = new GrammarTransformer(rules);
            Assert.Throws<NoMatchingGrammarRuleException>(
                () => transformer.Transform("foo"));
        }
    }
}