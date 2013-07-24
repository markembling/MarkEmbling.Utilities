using System.Collections.Generic;

namespace MarkEmbling.Utils.Extensions.Grammar.Rules {
    public static class DefaultRuleSets {
        public static IEnumerable<IGrammarTransformRule> Possessive = new List<IGrammarTransformRule> {
            new DefaultExceptionalCasePossessiveRule(),
            new AddApostrophePossessiveRule(),
            new AddApostropheSPossessiveRule()
        };
    }
}