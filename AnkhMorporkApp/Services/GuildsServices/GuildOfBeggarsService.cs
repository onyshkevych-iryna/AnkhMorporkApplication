using System;
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

        public void BeggarMeetsPlayer(Random rnd, Player player)
        {
            GuildOfBeggars guildOfBeggars = new GuildOfBeggars();
            var beggars = guildOfBeggars.Beggars;
            Beggar randomBeggar = beggars[rnd.Next(1, beggars.Count + 1)];
            guildOfBeggars.InteractionWithPlayer(player, randomBeggar);
            if (player.IsAlive)
                Console.WriteLine(player);
        }
    }
}
