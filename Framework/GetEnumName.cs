using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Framework;

public static class GetEnumName
{
    public static string GetEnumDisplayName(this Enum enumType)
    {
        return enumType.GetType().GetMember(enumType.ToString())
                       .First()
                       .GetCustomAttribute<DisplayAttribute>()
                       .Name;
    }
}
