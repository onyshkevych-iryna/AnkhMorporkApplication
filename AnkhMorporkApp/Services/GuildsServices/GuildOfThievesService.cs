using System;
using AnkhMorporkApp.Abstracts;

namespace AnkhMorporkApp.Services
{
    public class GuildOfThievesService : IGuildOfThievesService
    {
        public IFileService File;

        public GuildOfThievesService()
        {
            File = new FileService();
        }

        public void ThiefMeetsPlayer(Random rnd, Player player)
        {
            --GuildOfThieves.NumberOfThieves;
            GuildOfThieves guildOfTheves = new GuildOfThieves();
            Thief thieve = new Thief();
            guildOfTheves.InteractionWithPlayer(player, thieve);
            if (player.IsAlive)
                Console.WriteLine(player);
        }
    }
}
