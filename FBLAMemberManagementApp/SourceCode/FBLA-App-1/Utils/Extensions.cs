using System;
using System.Globalization;

namespace FBLA
{
    // Extensions class contains extension methods (for string and decimal variables)
    public static class Extensions
    {

        // extension method - captilizes only the first letter in the string
        public static string ToTitleCase(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        // extension method - converts number to a decimal rounded to two decimal places
        public static decimal ToCurrency(this decimal num)
        {
            return decimal.Round(num, 2, MidpointRounding.AwayFromZero);
        }

    }
}
