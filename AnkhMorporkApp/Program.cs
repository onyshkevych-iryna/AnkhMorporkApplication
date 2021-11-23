using System;
using System.Linq;

namespace AnkhMorporkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            IGameLogic gameLogic = new GameLogic();
            Console.WriteLine(player);
            while (player.IsAlive)
            {
                Random rnd = new Random();
                int random =rnd.Next(0,3);
                switch (random)
                {
                    case 0:
                        gameLogic.ZeroCase(rnd, player);
                        break;
                    case 1:
                        gameLogic.FirstCase(rnd, player);
                        break;
                    case 2:
                        gameLogic.SecondCase(rnd, player);
                        break;
                    case 3:
                        gameLogic.ThirdCase(rnd, player);
                        break;
                }
            }
        }
    }
}
