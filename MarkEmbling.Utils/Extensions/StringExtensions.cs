using System;

namespace MarkEmbling.Utils.Extensions {
    public static class StringExtensions {
        /// <summary>
        /// Determine if this string is equal to another, ignoring casing.
        /// </summary>
        /// <param name="str">Current string instance</param>
        /// <param name="value">The string to compare to this instance</param>
        public static bool EqualsWithoutCase(this string str, string value) {
            return str.Equals(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns the first N characters from the string.
        /// </summary>
        public static string First(this string str, int length) {
            return 
                string.IsNullOrEmpty(str) ? 
                string.Empty : 
                str.Substring(0, length);
        }

        /// <summary>
        /// Returns the first character from the string.
        /// </summary>
        public static string First(this string str) {
            return str.First(1);
        }

        /// <summary>
        /// Returns the last N characters from the string.
        /// </summary>
        public static string Last(this string str, int length) {
            return 
                string.IsNullOrEmpty(str) ? 
                string.Empty : 
                str.Substring(str.Length - length);
        }

        /// <summary>
        /// Returns the last character from the string.
        /// </summary>
        public static string Last(this string str) {
            return str.Last(1);
        }
    }
}