using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web;

namespace Seed.Utilities
{
    public static class StringUtilities
    {
        public static string SafeToTitleCase(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            string result = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());

            return result;
        }

        public static string SafeToLower(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return str.ToLowerInvariant();
        }

        public static string SafeToUpper(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return str.ToUpper();
        }

        public static string SafeTrim(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            return str.Trim();
        }

        public static string NormalizeText(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            string result = text.ToLower().Trim();

            result = Regex.Replace(
                result,
                @"(\A|[.!?])\s*[a-z]",
                match => string.Join(
                    " ",
                    match.ToString().Split(
                        new[]
                        {
                            ' '
                        },
                        StringSplitOptions.RemoveEmptyEntries)).ToUpper());

            result = Regex.Replace(
                result,
                @"\s*[,;:]\s*",
                match => match.ToString().Trim() + " ");

            if (!result.EndsWith(".") && !result.EndsWith("?") && !result.EndsWith("!"))
            {
                result += ".";
            }

            return result;
        }

        public static string NormalizeUrl(this string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return string.Empty;
            }

            string result = url.Trim().ToLowerInvariant();

            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                result = string.Format("{0}{1}{2}", Uri.UriSchemeHttp, Uri.SchemeDelimiter, result);
            }

            return result;
        }

        public static string FormatPhone(this string phone)
        {
            if (string.IsNullOrWhiteSpace(phone) || phone.Contains("()-"))
            {
                return string.Empty;
            }

            return phone.Trim();
        }

        public static string FormatEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return string.Empty;
            }

            string result = email.Trim().ToLowerInvariant();

            return result;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsEqualUrlWithoutQuery(this string url1, string url2)
        {
            string path1 = url1;

            int index1 = url1.IndexOf("?", StringComparison.Ordinal);
            if (index1 > -1)
            {
                path1 = url1.Substring(0, index1);
            }

            string path2 = url2;

            int index2 = url2.IndexOf("?", StringComparison.Ordinal);
            if (index2 > -1)
            {
                path2 = url2.Substring(0, index2);
            }

            //NOTE: Necessary for the agent details page, because HtmlUrl generated without paging, but requested url could be with paging.
            index1 = url1.IndexOf("/page", StringComparison.Ordinal);
            if (index1 > -1)
            {
                path1 = url1.Substring(0, index1);
            }

            index2 = url2.IndexOf("/page", StringComparison.Ordinal);
            if (index2 > -1)
            {
                path2 = url2.Substring(0, index2);
            }

            return path1.Equals(path2, StringComparison.InvariantCultureIgnoreCase);
        }

        public static string Reverse(this string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string UrlDecode(this string input)
        {
            if (input.IsNullOrEmpty())
            {
                return input;
            }

            return HttpUtility.UrlDecode(input);
        }

        public static string NormalizeInputText(this string input)
        {
            if (input.IsNullOrEmpty())
            {
                return string.Empty;
            }

            return input.UrlDecode().SafeTrim();
        }
    }
}
