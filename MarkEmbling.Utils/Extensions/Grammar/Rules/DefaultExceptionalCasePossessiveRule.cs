using System.Collections.Generic;

namespace MarkEmbling.Utils.Extensions.Grammar.Rules {
    public class DefaultExceptionalCasePossessiveRule : IGrammarTransformRule {
        private IDictionary<string, string> _exceptions = new Dictionary<string, string> {
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