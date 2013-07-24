using System.Collections.Generic;
using MarkEmbling.Utils.Extensions.Grammar.Rules;

namespace MarkEmbling.Utils.Extensions.Grammar {
    public class GrammarTransformer {
        public IEnumerable<IGrammarTransformRule> Rules { get; private set; }

        public GrammarTransformer(IEnumerable<IGrammarTransformRule> rules) {
            Rules = rules;
        }
        
        public string Transform(string input) {
            foreach (var rule in Rules) {
                if (rule.CanTransform(input))
                    return rule.Transform(input);
            }

            throw new NoMatchingGrammarRuleException();
        }
    }
}