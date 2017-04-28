using System;
using System.ComponentModel;
using System.Reflection;

namespace MarkEmbling.Utilities.Extensions {
    public static class EnumExtensions {
        /// <summary>
        /// Gets the description of an enumeration value
        /// 
        /// If there is no description attribute for this enumeration value, the
        /// raw name of the value is provided.
        /// </summary>
        /// <param name="value">Current enum value</param>
        /// <returns>Description or raw name</returns>
        public static string GetDescription(this Enum value) {
            var field = value.GetType().GetRuntimeField(value.ToString());
            var attribute = field.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        /// <summary>
        /// Gets the underlying numeric value of an enumeration value
        /// </summary>
        /// <param name="value">Current enum value</param>
        /// <returns>Underlying numeric value</returns>
        public static object GetUnderlyingValue(this Enum value) {
            var type = Enum.GetUnderlyingType(value.GetType());
            return Convert.ChangeType(value, type);
        }

        /// <summary>
        /// Gets the underlying numeric value of an enumeration value
        /// </summary>
        /// <typeparam name="T">Underlying numeric type of the enum</typeparam>
        /// <param name="value">Current enum value</param>
        /// <returns>Underlying numeric value as T</returns>
        public static T GetUnderlyingValue<T>(this Enum value) {
            var enumType = value.GetType();
            var underlyingType = Enum.GetUnderlyingType(enumType);
            var expectedType = typeof(T);

            if (underlyingType != expectedType)
                throw new InvalidOperationException(
                    string.Format(
                        "{0} has the underlying type of {1} instead of {2}",
                        enumType.Name,
                        underlyingType.Name,
                        expectedType.Name));

            return (T)Convert.ChangeType(value, expectedType);
        }
    }
}
