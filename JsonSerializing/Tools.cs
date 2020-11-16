using System.IO;
using System.Reflection;

namespace JsonSerializing
{
    internal static class Tools
    {
        public static string CombineFileName(string fileName)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

            return Path.Combine(directoryName, fileName);
        }
    }
}