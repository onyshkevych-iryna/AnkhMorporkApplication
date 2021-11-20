using System;
using System.Collections.Generic;

namespace AnkhMorporkApp
{
    public class GuildOfTheves
    {
        private int NumberOfTheves { get; set; } = 6;
        public List<Thieve> theves;

        public GuildOfTheves()
        {
            theves = new List<Thieve>(NumberOfTheves);
        }

        public void ThevesGetMoney(Player player, Thieve thieve)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"Skip to skip. Give sum of {thieve.Fee}");
            if (player.Balance < thieve.Fee)
            {
                Console.WriteLine("You don't have enough money!");
                player.IsAlive = false;
                return;
            }
            var validInput = false;
            do
            {
                number = Console.ReadLine();
                if (number == "skip")
                {
                    Console.WriteLine("Game is over. You're killed");
                    player.IsAlive = false;
                    return;
                }
                input = Double.Parse(number);
                if (input!= thieve.Fee)
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
            } while (validInput == false);
        }
    }
}
