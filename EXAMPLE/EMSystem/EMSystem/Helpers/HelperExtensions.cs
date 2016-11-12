using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMSystem.Helpers
{
    public static class HelperExtensions
    {
        public static string ToTitleCase(this string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        public static string Period(this DateTime date, DateTime with)
        {
            var value = ((with.Year - date.Year) * 12) + with.Month - date.Month;
            var years = value / 12;
            string yearString = years > 1 ? $"{years.ToString("0#")} Years" : (years == 1 ? $"{years.ToString("0#")} Year" : string.Empty);

            var months = value % 12;
            string monthString = months > 1 ? $"{months.ToString("0#")} Months" : (months == 1 ? $"{months.ToString("0#")} Month" : string.Empty);
            if (string.IsNullOrEmpty(yearString) && string.IsNullOrEmpty(monthString))
                return string.Empty;
            else if (!string.IsNullOrEmpty(yearString) && string.IsNullOrEmpty(monthString))
                return $"{yearString}";
            else if (string.IsNullOrEmpty(yearString) && !string.IsNullOrEmpty(monthString))
                return $"{monthString}";
            return $"{yearString} , {monthString}";
        }

        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static SelectList ToSelect<T>(this T enumObj) where T : struct, IComparable, IFormattable, IConvertible
        {
            var values = from T e in Enum.GetValues(typeof(T)) select new { Id = e, Name = e.ToString() };
            return new SelectList(values, "Id", "Name", enumObj.ToString());
        }

        public static decimal CurrencyToDecimal(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;
            return decimal.Parse(value, NumberStyles.Currency);
        }
    }
}