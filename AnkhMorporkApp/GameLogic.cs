using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnkhMorporkApp
{
    public class GameLogic:IGameLogic
    {
        public void Assassins(Random rnd, Player player)
        {
            GuildOfAssassins guild = new GuildOfAssassins();
            int random1 = rnd.Next(0, guild.assassins.Count);
            Assassin assassin = guild.assassins[random1];
            guild.BalanceChange(player, assassin);
            Console.WriteLine(player);
        }

        public void Theves(Random rnd, Player player)
        {
            GuildOfTheves guildOfTheves = new GuildOfTheves();
            Thieve thieve = new Thieve();
            guildOfTheves.BalanceChange(player, thieve);
            Console.WriteLine(player);
        }

        public void Fools(Random rnd, Player player)
        {
            GuildOfFools guildOfFools = new GuildOfFools();
            var fools = guildOfFools.fools;
            int random2 = rnd.Next(1, fools.Count);
            var dict = fools[random2];
            var name = dict.Select(v => v.Key).Single();
            var sum = dict.Select(v => v.Value).Single();
            Fool fool = new Fool(name, sum);
            guildOfFools.BalanceChange(player, fool);
            Console.WriteLine(player);
        }

        public void Beggars(Random rnd, Player player)
        {
            GuildOfBeggars guildOfBeggars = new GuildOfBeggars();
            var beggars = guildOfBeggars.beggars;
            int random3 = rnd.Next(1, beggars.Count);
            var dict1 = beggars[random3];
            var name1 = dict1.Select(v => v.Key).Single();
            var sum1 = dict1.Select(v => v.Value).Single();
            Beggar beggar = new Beggar(name1, sum1);
            guildOfBeggars.BalanceChange(player, beggar);
            Console.WriteLine(player);
        }
    }
}
