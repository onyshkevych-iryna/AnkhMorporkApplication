using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkApp
{
    public class GuildOfFools
    {
        public Dictionary<string,double> fools;

        public GuildOfFools()
        {
            fools = new Dictionary<string, double>();
            fools.Add("Muggins", 0.5);
            fools.Add("Gull", 1);
            fools.Add("Dupe", 2);
            fools.Add("Butt", 3);
            fools.Add("Fool", 5);
            fools.Add("Tomfool", 6);
            fools.Add("Stupid Foolp", 7);
            fools.Add("Arch Fool", 8);
            fools.Add("Complete Fool", 10);
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
