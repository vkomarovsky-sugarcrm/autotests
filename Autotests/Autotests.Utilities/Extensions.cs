using System;

namespace Autotests.Utilities
{
    public static class Extensions
    {
        public static bool Contains(this string source, string target, StringComparison stringComparison)
        {
            return source.IndexOf(target, stringComparison) >= 0;
        }

        public static bool Contains(this Uri source, Uri target)
        {
            return source.ToString().Contains(target.ToString());
        }

        public static int ToInt(this string source)
        {
            return string.IsNullOrEmpty(source) ? 0 : int.Parse(source);
        }
    }
}
