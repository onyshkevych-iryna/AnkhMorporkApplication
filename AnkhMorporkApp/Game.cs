using System;
using AnkhMorporkApp.Services;
using AnkhMorporkApp.Services.GuildsServices;

namespace AnkhMorporkApp
{
    public class Game
    {
        private const int _maxNumberOfGuilds = 4;
        private GuildOfAssassinsService _assassinsService;
        private GuildOfFoolsService _foolsService;
        private GuildOfBeggarsService _beggarsService;
        private GuildOfThievesService _thievesService;
        private Player _player;

        public Game()
        {
            _assassinsService = new GuildOfAssassinsService();
            _foolsService = new GuildOfFoolsService();
            _beggarsService = new GuildOfBeggarsService();
            _thievesService = new GuildOfThievesService();
            _player = new Player();
        }

        public void GameStart()
        {
            Console.WriteLine("The game started!");
            Console.WriteLine(_player);
            while (_player.IsAlive)
            {
                Random rnd = new Random();
                var random = rnd.Next(0, _maxNumberOfGuilds);
                try
                {
                    switch (random)
                    {
                        case 0:
                            _assassinsService.AssassinMeetsPlayer(_player);
                            break;
                        case 1:
                            if (GuildOfThieves.NumberOfThieves > 0)
                                _thievesService.ThiefMeetsPlayer(rnd, _player);
                            break;
                        case 2:
                            _foolsService.FoolMeetsPlayer(rnd, _player);
                            break;
                        case 3:
                            _beggarsService.BeggarMeetsPlayer(rnd, _player);
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
