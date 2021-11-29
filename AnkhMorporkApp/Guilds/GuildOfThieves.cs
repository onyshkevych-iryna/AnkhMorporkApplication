using System;
using System.Collections.Generic;

namespace AnkhMorporkApp
{
    public class GuildOfThieves : Guilds<Thief>
    {
        public static int NumberOfThieves = 6;
        public List<Thief> Theves;

        public GuildOfThieves()
        {
            Theves = new List<Thief>();
        }

        public override void InteractionWithPlayer(Player player, Thief thief)
        {
            string input = null;
            decimal amount = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You came across a thieve!\nEnter \'s\' to skip. Or give {thief.Fee} AM$.");
            Console.ForegroundColor = ConsoleColor.White;
            if (player.IsOutOfMoney(thief.Fee))
                return;
            var validInput = false;
            do
            {
                input = Console.ReadLine();
                if (input == "s")
                {
                    player.Skip(thief);
                    return;
                }
                if (!Double.TryParse(input, out double result))
                {
                    Console.WriteLine("Incorrect data! Please, try again:");
                    continue;
                }
                amount = Decimal.Parse(input);
                if (amount != thief.Fee)
                    Console.WriteLine($"The amount isn't equal to {thief.Fee}! Please, try again:");
                else if(!player.EnteredSumIsCorrect(amount))
                    return;
                else 
                    player.GiveMoney(amount, ref validInput);
            } while (!validInput);
        }
    }
}
