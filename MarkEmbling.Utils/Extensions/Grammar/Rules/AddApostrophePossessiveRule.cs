namespace MarkEmbling.Utils.Extensions.Grammar.Rules {
    public class AddApostrophePossessiveRule : IGrammarTransformRule {
        public bool CanTransform(string input) {
            return input.Last().EqualsWithoutCase("S");
        }

        public string Transform(string input) {
            return input + "'";
        }
    }
}