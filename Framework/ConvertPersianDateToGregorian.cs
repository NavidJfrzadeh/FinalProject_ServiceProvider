using System.Globalization;

namespace Framework;

public static class ConvertPersianDateToGregorian
{
    public static DateTime ConvertToGregorian(this string persianDate)
    {
        DateTime dt = DateTime.Parse(persianDate, new CultureInfo("fa-IR"));
        return dt;
    }
}
