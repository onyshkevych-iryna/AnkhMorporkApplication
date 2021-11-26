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

        public void Assassins(Player player)
        {
            GuildOfAssassins guildOfAssassins = new GuildOfAssassins(file);
            guildOfAssassins.BalanceChange(player, guildOfAssassins.assassins);
            if (player.IsAlive)
                Console.WriteLine(player);
        }
    }
}
