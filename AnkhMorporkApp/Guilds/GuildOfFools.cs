using System;
using System.Collections.Generic;

namespace AnkhMorporkApp
{
    public class GuildOfFools: Guilds<Fool>
    {
        public Dictionary<int, Dictionary<string,double>> fools;

        public GuildOfFools()
        {
            fools = new Dictionary<int,Dictionary<string, double>>()
            {
                { 1, new Dictionary<string, double>(){{"Muggins", 0.5}}},
                { 2, new Dictionary<string, double>(){{ "Gull", 1 } }},
                { 3, new Dictionary<string, double>(){{ "Dupe", 2 } }},
                { 4, new Dictionary<string, double>(){{ "Butt", 3 } }},
                { 5, new Dictionary<string, double>(){{ "Fool", 5 } }},
                { 6, new Dictionary<string, double>(){{ "Tomfool", 6 } }},
                { 7, new Dictionary<string, double>(){{ "Stupid Fool", 7 } }},
                { 8, new Dictionary<string, double>(){{ "Arch Fool", 8 } }},
                { 9, new Dictionary<string, double>(){{ "Complete Fool", 10 } }},

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
