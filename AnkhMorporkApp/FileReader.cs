using System.IO;
using System.Reflection;

namespace AnkhMorporkApp
{
    public static class FileReader
    {
        public static string GetText(string fileName)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var allPath = Path.Combine(path, fileName);
            return File.ReadAllText(allPath);
        }
    }
}
