using System;
using System.Collections.Generic;
using AnkhMorporkApp.Abstracts;
using Newtonsoft.Json;

namespace AnkhMorporkApp
{
    public class GuildOfAssassins :Guilds<List<Assassin>>
    {
        public List<Assassin> assassins;

        public GuildOfAssassins(IFileService fileService)
        {
            try
            {
                var assassinsData = fileService.GetText("listOfAssassins.json");
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
            decimal input = 0;
            Console.WriteLine($"Someone wants to kill you!\nEnter 's' to skip. Or enter sum of money to make a contract with an assassin.");
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
                input = Decimal.Parse(number);
                if (!player.EnteredSumIsCorrect(input))
                    continue;
                var contractWasMade = false;
                foreach (Assassin ass in assassins)
                {
                    if (input >= ass.MinReward && input <= ass.MaxReward && (ass.IsOccupied))
                    {
                        Console.WriteLine($"Assassin \"{ass.Name}\" made a contract with you!");
                        player.GiveMoney(input, ref validInput);
                        contractWasMade = true;
                        break;
                    }
                }
                if (contractWasMade == false)
                {
                    Console.WriteLine("There is no opportunity to make a contract! Game is over");
                    player.IsAlive = false;
                    return;
                }
            } while (!validInput);
        }
    }
}
