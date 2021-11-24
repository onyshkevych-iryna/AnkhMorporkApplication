﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnkhMorporkApp
{
    public class GameLogic:IGameLogic
    {
        public void Assassins(Random rnd, Player player)
        {
            GuildOfAssassins guildOfAssassins = new GuildOfAssassins();
            Assassin assassin = guildOfAssassins.assassins[rnd.Next(0, guildOfAssassins.assassins.Count)];
            guildOfAssassins.BalanceChange(player, assassin);
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
            var dict = fools[rnd.Next(1, fools.Count)];
            Fool fool = new Fool(dict.Select(v => v.Key).Single(), dict.Select(v => v.Value).Single());
            guildOfFools.BalanceChange(player, fool);
            Console.WriteLine(player);
        }

        public void Beggars(Random rnd, Player player)
        {
            GuildOfBeggars guildOfBeggars = new GuildOfBeggars();
            var beggars = guildOfBeggars.beggars;
            var dict1 = beggars[rnd.Next(1, beggars.Count)];
            Beggar beggar = new Beggar(dict1.Select(v => v.Key).Single(), dict1.Select(v => v.Value).Single());
            guildOfBeggars.BalanceChange(player, beggar);
            Console.WriteLine(player);
        }
    }
}