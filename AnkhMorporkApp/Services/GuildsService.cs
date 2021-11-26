using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnkhMorporkApp
{
    public class GuildsService:IGuildsService
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
            GuildOfTheves.NumberOfTheves--;
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
            var randomFool = fools[rnd.Next(1, fools.Count+1)];
            Fool fool = new Fool(randomFool.Practice, randomFool.Fee);
            guildOfFools.BalanceChange(player, fool);
            if (player.IsAlive)
                Console.WriteLine(player);
        }

        public void Beggars(Random rnd, Player player)
        {
            GuildOfBeggars guildOfBeggars = new GuildOfBeggars();
            var beggars = guildOfBeggars.beggars;
            var randomBeggar = beggars[rnd.Next(1, beggars.Count+1)];
            Beggar beggar = new Beggar(randomBeggar.Practice, randomBeggar.Fee);
            guildOfBeggars.BalanceChange(player, beggar);
            if (player.IsAlive) 
                Console.WriteLine(player);
        }
    }
}
