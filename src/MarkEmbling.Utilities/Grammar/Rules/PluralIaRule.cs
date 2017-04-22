using System;

namespace MarkEmbling.Utilities.Grammar.Rules {
    /// <summary>
    /// Replace the "ium" on the end of a word with "ia"
    /// </summary>
    public class PluralIaRule : IGrammarTransformRule {
        public bool CanTransform(string input) {
            return input.EndsWith("ium", StringComparison.OrdinalIgnoreCase);
        }

        public string Transform(string input) {
            return input.Substring(0, input.Length - 3) + "ia";
        }
    }
}