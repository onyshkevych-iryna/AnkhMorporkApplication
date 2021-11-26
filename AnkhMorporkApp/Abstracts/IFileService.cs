using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkhMorporkApp.Abstracts
{
    interface IFileService
    {
        public string GetText(string fileName);
    }
}
