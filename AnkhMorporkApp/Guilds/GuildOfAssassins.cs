using System;
using System.Collections.Generic;
using System.Linq;
using AnkhMorporkApp.Properties;
using Newtonsoft.Json;

namespace AnkhMorporkApp
{
    public class GuildOfAssassins : Guilds<List<Assassin>>
    {
        public List<Assassin> Assassins;

        public GuildOfAssassins()
        {
            try{
                var assassinsData = System.Text.Encoding.Default.GetString(Resources.listOfAssassins);
                Assassins = JsonConvert.DeserializeObject<List<Assassin>>(assassinsData);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        
        public override void InteractionWithPlayer(Player player, List<Assassin> assassins)
        {
            ConsoleColorChanger.ChangeColor("Someone wants to kill you!\nEnter sum of money to make a contract with an assassin. Or enter \"no\" to skip.", ConsoleColor.Green);
            var validInput = false;
            do
            {
                var input = Console.ReadLine();
                if (input == "no")
                {
                    player.Skip(typeof(Assassin));
                    return;
                }
                if (!Decimal.TryParse(input, out var amount))
                {
                    Console.WriteLine("Incorrect data! Try again:");
                    continue;
                }
                if (!player.EnteredSumIsCorrect(amount))
                {
                    continue;
                }
                var assassin = assassins
                    .Select(ass => ass)
                    .FirstOrDefault(ass => ass.MinReward <= amount && ass.MaxReward >= amount && !ass.IsOccupied);
                if (assassin is not null)
                {
                    Console.WriteLine($"Assassin \"{assassin.Name}\" made a contract with you!");
                    player.GiveMoney(amount, ref validInput);
                }
                else
                {
                    ConsoleColorChanger.ChangeColor("There is no opportunity to make a contract! Game is over", ConsoleColor.Red);
                    player.IsAlive = false;
                    return;
                }
            } while (!validInput);
        }
    }
}
