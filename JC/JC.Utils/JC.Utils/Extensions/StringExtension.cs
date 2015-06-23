using System;
using System.ComponentModel;
using System.Web;

namespace JC.Utils.Extensions
{
    public static class StringExtension
    {
        #region Data convert
        public static int AsInt(this string value)
        {
            return AsInt(value, 0);
        }

        public static int AsInt(this string value, int defaultValue)
        {
            int result;
            return Int32.TryParse(value, out result) ? result : defaultValue;
        }

        public static bool AsBool(this string value)
        {
            return AsBool(value, default(bool));
        }

        public static bool AsBool(this string value, bool defaultValue)
        {
            bool result;
            return Boolean.TryParse(value, out result) ? result : defaultValue;
        }

        public static decimal AsDecimal(this string value)
        {
            return AsDecimal(value, 0m);
        }

        public static decimal AsDecimal(this string value, decimal defaultValue)
        {
            // Decimal.TryParse does not work consistently for some locales. For instance for lt-LT, it accepts but ignores decimal values so "12.12" is parsed as 1212.
            return As<Decimal>(value, defaultValue);
        }

        public static TValue As<TValue>(this string value, TValue defaultValue)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(TValue));
                if (converter.CanConvertFrom(typeof(string)))
                {
                    return (TValue)converter.ConvertFrom(value);
                }
                // try the other direction
                converter = TypeDescriptor.GetConverter(typeof(string));
                if (converter.CanConvertTo(typeof(TValue)))
                {
                    return (TValue)converter.ConvertTo(value, typeof(TValue));
                }
            }
            catch
            {
                return defaultValue;
            }

            return defaultValue;
        }
        #endregion

        #region String extension

        public static string UrlEncode(this string input)
        {
            return HttpUtility.UrlEncode(input);
        }

        public static string UrlDecode(this string input)
        {
            return HttpUtility.UrlDecode(input);
        }

        public static string HtmlEncode(this string input)
        {
            return HttpUtility.HtmlEncode(input);
        }

        public static string HtmlDecode(this string input)
        {
            return HttpUtility.HtmlDecode(input);
        }

        #endregion
    }
}
