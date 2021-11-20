using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkApp
{
    public class Thieve : GuildOfTheves
    {
        public double Fee { get; set; } = 10;

        public Thieve(double fee)
        {
            Fee = fee;
        }

        public Thieve()
        {
        }
    }
}
