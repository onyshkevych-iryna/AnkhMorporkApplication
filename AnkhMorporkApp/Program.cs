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
                //GuildOfAssassins guild = new GuildOfAssassins();
                //Assassin assassin = guild.assassins[0];
                //guild.AssassinGetMoney(assassin, player); 
                //Console.WriteLine(player);
                //GuildOfTheves guildOfTheves = new GuildOfTheves();
                //Thieve thieve = new Thieve();
                //guildOfTheves.ThevesGetMoney(player,thieve);
                //Console.WriteLine(player);
                GuildOfFools guildOfFools = new GuildOfFools();
                var fools = guildOfFools.fools;
                var sum = fools["Twitchers"];
                var name = "Twitchers";
                Fool fool = new Fool(name, sum);
                guildOfFools.FoolGiveMoney(player, fool);
                Console.WriteLine(player);
            }

        }
    }
}
