﻿using System;
using AnkhMorporkApp.Abstracts;

namespace AnkhMorporkApp.Services.GuildsServices
{
    public class GuildOfFoolsService:IGuildOfFoolsService
    {
        public IFileService file;
        public GuildOfFoolsService()
        {
            file = new FileService();
        }

        public void FoolMeetsPlayer(Random rnd, Player player)
        {
            GuildOfFools guildOfFools = new GuildOfFools();
            var fools = guildOfFools.fools;
            Fool randomFool = fools[rnd.Next(1, fools.Count + 1)];
            guildOfFools.InteractionWithPlayer(player, randomFool);
            if (player.IsAlive)
                Console.WriteLine(player);
        }
    }
}
