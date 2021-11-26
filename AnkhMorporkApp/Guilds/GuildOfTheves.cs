using System;
using System.Collections.Generic;

namespace AnkhMorporkApp
{
    public class GuildOfTheves : Guilds<Thieve>
    {
        public static int NumberOfTheves = 6;
        private List<Thieve> theves;

        public GuildOfTheves()
        {
            theves = new List<Thieve>();
        }

        public override void BalanceChange(Player player, Thieve thieve)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"Enter \'s\' to skip. Give sum of {thieve.Fee}");
            if (player.IsOutOfMoney(thieve.Fee))
                return;
            var validInput = false;
            do
            {
                number = Console.ReadLine();
                if (number == "s")
                {
                    player.Skip(number, thieve);
                    return;
                }
                if (!Double.TryParse(number, out double result))
                {
                    Console.WriteLine("Incorrect data! Please, try again:");
                    continue;
                }
                input = Double.Parse(number);
                if (input != thieve.Fee)
                    Console.WriteLine($"The amount isn't equal {thieve.Fee}! Please, try again:");
                else if(!player.EnteredSumIsCorrect(input))
                    return;
                else 
                    player.GiveMoney(input, ref validInput);
            } while (!validInput);
        }
    }
}
