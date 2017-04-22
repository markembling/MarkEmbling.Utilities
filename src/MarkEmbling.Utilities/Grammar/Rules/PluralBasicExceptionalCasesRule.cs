using System.Collections.Generic;

namespace MarkEmbling.Utilities.Grammar.Rules {
    /// <summary>
    /// Basic naive rule which swaps specific singular words with their plural equivilent.
    /// </summary>
    public class PluralBasicExceptionalCasesRule : IGrammarTransformRule {
        private readonly IDictionary<string, string> _exceptions = new Dictionary<string, string> {
            {"goose", "geese"},
            {"louse", "lice"},
            {"mouse", "mice"},

            {"deer", "deer"},
            {"sheep", "sheep"}
        };

        public bool CanTransform(string input) {
            return _exceptions.ContainsKey(input.ToLowerInvariant());
        }

        public string Transform(string input) {
            return _exceptions[input.ToLowerInvariant()];
        }
    }
}