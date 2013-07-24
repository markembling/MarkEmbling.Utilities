using System.Collections.Generic;
using MarkEmbling.Utils.Extensions.Grammar.Rules;

namespace MarkEmbling.Utils.Extensions.Grammar {
    public static class StringGrammarExtensions {
        /// <summary>
        /// Return either the single form (the current string) or the given plural form,
        /// based on the provided count.
        /// </summary>
        /// <param name="str">Current string instance</param>
        /// <param name="count">Number to apply pluralisation rules against</param>
        /// <param name="multipleForm">Alternate plural form of the word</param>
        public static string Pluralise(this string str, int count, string multipleForm) {
            // Note than .NET 4 also has PluralizationService inside System.Data.Entity.Design,
            // but that would then cause a dependancy on the full .NET 4.0 framework (i.e. not
            // work under the client profile. I'm not happy to do that...

            return count == 1 ? str : multipleForm;
        }

        /// <summary>
        /// Naive pluralisation method (simply adds an S to the end of the word if the
        /// given count is not one.
        /// </summary>
        /// <param name="str">Current string instance</param>
        /// <param name="count">Number to apply pluralisation rules against</param>
        public static string Pluralise(this string str, int count) {
            return Pluralise(str, count, str + "s");
        }

        /// <summary>
        /// Apply default (naive English) possession rules
        /// </summary>
        /// <param name="str">Current string instance</param>
        public static string Possessive(this string str) {
            return PerformGrammarTransformation(str, DefaultRuleSets.Possessive);
        }

        /// <summary>
        /// Apply the given grammar rules to the input string
        /// </summary>
        /// <param name="str">Current string instance</param>
        /// <param name="rules">Rules to apply</param>
        public static string PerformGrammarTransformation(this string str, IEnumerable<IGrammarTransformRule> rules) {
            var transformer = new GrammarTransformer(rules);
            return transformer.Transform(str);
        }
    }
}