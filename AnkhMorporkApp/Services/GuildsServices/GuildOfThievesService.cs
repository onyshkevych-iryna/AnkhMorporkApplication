using System;
using AnkhMorporkApp.Abstracts;

namespace AnkhMorporkApp.Services
{
    public class GuildOfThievesService : IGuildOfThievesService
    {
        public void ThiefMeetsPlayer(Random rnd, Player player)
        {
            --GuildOfThieves.NumberOfThieves;
            var guildOfTheves = new GuildOfThieves();
            var thieve = new Thief();
            guildOfTheves.InteractionWithPlayer(player, thieve);
            if (player.IsAlive)
            {
                Console.WriteLine(player);
            }
        }
    }
}
