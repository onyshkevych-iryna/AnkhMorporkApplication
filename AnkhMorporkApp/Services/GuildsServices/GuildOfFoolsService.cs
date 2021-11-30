using System;
using AnkhMorporkApp.Abstracts;

namespace AnkhMorporkApp.Services.GuildsServices
{
    public class GuildOfFoolsService:IGuildOfFoolsService
    {
        public void FoolMeetsPlayer(Random rnd, Player player)
        {
            var guildOfFools = new GuildOfFools();
            var fools = guildOfFools.Fools;
            var randomFool = fools[rnd.Next(1, fools.Count + 1)];
            guildOfFools.InteractionWithPlayer(player, randomFool);
            if (player.IsAlive)
            {
                Console.WriteLine(player);
            }
        }
    }
}
