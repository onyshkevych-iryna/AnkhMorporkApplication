using System;

namespace AnkhMorporkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            IGuildsService randomGuild = new GuildsService();
            Console.WriteLine("The game started!");
            Console.WriteLine(player);
            while (player.IsAlive)
            {
                Random rnd = new Random();
                var random = rnd.Next(0,4);
                try
                {
                    switch (random)
                    {
                        case 0:
                            randomGuild.Assassins(player);
                            break;
                        case 1:
                            if(GuildOfTheves.NumberOfTheves>=1)
                                randomGuild.Theves(rnd, player);
                            break;
                        case 2:
                            randomGuild.Fools(rnd, player);
                            break;
                        case 3:
                            randomGuild.Beggars(rnd, player);
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
