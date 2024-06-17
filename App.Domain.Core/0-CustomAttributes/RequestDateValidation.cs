using Framework;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace App.Domain.Core._0_CustomAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class RequestDateValidation : ValidationAttribute
{
    public sealed override bool IsValid(object? value)
    {
        if (value == null) return false;

        string dateFa = value.ToString();

        string pattern = "^(?:\\d{4})/(?:0[1-9]|1[0-2])/(?:0[1-9]|[1-2][0-9]|3[0-1])$";

        if (Regex.IsMatch(dateFa, pattern))
        {
            var inputDate = dateFa.ConvertToGregorian();

            return inputDate >= DateTime.Now;
        }
        return false;
    }
}
