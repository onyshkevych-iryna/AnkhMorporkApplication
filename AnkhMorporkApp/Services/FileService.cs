using System;
using System.IO;
using System.Reflection;
using AnkhMorporkApp.Abstracts;

namespace AnkhMorporkApp
{
    public class FileService:IFileService
    {
        public string GetText(string fileName)
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
