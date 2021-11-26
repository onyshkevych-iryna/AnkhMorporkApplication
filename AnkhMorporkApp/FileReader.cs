using System;
using System.IO;
using System.Reflection;

namespace AnkhMorporkApp
{
    public static class FileReader
    {
        public static string GetText(string fileName)
        {
            string allPath = null;
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                allPath = Path.Combine(path, fileName);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return File.ReadAllText(allPath);

        }
    }
}
