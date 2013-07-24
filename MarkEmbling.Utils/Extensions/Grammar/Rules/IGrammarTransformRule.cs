namespace MarkEmbling.Utils.Extensions.Grammar.Rules {
    public interface IGrammarTransformRule {
        bool CanTransform(string input);
        string Transform(string input);
    }
}