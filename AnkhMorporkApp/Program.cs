using System;
using System.Linq;

namespace AnkhMorporkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            IRandomGuild randomGuild = new RandomGuild();
            Console.WriteLine("The game started!");
            Console.WriteLine(player);
            while (player.IsAlive)
            {
                Random rnd = new Random();
                int random =rnd.Next(0,3);
                switch (random)
                {
                    case 0:
                        randomGuild.Assassins(rnd,player);
                        break;
                    case 1:
                        randomGuild.Theves(rnd,player);
                        break;
                    case 2:
                        randomGuild.Fools(rnd,player);
                        break;
                    case 3:
                        randomGuild.Beggars(rnd,player);
                        break;
                }
            }
        }
    }
}
