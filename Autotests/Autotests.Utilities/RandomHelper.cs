using System.IO;

namespace Autotests.Utilities
{
    public static class RandomHelper
    {
        public static string RandomString
        {
            get { return Path.GetRandomFileName().Replace(".", string.Empty); }
        }
    }
}
