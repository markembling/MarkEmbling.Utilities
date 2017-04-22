using System.Collections.Generic;

namespace MarkEmbling.Utilities.Grammar.Rules {
    /// <summary>
    /// Basic naive rule which swaps specific singular words with their possessive equivilent.
    /// </summary>
    public class PossessiveBasicExceptionalCasesRule : IGrammarTransformRule {
        private readonly IDictionary<string, string> _exceptions = new Dictionary<string, string> {
            {"him", "his"},
            {"her", "hers"}
        };

        public bool CanTransform(string input) {
            return _exceptions.ContainsKey(input.ToLowerInvariant());
        }

        public string Transform(string input) {
            return _exceptions[input.ToLowerInvariant()];
        }
    }
}