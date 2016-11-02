using System;

namespace MarkEmbling.Utils.Extensions {
    public static class DoubleExtensions {
        /// <summary>
        /// Return the integer representation of this double
        /// </summary>
        /// <param name="value">Current double instance</param>
        /// <param name="method">Conversion method</param>
        /// <returns>Integer representation</returns>
        public static int ToInt(this double value, ToIntMethod method) {
            if (method == ToIntMethod.IgnoreFraction)
                return (int) value;

            if (method == ToIntMethod.Round)
                return Convert.ToInt32(value);

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Determine if a double is equivalent to the given double up to the level of precision provided
        /// </summary>
        /// <param name="double1">Double to compare</param>
        /// <param name="double2">Double to compare against</param>
        /// <param name="precision">Precision (number which defines the difference between the numbers which is considered different)</param>
        /// <returns>True if considered equivalent</returns>
        public static bool Equivalent(this double double1, double double2, double precision) {
            return Math.Abs(double1 - double2) <= precision;
        }
    }
}