using System;

namespace MarkEmbling.Utils.Extensions {
    public static class FloatExtensions {
        /// <summary>
        /// Return the integer representation of this double
        /// </summary>
        /// <param name="value">Current float instance</param>
        /// <param name="method">Conversion method</param>
        /// <returns>Integer representation</returns>
        public static int ToInt(this float value, ToIntMethod method) {
            if (method == ToIntMethod.IgnoreFraction)
                return (int) value;

            if (method == ToIntMethod.Round)
                return Convert.ToInt32(value);

            throw new InvalidOperationException();
        }

        /// <summary>
        /// Determine if a float is equivalent to the given float up to the level of precision provided
        /// </summary>
        /// <param name="double1">Float to compare</param>
        /// <param name="double2">Float to compare against</param>
        /// <param name="precision">Precision (number which defines the difference between the numbers which is considered different)</param>
        /// <returns>True if considered equivalent</returns>
        public static bool Equivalent(this float double1, float double2, float precision) {
            return Math.Abs(double1 - double2) <= precision;
        }
    }
}