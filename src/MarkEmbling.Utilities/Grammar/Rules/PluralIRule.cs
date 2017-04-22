using System;

namespace MarkEmbling.Utilities.Grammar.Rules {
    /// <summary>
    /// Replace the "us" on the end of a word with "i"
    /// </summary>
    public class PluralIRule : IGrammarTransformRule {
        public bool CanTransform(string input) {
            return input.EndsWith("us", StringComparison.OrdinalIgnoreCase);
        }

        public string Transform(string input) {
            return input.Substring(0, input.Length - 2) + "i";
        }
    }
}