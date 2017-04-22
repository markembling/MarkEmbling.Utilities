using MarkEmbling.Utilities.Extensions;

namespace MarkEmbling.Utilities.Grammar.Rules {
    /// <summary>
    /// Apply an apostrophe to all input strings ending in S
    /// </summary>
    public class PossessiveApostropheRule : IGrammarTransformRule {
        public bool CanTransform(string input) {
            return input.Last().EqualsWithoutCase("S");
        }

        public string Transform(string input) {
            return input + "'";
        }
    }
}