using System.IO;
using System.Reflection;

namespace AccessToData
{
    internal class Tools
    {
        public static string CombineFileName(string fileName)
        {
            string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

            return Path.Combine(directoryName, fileName);
        }
    }
}