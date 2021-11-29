using System;
using AnkhMorporkApp.Abstracts;

namespace AnkhMorporkApp.Services
{
    public class GuildOfAssassinsService: IGuildOfAssassinsService
    {
        public IFileService file;

        public GuildOfAssassinsService()
        {
            file = new FileService();
        }

        public void AssassinMeetsPlayer(Player player)
        {
            GuildOfAssassins guildOfAssassins = new GuildOfAssassins(file);
            guildOfAssassins.InteractionWithPlayer(player, guildOfAssassins.Assassins);
            if (player.IsAlive)
                Console.WriteLine(player);
        }
    }
}
