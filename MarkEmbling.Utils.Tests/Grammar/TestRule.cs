using MarkEmbling.Utils.Grammar.Rules;

namespace MarkEmbling.Utils.Tests.Grammar {
    /// <summary>
    /// Test rule
    /// </summary>
    internal class TestRule : IGrammarTransformRule {
        public bool CanTransform(string input) {
            return true;
        }

        public string Transform(string input) {
            return "bar";
        }
    }

    /// <summary>
    /// Test rule which cannot transform any string
    /// </summary>
    internal class TestUselessRule : IGrammarTransformRule {
        public bool CanTransform(string input) {
            return false;
        }

        public string Transform(string input) {
            return "error";
        }
    }
}