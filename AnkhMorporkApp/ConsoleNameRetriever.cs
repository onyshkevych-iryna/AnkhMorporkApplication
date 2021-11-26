using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnkhMorporkApp
{
    public class ConsoleNameRetriever
    {
        public virtual string GetNextName()
        {
            return Console.ReadLine();
        }
    }
}
