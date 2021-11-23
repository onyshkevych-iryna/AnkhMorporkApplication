using System;
using System.Collections.Generic;

namespace AnkhMorporkApp
{
    public class GuildOfTheves : Guilds<Thieve>
    {
        private int NumberOfTheves { get; set; } = 6;
        public List<Thieve> theves;

        public GuildOfTheves()
        {
            theves = new List<Thieve>(NumberOfTheves);
        }

        public override void BalanceChange(Player player, Thieve thieve)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"Enter \'s\' to skip. Give sum of {thieve.Fee}");
            if (!player.IsMoneyEnough(thieve.Fee))
                return;
            var validInput = false;
            do
            {
                number = Console.ReadLine();
                if (number == "s")
                {
                    Console.WriteLine("Game is over. You're killed");
                    player.IsAlive = false;
                    return;
                }

                if (!Double.TryParse(number, out double result))
                {
                    Console.WriteLine("Incorrect data! Try again");
                }
                else
                {
                    input = Double.Parse(number);
                    if (input != thieve.Fee)
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
            }
        while (!validInput);
        }
    }
}
