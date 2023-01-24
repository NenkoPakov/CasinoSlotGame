using System.Reflection;
using Casino.Attributes;

namespace Casino.Extensions
{
    public static class EnumExtensions
    {
        public static string GetStringValue(this Enum value)
        {
            if (value == null)
            {
                return String.Empty;
            }

            Type type = value.GetType();
            FieldInfo? fieldInfo = type.GetField(value.ToString());

            StringValueAttribute[]? attribs = fieldInfo?.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            return attribs?.Length > 0 ? attribs[0].Value : String.Empty;
        }
    }
}
