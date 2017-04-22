using System.Collections.Generic;

namespace MarkEmbling.Utilities.Grammar.Rules {
    /// <summary>
    /// Default rule sets for various operations (English language)
    /// </summary>
    public static class DefaultRuleSets {
        /// <summary>
        /// Rule set for producing a possessive form of a word/name.
        /// </summary>
        public static IEnumerable<IGrammarTransformRule> Possessive = new List<IGrammarTransformRule> {
            new PossessiveBasicExceptionalCasesRule(),
            new PossessiveApostropheRule(),
            new PossessiveApostropheSRule()
        };

        /// <summary>
        /// Rule set for converting a singular word to a plural form.
        /// </summary>
        public static IEnumerable<IGrammarTransformRule> Plural = new List<IGrammarTransformRule> {
            new PluralBasicExceptionalCasesRule(),
            new PluralIaRule(),
            new PluralIRule(),
            new PluralEsRule(),
            new PluralSRule()
        }; 
    }
}