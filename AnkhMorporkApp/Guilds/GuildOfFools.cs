using System;
using System.Collections.Generic;
using AnkhMorporkApp.Properties;
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
                var foolsData = System.Text.Encoding.Default.GetString(Resources.listOfFools);
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
                switch (input)
                {
                    case "yes":
                        player.GetMoney(fool.Fee, ref validInput);
                        break;
                    case "no":
                        player.Skip(fool.GetType());
                        validInput = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input! Please, try again:");
                        break;
                }
            } while (!validInput);
        }
    }
}
