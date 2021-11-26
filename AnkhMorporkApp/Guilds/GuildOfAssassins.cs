using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace AnkhMorporkApp
{
    public class GuildOfAssassins :Guilds<List<Assassin>>
    {
        public List<Assassin> assassins;

        public GuildOfAssassins()
        {
            try
            {
                var assassinsData = FileReader.GetText("listOfAssassins.json");
                assassins = JsonConvert.DeserializeObject<List<Assassin>>(assassinsData);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
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
                        Console.WriteLine($"{ass.Name} made a contract with you!");
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
