using System;
using System.Collections.Generic;

namespace AnkhMorporkApp
{
    public class GuildOfAssassins :Guilds<List<Assassin>>
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

        public override void BalanceChange(Player player, List<Assassin> assassins)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"Enter 's' to skip. Or input sum of money to make a contract");
            var validInput = false;
            do
            {
                number = Console.ReadLine();
                if (number == "s")
                {
                    player.Skip(number, assassins);
                    return;
                }
                if (!Double.TryParse(number, out double result))
                {
                    Console.WriteLine("Incorrect data! Try again:");
                    continue;
                }
                input = Double.Parse(number);
                if (!player.EnteredSumIsCorrect(input))
                    continue;
                var count =0;
                foreach (Assassin ass in assassins)
                {
                    if (input >= ass.MinReward && input <= ass.MaxReward && (ass.IsOccupied))
                    {
                        Console.WriteLine($"{ass.Name} make a contract with you!");
                        player.GiveMoney(input, ref validInput);
                        count++;
                        break;
                    }
                }
                if (count == 0)
                {
                    Console.WriteLine("There is no opportunity to make a contract! Game is over");
                    player.IsAlive = false;
                    return;
                }
            } while (!validInput);
        }
    }
}
