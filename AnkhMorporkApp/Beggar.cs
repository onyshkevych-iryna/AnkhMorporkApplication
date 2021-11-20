using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkApp
{
    public class Beggar
    {
        public string Practice { get; set; }
        public double Fee { get; set; }

        public Beggar(string practice, double fee)
        {
            Practice = practice;
            Fee = fee;
        }

        public Beggar()
        {
        }
    }
}
