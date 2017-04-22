using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MarkEmbling.Utilities {
    public class EnumHelper {
        /// <summary>
        /// Gets a list containing all values from the given enum
        /// </summary>
        /// <typeparam name="TEnum">The enum type</typeparam>
        /// <returns>List of enum values</returns>
        public static IEnumerable<TEnum> GetValuesList<TEnum>() {
            if (!typeof(TEnum).GetTypeInfo().IsEnum)
                throw new InvalidOperationException("GetValuesList requires an enum type");
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }
    }
}