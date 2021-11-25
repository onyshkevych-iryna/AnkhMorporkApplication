using System;
using System.Collections.Generic;

namespace AnkhMorporkApp
{
    public class GuildOfFools: Guilds<Fool>
    {
        public Dictionary<int, Fool> fools;

        public GuildOfFools()
        {
            fools = new Dictionary<int, Fool>()
            {
                { 1, new Fool("Muggins", 0.5)},
                { 2, new Fool( "Gull", 1  )},
                { 3, new Fool( "Dupe", 2 )},
                { 4, new Fool("Butt", 3 )},
                { 5, new Fool( "Fool", 5 )},
                { 6, new Fool( "Tomfool", 6 )},
                { 7, new Fool( "Stupid Fool", 7 )},
                { 8, new Fool( "Arch Fool", 8 )},
                { 9, new Fool( "Complete Fool", 10 )}

            };
        }

        public override void BalanceChange(Player player, Fool fool)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"Enter \'s\' to skip or \'j\' to join. You'll earn sum of {fool.Fee}");
            var validInput = false;
            do
            {
                number = Console.ReadLine();
                if (number == "s")
                {
                    player.Skip(number, fool);
                    validInput = true;
                }
                else if (number == "j")
                    player.GetMoney(fool.Fee, ref validInput);
                else
                    Console.WriteLine("Invalid input! Please, try again:");
            } while (!validInput);
        }
    }
}
