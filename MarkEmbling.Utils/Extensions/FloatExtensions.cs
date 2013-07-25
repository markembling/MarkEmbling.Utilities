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
    }
}