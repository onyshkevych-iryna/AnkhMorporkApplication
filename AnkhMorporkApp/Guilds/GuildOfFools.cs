using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AnkhMorporkApp
{
    public class GuildOfFools : Guilds<Fool>
    {
        public Dictionary<int, Fool> Fools;

        public GuildOfFools()
        {
            try
            {
                FileService fileService = new FileService();
                var foolsData = fileService.GetText("listOfFools.json");
                Fools = JsonConvert.DeserializeObject<Dictionary<int, Fool>>(foolsData);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public override void InteractionWithPlayer(Player player, Fool fool)
        {
            ConsoleColorChanger.ChangeColor($"You came across a friend!\nTo join their offer to work as {fool.Practice} " +
                                                     $"and earn {CurrencyConverter.Convert(fool.Fee)} - enter \"yes\". To skip - enter \"no\".",ConsoleColor.Green);
            var validInput = false;
            do
            {
                var input = Console.ReadLine();
                if (input == "yes")
                {
                    player.GetMoney(fool.Fee, ref validInput);
                }
                else if (input == "no")
                {
                    player.Skip(fool.GetType());
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please, try again:");
                }
            } while (!validInput);
        }
    }
}
