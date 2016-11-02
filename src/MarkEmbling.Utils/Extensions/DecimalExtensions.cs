using System;

namespace MarkEmbling.Utils.Extensions {
    public static class DecimalExtensions {
        /// <summary>
        /// Return the integer representation of this decimal
        /// </summary>
        /// <param name="value">Current decimal instance</param>
        /// <param name="method">Conversion method</param>
        /// <returns>Integer representation</returns>
        public static int ToInt(this decimal value, ToIntMethod method) {
            switch (method) {
                case ToIntMethod.IgnoreFraction:
                    return (int)value;
                case ToIntMethod.Round:
                    return Convert.ToInt32(value);
                default:
                    throw new ArgumentOutOfRangeException(nameof(method), method, null);
            }
        }
    }
}