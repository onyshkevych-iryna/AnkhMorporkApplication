using System;
using System.Linq;

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
                Random rnd = new Random();
                int random =rnd.Next(0,3);
                switch (random)
                {
                    case 0:
                        GuildOfAssassins guild = new GuildOfAssassins();
                        int random1 = rnd.Next(0, guild.assassins.Count);
                        Assassin assassin = guild.assassins[random1];
                        guild.AssassinGetMoney(assassin, player);
                        Console.WriteLine(player);
                        break;
                    case 1:
                        GuildOfTheves guildOfTheves = new GuildOfTheves();
                        Thieve thieve = new Thieve();
                        guildOfTheves.ThevesGetMoney(player, thieve);
                        Console.WriteLine(player);
                        break;
                    case 2:
                        GuildOfFools guildOfFools = new GuildOfFools();
                        var fools = guildOfFools.fools;
                        int random2 = rnd.Next(1, fools.Count);
                        var dict = fools[random2];
                        var name = dict.Select(v=>v.Key).Single();
                        var sum = dict.Select(v => v.Value).Single();
                        Fool fool = new Fool(name, sum);
                        guildOfFools.FoolGiveMoney(player, fool);
                        Console.WriteLine(player);
                        break;
                    //case 3:
                    //    GuildOfBeggars guildOfBeggars = new GuildOfBeggars();
                    //    var beggars = guildOfBeggars.beggars;

                    //    var sum1 = beggars["Twitchers"];
                    //    var name1 = "Twitchers";

                    //    Beggar beggar = new Beggar(name1, sum1);
                    //    guildOfBeggars.BeggarGetMoney(player, beggar);
                    //    Console.WriteLine(player);
                    //    break;

                }

            }
        }
    }
}
