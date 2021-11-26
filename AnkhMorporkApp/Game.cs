using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnkhMorporkApp.Services;
using AnkhMorporkApp.Services.GuildsServices;

namespace AnkhMorporkApp
{
    public class Game
    {
        private GuildOfAssassinsService guildOfAssassins;
        private GuildOfFoolsService guildOfFools;
        private GuildOfBeggarsService guildOfBeggars;
        private GuildOfThevesService guildOfTheves;
        private Player player;
        public Game()
        { 
            guildOfAssassins = new GuildOfAssassinsService();
            guildOfFools = new GuildOfFoolsService();
            guildOfBeggars = new GuildOfBeggarsService();
            guildOfTheves = new GuildOfThevesService();
            player = new Player();
        }

        public void GameStart()
        {
            Console.WriteLine("The game started!");
            Console.WriteLine(player);
            while (player.IsAlive)
            {
                Random rnd = new Random();
                var random = rnd.Next(0, 4);
                try
                {
                    switch (random)
                    {
                        case 0:
                            guildOfAssassins.Assassins(player);
                            break;
                        case 1:
                            if (GuildOfTheves.NumberOfTheves >= 1)
                                guildOfTheves.Theves(rnd, player);
                            break;
                        case 2:
                            guildOfFools.Fools(rnd, player);
                            break;
                        case 3:
                            guildOfBeggars.Beggars(rnd, player);
                            break;
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
