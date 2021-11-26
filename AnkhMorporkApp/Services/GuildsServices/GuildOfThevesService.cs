using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnkhMorporkApp.Abstracts;

namespace AnkhMorporkApp.Services
{
    public class GuildOfThevesService : IGuildOfThevesService
    {
        public IFileService file;
        public GuildOfThevesService()
        {
            file = new FileService();
        }

        public void Theves(Random rnd, Player player)
        {
            GuildOfTheves.NumberOfTheves--;
            GuildOfTheves guildOfTheves = new GuildOfTheves();
            Thieve thieve = new Thieve();
            guildOfTheves.BalanceChange(player, thieve);
            if (player.IsAlive)
                Console.WriteLine(player);
        }
    }
}
