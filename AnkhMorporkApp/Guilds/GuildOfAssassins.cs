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
            decimal amount;
            ConsoleColorChanger.ChangeColor("Someone wants to kill you!\nEnter sum of money to make a contract with an assassin. Or enter \"no\" to skip.",ConsoleColor.Green);
            var validInput = false;
            do
            {
                var input = Console.ReadLine();
                if (input == "no")
                {
                    player.Skip(assassins.GetType());
                    return;
                }
                if (!Decimal.TryParse(input, out amount))
                {
                    Console.WriteLine("Incorrect data! Try again:");
                    continue;
                }
                if (!player.EnteredSumIsCorrect(amount))
                {
                    continue;
                }
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
                    ConsoleColorChanger.ChangeColor("There is no opportunity to make a contract! Game is over",ConsoleColor.Red);
                    player.IsAlive = false;
                    return;
                }
            } while (!validInput);
        }
    }
}
