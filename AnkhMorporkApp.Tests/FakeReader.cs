using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnkhMorporkApp.Abstracts;

namespace AnkhMorporkApp.Tests
{
    public class FakeReader: IFileService
    {
        public string GetText(string fileName)
        {
            return "";
        }
    }
}
