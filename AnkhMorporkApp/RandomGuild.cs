using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnkhMorporkApp
{
    public class RandomGuild:IRandomGuild
    {
        public void Assassins(Player player)
        {
            GuildOfAssassins guildOfAssassins = new GuildOfAssassins();
            guildOfAssassins.BalanceChange(player, guildOfAssassins.assassins);
            if (player.IsAlive)
                Console.WriteLine(player);
        }

        public void Theves(Random rnd, Player player)
        {
            GuildOfTheves guildOfTheves = new GuildOfTheves();
            Thieve thieve = new Thieve();
            guildOfTheves.BalanceChange(player, thieve);
            if (player.IsAlive)
                Console.WriteLine(player);
        }

        public void Fools(Random rnd, Player player)
        {
            GuildOfFools guildOfFools = new GuildOfFools();
            var fools = guildOfFools.fools;
            var dict = fools[rnd.Next(1, fools.Count+1)];
            Fool fool = new Fool(dict.Select(v => v.Key).Single(), dict.Select(v => v.Value).Single());
            guildOfFools.BalanceChange(player, fool);
            if (player.IsAlive)
                Console.WriteLine(player);
        }

        public void Beggars(Random rnd, Player player)
        {
            GuildOfBeggars guildOfBeggars = new GuildOfBeggars();
            var beggars = guildOfBeggars.beggars;
            var dict1 = beggars[rnd.Next(1, beggars.Count+1)];
            Beggar beggar = new Beggar(dict1.Select(v => v.Key).Single(), dict1.Select(v => v.Value).Single());
            guildOfBeggars.BalanceChange(player, beggar);
            if (player.IsAlive) 
                Console.WriteLine(player);
        }
    }
}
