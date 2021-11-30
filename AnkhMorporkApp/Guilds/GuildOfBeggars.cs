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
            string input = null;
            decimal amount = 0;
            if (beggar.Fee != 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You came across a beggar!");
                if (beggar.Fee<1)
                    Console.Write($"To pay him {CurrencyConverter.ConvertCurrency(beggar.Fee)} pennies - enter \"yes\".");
                else
                    Console.Write($"To pay him {beggar.Fee} AM$ - enter \"yes\".");
                Console.WriteLine(" To skip - enter \"no\".");
                Console.ForegroundColor = ConsoleColor.White;
                if (player.IsOutOfMoney(beggar.Fee))
                    return;
                var validInput = false;
                do
                {
                    input = Console.ReadLine();
                    if (input == "no")
                    {
                        player.Skip(beggar.GetType());
                        return;
                    }
                    if (input == "yes")
                        player.GiveMoney(beggar.Fee, ref validInput);
                    else
                    {
                        Console.WriteLine("Incorrect data! Please, try again:");
                        continue;
                    }
                } while (!validInput);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You met people with placards saying: \"Why lie? I need a beer\".");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
