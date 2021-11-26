using System;
using AnkhMorporkApp.Services;
using AnkhMorporkApp.Services.GuildsServices;

namespace AnkhMorporkApp
{
    public class Game
    {
        private const int maxNumberOfGuilds = 4;
        private GuildOfAssassinsService assassinsService;
        private GuildOfFoolsService foolsService;
        private GuildOfBeggarsService beggarsService;
        private GuildOfThievesService thievesService;
        private Player player;

        public Game()
        {
            assassinsService = new GuildOfAssassinsService();
            foolsService = new GuildOfFoolsService();
            beggarsService = new GuildOfBeggarsService();
            thievesService = new GuildOfThievesService();
            player = new Player();
        }

        public void GameStart()
        {
            Console.WriteLine("The game started!");
            Console.WriteLine(player);
            while (player.IsAlive)
            {
                Random rnd = new Random();
                var random = rnd.Next(0, maxNumberOfGuilds);
                try
                {
                    switch (random)
                    {
                        case 0:
                            assassinsService.AssassinMeetsPlayer(player);
                            break;
                        case 1:
                            if (GuildOfThieves.NumberOfThieves > 0)
                                thievesService.ThiefMeetsPlayer(rnd, player);
                            break;
                        case 2:
                            foolsService.FoolMeetsPlayer(rnd, player);
                            break;
                        case 3:
                            beggarsService.BeggarMeetsPlayer(rnd, player);
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
