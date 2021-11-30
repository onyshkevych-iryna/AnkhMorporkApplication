using System;
using AnkhMorporkApp.Abstracts;

namespace AnkhMorporkApp.Services
{
    public class GuildOfAssassinsService: IGuildOfAssassinsService
    {
        public void AssassinMeetsPlayer(Player player)
        {
            var guildOfAssassins = new GuildOfAssassins();
            guildOfAssassins.InteractionWithPlayer(player, guildOfAssassins.Assassins);
            if (player.IsAlive)
            {
                Console.WriteLine(player);
            }
        }
    }
}
