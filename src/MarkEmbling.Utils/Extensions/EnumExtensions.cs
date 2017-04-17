using System;
using System.ComponentModel;
using System.Reflection;

namespace MarkEmbling.Utils.Extensions {
    public static class EnumExtensions {
        /// <summary>
        /// Gets the description of a field in an enumeration. If there is no
        /// description attribute, the raw name of the field is provided.
        /// </summary>
        /// <param name="value">Enum value</param>
        /// <returns>Description or raw name</returns>
        public static string GetDescription(this Enum value) {
            var field = value.GetType().GetRuntimeField(value.ToString());
            var attribute = field.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
