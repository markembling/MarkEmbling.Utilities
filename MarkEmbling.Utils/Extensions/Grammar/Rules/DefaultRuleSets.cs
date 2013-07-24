using System.Collections.Generic;

namespace MarkEmbling.Utils.Extensions.Grammar.Rules {
    /// <summary>
    /// Default rule sets for various operations (English language)
    /// </summary>
    public static class DefaultRuleSets {
        /// <summary>
        /// Rule set for producing a possessive form of a word/name.
        /// </summary>
        public static IEnumerable<IGrammarTransformRule> Possessive = new List<IGrammarTransformRule> {
            new DefaultExceptionalCasePossessiveRule(),
            new AddApostrophePossessiveRule(),
            new AddApostropheSPossessiveRule()
        };
    }
}