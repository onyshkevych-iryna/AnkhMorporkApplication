using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkApp
{
    interface IGameLogic
    {
        public void ZeroCase(Random rnd, Player player);
        public void FirstCase(Random rnd, Player player);
        public void SecondCase(Random rnd, Player player);
        public void ThirdCase(Random rnd, Player player);
    }
}
