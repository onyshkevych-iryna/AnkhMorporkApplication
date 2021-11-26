using System;
using AnkhMorporkApp.Abstracts;
using AnkhMorporkApp.Services;
using AnkhMorporkApp.Services.GuildsServices;

namespace AnkhMorporkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.GameStart();
        }
    }
}
