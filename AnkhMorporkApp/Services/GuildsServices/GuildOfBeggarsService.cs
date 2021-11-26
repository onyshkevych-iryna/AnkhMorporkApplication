﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnkhMorporkApp.Abstracts;

namespace AnkhMorporkApp.Services
{
    public class GuildOfBeggarsService : IGuildOfBeggarsService
    {
        public IFileService file;
        public GuildOfBeggarsService()
        {
            file = new FileService();
        }

        public void Beggars(Random rnd, Player player)
        {
            GuildOfBeggars guildOfBeggars = new GuildOfBeggars();
            var beggars = guildOfBeggars.beggars;
            var randomBeggar = beggars[rnd.Next(1, beggars.Count + 1)];
            Beggar beggar = new Beggar(randomBeggar.Practice, randomBeggar.Fee);
            guildOfBeggars.BalanceChange(player, beggar);
            if (player.IsAlive)
                Console.WriteLine(player);
        }
    }
}