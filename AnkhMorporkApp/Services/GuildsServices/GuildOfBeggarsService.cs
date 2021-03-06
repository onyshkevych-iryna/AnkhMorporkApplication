using System;
using AnkhMorporkApp.Abstracts;

namespace AnkhMorporkApp.Services
{
    public class GuildOfBeggarsService : IGuildOfBeggarsService
    {
        public void BeggarMeetsPlayer(Random rnd, Player player)
        {
            var guildOfBeggars = new GuildOfBeggars();
            var beggars = guildOfBeggars.Beggars;
            var randomBeggar = beggars[rnd.Next(1, beggars.Count + 1)];
            guildOfBeggars.InteractionWithPlayer(player, randomBeggar);
            if (player.IsAlive)
            {
                Console.WriteLine(player);
            }
        }
    }
}
