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

        /// <summary>
        /// Truncate a string to the given number of characters.
        /// </summary>
        /// <param name="str">Current string instance</param>
        /// <param name="maxLength">Maximum number of characters</param>
        public static string Truncate(this string str, int maxLength) {
            return str.Length > maxLength ? str.Substring(0, maxLength) : str;
        }

        /// <summary>
        /// Truncate a string to the given number of characters, applying the given suffix.
        /// </summary>
        /// <param name="str">Current string instance</param>
        /// <param name="maxLength">Maximum number of characters</param>
        /// <param name="suffix">Suffix to append to the end of the truncated string</param>
        public static string Truncate(this string str, int maxLength, string suffix) {
            if (str.Length > maxLength && str.Length > suffix.Length && suffix.Length < maxLength)
                return Truncate(str, maxLength - suffix.Length) + suffix;
            return Truncate(str, maxLength);
        }

        /// <summary>
        /// Truncate a string on the last occurance of whitespace within the given
        /// character limit.
        /// </summary>
        /// <param name="str">Current string instance</param>
        /// <param name="maxLength">Maximum number of characters</param>
        public static string TruncateOnWhitespace(this string str, int maxLength) {
            if (str.Length <= maxLength) return str;

            var whitespace = new[]{' ', '\r', '\n', '\t'};
            var truncatedOnLimit = Truncate(str, maxLength);
            var indexOfLastSpace = truncatedOnLimit.LastIndexOfAny(whitespace);
            return indexOfLastSpace == -1
                ? truncatedOnLimit
                : Truncate(truncatedOnLimit, indexOfLastSpace);
        }

        /// <summary>
        /// Truncate a string on the last occurance of whitespace within the given
        /// character limit, applying the given suffix.
        /// </summary>
        /// <param name="str">Current string instance</param>
        /// <param name="maxLength">Maximum number of characters</param>
        /// <param name="suffix">Suffix to append to the end of the truncated string</param>
        public static string TruncateOnWhitespace(this string str, int maxLength, string suffix) {
            if (str.Length > maxLength && str.Length > suffix.Length && suffix.Length < maxLength) {
                var truncatedLeavingRoomForSuffix = TruncateOnWhitespace(str, maxLength - suffix.Length);
                return truncatedLeavingRoomForSuffix + suffix;
            }

            return TruncateOnWhitespace(str, maxLength);
        }
    }
}