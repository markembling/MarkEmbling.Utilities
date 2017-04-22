using MarkEmbling.Utilities.Extensions;

namespace MarkEmbling.Utilities.Grammar.Rules {
    /// <summary>
    /// Apply "es" to the end of all words ending in S or O
    /// </summary>
    public class PluralEsRule : IGrammarTransformRule {
        public bool CanTransform(string input) {
            var lastCharacter = input.Last();
            return lastCharacter.EqualsWithoutCase("S") || 
                lastCharacter.EqualsWithoutCase("O");
        }

        public string Transform(string input) {
            return input + "es";
        }
    }
}