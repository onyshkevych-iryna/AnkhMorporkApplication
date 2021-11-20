using System;

namespace AnkhMorporkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Console.WriteLine(player);
            while (player.IsAlive==true)
            {
                GuildOfAssassins guild = new GuildOfAssassins();
                Assassin assassin = guild.assassins[0];
                guild.AssassinGetMoney(assassin, player); 
                Console.WriteLine(player);
            }
            
        }
    }
}
