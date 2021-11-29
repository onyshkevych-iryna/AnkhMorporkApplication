using System;
using AnkhMorporkApp.Abstracts;

namespace AnkhMorporkApp.Services
{
    public class GuildOfAssassinsService: IGuildOfAssassinsService
    {
        public IFileService File;

        public GuildOfAssassinsService()
        {
            File = new FileService();
        }

        public void AssassinMeetsPlayer(Player player)
        {
            GuildOfAssassins guildOfAssassins = new GuildOfAssassins(File);
            guildOfAssassins.InteractionWithPlayer(player, guildOfAssassins.Assassins);
            if (player.IsAlive)
                Console.WriteLine(player);
        }
    }
}
