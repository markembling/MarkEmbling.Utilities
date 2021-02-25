namespace MarkEmbling.Utilities.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Return a string representation of this number as an ordinal numeral
        /// </summary>
        /// <param name="value">Current integer instance</param>
        /// <returns>Ordinal numeral</returns>
        public static string ToOrdinal(this int value)
        {
            return ToOrdinal(value, null);
        }

        /// <summary>
        /// Return a string representation of this number as an ordinal numeral
        /// </summary>
        /// <param name="value">Current integer instance</param>
        /// <param name="format">A standard or custom numeric format string</param>
        /// <returns>Ordinal numeral</returns>
        public static string ToOrdinal(this int value, string format)
        {
            var number = !string.IsNullOrEmpty(format) ? value.ToString(format) : value.ToString();
            var suffix = GetOrdinalSuffix(value);
            return $"{number}{suffix}";
        }

        /// <summary>
        /// Return a string containing the appropriate ordinal suffix for the number
        /// </summary>
        /// <param name="value">Current integer instance</param>
        /// <returns>Ordinal suffix</returns>
        public static string GetOrdinalSuffix(this int value)
        {
            var lastTwoDigits = value % 100;
            if (lastTwoDigits < 11 || lastTwoDigits > 13)
            {
                var lastDigit = value % 10;
                if (lastDigit == 1) return "st";
                if (lastDigit == 2) return "nd";
                if (lastDigit == 3) return "rd";
            }
            return "th";
        }
    }
}
