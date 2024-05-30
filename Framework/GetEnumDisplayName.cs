using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Framework
{
    public static class GetEnumDisplayNameExtension
    {
        public static string GetEnumDisplayName(this Enum enumType)
        {
            return enumType.GetType().GetMember(enumType.ToString())
                           .First()
                           .GetCustomAttribute<DisplayAttribute>()
                           .Name;
        }
    }
}
