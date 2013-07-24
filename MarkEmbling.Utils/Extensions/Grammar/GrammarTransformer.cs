using System.Collections.Generic;
using MarkEmbling.Utils.Extensions.Grammar.Rules;

namespace MarkEmbling.Utils.Extensions.Grammar {
    /// <summary>
    /// Class which can apply a set of grammar transform rules on input strings
    /// </summary>
    public class GrammarTransformer {
        /// <summary>
        /// Grammar transform rules for this transformer
        /// </summary>
        public IEnumerable<IGrammarTransformRule> Rules { get; private set; }

        /// <summary>
        /// Create a new GrammarTransformer with the given rule set
        /// </summary>
        /// <param name="rules">Set of grammar transform rules</param>
        public GrammarTransformer(IEnumerable<IGrammarTransformRule> rules) {
            Rules = rules;
        }
        
        /// <summary>
        /// Perform a transformation on a given input string
        /// </summary>
        /// <param name="input">String to transform</param>
        /// <returns>Transformed version of the string</returns>
        public string Transform(string input) {
            foreach (var rule in Rules) {
                if (rule.CanTransform(input))
                    return rule.Transform(input);
            }

            throw new NoMatchingGrammarRuleException();
        }
    }
}