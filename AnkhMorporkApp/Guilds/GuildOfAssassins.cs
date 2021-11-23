using System;
using System.Collections.Generic;

namespace AnkhMorporkApp
{
    public class GuildOfAssassins :Guilds<Assassin>
    {
        public List<Assassin> assassins;

        public GuildOfAssassins()
        {
            assassins = new List<Assassin>()
            {
                new Assassin("Assassin1", 15, 30, true),
                new Assassin("Assassin2", 10, 20, false),
                new Assassin("Assassin3", 7, 12, true),
                new Assassin("Assassin4", 15, 19, false)
            };
        }

        public override void BalanceChange(Player player, Assassin assassin)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"Skip to skip. Give money in the range of [{assassin.MinReward}, {assassin.MaxReward}]");
            if (player.Balance < assassin.MinReward)
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
                if (input < assassin.MinReward || input > assassin.MaxReward)
                {
                    Console.WriteLine("Incorrect input! Try again");
                }
                else if (input > player.Balance){
                    Console.WriteLine("Incorrect data! Try again");
                }
                else
                {
                    player.Balance -= input;
                    validInput = true;
                }
            } while (validInput==false);
        }
    }
}
