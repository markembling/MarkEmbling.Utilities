using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MarkEmbling.Utilities.Extensions {
    public static class EnumExtensions {
        /// <summary>
        /// Gets the display name of an enumeration value
        /// 
        /// If there is no display attribute for this enumeration value, the
        /// raw name of the value is provided. If there is a display attribute
        /// but no name, the null name value is returned.
        /// </summary>
        /// <param name="value">Current enum value</param>
        /// <returns>Display name or raw name</returns>
        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetRuntimeField(value.ToString());
            var attribute = field.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

            return attribute == null ? value.ToString() : attribute.GetName();
        }

        /// <summary>
        /// Gets the display description of an enumeration value
        /// 
        /// If there is no display attribute for this enumeration value, the
        /// raw name of the value is provided. If there is a display attribute
        /// but no description, the null description is returned.
        /// </summary>
        /// <param name="value">Current enum value</param>
        /// <returns>Display description or raw name</returns>
        public static string GetDisplayDescription(this Enum value)
        {
            var field = value.GetType().GetRuntimeField(value.ToString());
            var attribute = field.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;

            return attribute == null ? value.ToString() : attribute.GetDescription();
        }

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
        public static object GetNumericValue(this Enum value) {
            var type = Enum.GetUnderlyingType(value.GetType());
            return Convert.ChangeType(value, type);
        }

        /// <summary>
        /// Gets the underlying numeric value of an enumeration value
        /// </summary>
        /// <typeparam name="T">Underlying numeric type of the enum</typeparam>
        /// <param name="value">Current enum value</param>
        /// <returns>Underlying numeric value as T</returns>
        public static T GetNumericValue<T>(this Enum value) {
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
