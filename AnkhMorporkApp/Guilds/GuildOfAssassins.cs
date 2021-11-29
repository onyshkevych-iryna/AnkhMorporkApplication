using System;
using System.Collections.Generic;
using AnkhMorporkApp.Abstracts;
using Newtonsoft.Json;

namespace AnkhMorporkApp
{
    public class GuildOfAssassins : Guilds<List<Assassin>>
    {
        public List<Assassin> Assassins;

        public GuildOfAssassins(IFileService fileService)
        {
            try
            {
                var assassinsData = fileService.GetText("listOfAssassins.json");
                Assassins = JsonConvert.DeserializeObject<List<Assassin>>(assassinsData);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        
        public override void InteractionWithPlayer(Player player, List<Assassin> assassins)
        {
            string input = null;
            decimal amount = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Someone wants to kill you!\nEnter 's' to skip. Or enter sum of money to make a contract with an assassin.");
            Console.ForegroundColor = ConsoleColor.White;
            var validInput = false;
            do
            {
                input = Console.ReadLine();
                if (input == "s")
                {
                    player.Skip(assassins);
                    return;
                }
                if (!Double.TryParse(input, out double result))
                {
                    Console.WriteLine("Incorrect data! Try again:");
                    continue;
                }
                amount = Decimal.Parse(input);
                if (!player.EnteredSumIsCorrect(amount))
                    continue;
                var contractWasMade = false;
                foreach (Assassin ass in assassins)
                {
                    if (amount >= ass.MinReward && amount <= ass.MaxReward && (!ass.IsOccupied))
                    {
                        Console.WriteLine($"Assassin \"{ass.Name}\" made a contract with you!");
                        player.GiveMoney(amount, ref validInput);
                        contractWasMade = true;
                        break;
                    }
                }
                if (contractWasMade == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no opportunity to make a contract! Game is over");
                    Console.ForegroundColor = ConsoleColor.White;
                    player.IsAlive = false;
                    return;
                }
            } while (!validInput);
        }
    }
}
