using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AnkhMorporkApp
{
    public class GuildOfBeggars : Guilds<Beggar>
    {
        public Dictionary<int, Beggar> Beggars;

        public GuildOfBeggars()
        {
            try
            {
                FileService fileService = new FileService();
                var beggarsData = fileService.GetText("listOfBeggars.json");
                Beggars = JsonConvert.DeserializeObject<Dictionary<int, Beggar>>(beggarsData);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public override void InteractionWithPlayer(Player player, Beggar beggar)
        {
            if (beggar.Fee != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You came across a beggar! To pay him {CurrencyConverter.Convert(beggar.Fee)} - enter \"yes\".");
                Console.WriteLine(" To skip - enter \"no\".");
                Console.ForegroundColor = ConsoleColor.White;
                if (player.IsOutOfMoney(beggar.Fee))
                {
                    return;
                }
                var validInput = false;
                do
                {
                    var input = Console.ReadLine();
                    if (input == "yes")
                    {
                        player.GiveMoney(beggar.Fee, ref validInput);
                    }
                    else if (input == "no")
                    {
                        player.Skip(beggar.GetType());
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect data! Please, try again:");
                    }
                } while (!validInput);
            }
            else
                ConsoleColourChanger.ChangeColour("You met people with placards saying: \"Why lie? I need a beer\".", ConsoleColor.Yellow);
        }
    }
}
