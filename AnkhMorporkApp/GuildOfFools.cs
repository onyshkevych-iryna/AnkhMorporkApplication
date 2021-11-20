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
            fools.Add("Twitchers", 3);
            fools.Add("Droolers", 2);
            fools.Add("Dribblers", 1);
            fools.Add("Mumblers", 1);
            fools.Add("Mutterers", 0.9);
            fools.Add("Walking-Along-Shouter", 0.8);
            fools.Add("Demanders of a Chip", 0.6);
            fools.Add("People Who Call Other People Jimmy", 0.5);
            fools.Add("People Who Need Eightpence For A Meal", 0.08);
            fools.Add("People Who Need Tuppence For A Cup Of Tea", 0.02);
            fools.Add("People With Placards Saying \"Why lie ? I need a beer\"", 0);
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
