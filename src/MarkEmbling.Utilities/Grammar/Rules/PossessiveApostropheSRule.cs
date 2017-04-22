using MarkEmbling.Utilities.Extensions;

namespace MarkEmbling.Utilities.Grammar.Rules {
    /// <summary>
    /// Apply an apostrophe and the letter S (lower case) to strings
    /// not ending in S
    /// </summary>
    public class PossessiveApostropheSRule : IGrammarTransformRule {
        public bool CanTransform(string input) {
            return !input.Last().EqualsWithoutCase("S");
        }

        public string Transform(string input) {
            return input + "'s";
        }
    }
}