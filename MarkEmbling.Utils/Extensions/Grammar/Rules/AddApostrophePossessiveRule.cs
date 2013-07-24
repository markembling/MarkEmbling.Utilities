namespace MarkEmbling.Utils.Extensions.Grammar.Rules {
    /// <summary>
    /// Apply an apostrophe to all input strings ending in S
    /// </summary>
    public class AddApostrophePossessiveRule : IGrammarTransformRule {
        public bool CanTransform(string input) {
            return input.Last().EqualsWithoutCase("S");
        }

        public string Transform(string input) {
            return input + "'";
        }
    }
}