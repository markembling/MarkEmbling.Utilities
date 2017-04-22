using MarkEmbling.Utilities.Extensions;

namespace MarkEmbling.Utilities.Grammar.Rules {
    /// <summary>
    /// Apply an S to all input strings not ending in S or O
    /// </summary>
    public class PluralSRule : IGrammarTransformRule {
        public bool CanTransform(string input) {
            var lastCharacter = input.Last();
            return !lastCharacter.EqualsWithoutCase("S") && 
                !lastCharacter.EqualsWithoutCase("O");
        }

        public string Transform(string input) {
            return input + "s";
        }
    }
}