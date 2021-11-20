using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkApp
{
    public class GuildOfFools
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
                { 7, new Dictionary<string, double>(){{ "Arch Fool", 8 } }},
                { 7, new Dictionary<string, double>(){{ "Complete Fool", 10 } }},

            };
            
        }

        public void FoolGiveMoney(Player player, Fool fool)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"Join or to skip. You'll earn sum of {fool.Fee}");
            number = Console.ReadLine();
                if (number == "skip")
                {
                    Console.WriteLine("You skipped that fool");
                    return;
                }
                if (number == "Y")
                input = fool.Fee;
                player.Balance += input;
        }
    }
}
