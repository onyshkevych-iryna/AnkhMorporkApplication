using System;
using System.Collections.Generic;

namespace AnkhMorporkApp
{
    public class GuildOfBeggars : Guilds<Beggar>
    {
        public Dictionary<int, Dictionary<string, double>> beggars;

        public GuildOfBeggars()
        {
            beggars = new Dictionary<int, Dictionary<string, double>>()
            {
                { 1, new Dictionary<string, double>(){{ "Twitchers", 3 } }},
                { 2, new Dictionary<string, double>(){{ "Droolers", 2 } }},
                { 3, new Dictionary<string, double>(){{ "Dribblers", 1 } }},
                { 4, new Dictionary<string, double>(){{ "Mumblers", 1 } }},
                { 5, new Dictionary<string, double>(){{ "Mutterers", 0.9 } }},
                { 6, new Dictionary<string, double>(){{ "Walking-Along-Shouter", 0.8 } }},
                { 7, new Dictionary<string, double>(){{ "Demanders of a Chip", 0.6 } }},
                { 8, new Dictionary<string, double>(){{ "People Who Call Other People Jimmy", 0.5 } }},
                { 9, new Dictionary<string, double>(){{ "People Who Need Eightpence For A Meal", 0.08 } }},
                { 10, new Dictionary<string, double>(){{ "People Who Need Tuppence For A Cup Of Tea", 0.02} }},
                { 11, new Dictionary<string, double>(){{ "People Who Need Tuppence For A Cup Of Tea", 0.02 } }}
            };
        }

        public override void BalanceChange(Player player, Beggar beggar)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"Enter 's' to skip. Or give sum of {beggar.Fee}");
            if (!player.IsMoneyEnough(beggar.Fee))
                return;
            var validInput = false;
            do
            {
                number = Console.ReadLine();
                if (player.Skip(number, beggar))
                    return;
                if (!Double.TryParse(number, out double result))
                {
                    Console.WriteLine("Incorrect data! Try again");
                }
                else
                {
                    input = Double.Parse(number);
                    if (input != beggar.Fee)
                    {
                        Console.WriteLine("Incorrect input! Try again");
                    }
                    else if (input > player.Balance)
                    {
                        Console.WriteLine("Incorrect data! Try again");
                    }
                    else
                    {
                        player.Balance -= input;
                        validInput = true;
                    }
                }
            } while (validInput == false);
        }
    }
}
