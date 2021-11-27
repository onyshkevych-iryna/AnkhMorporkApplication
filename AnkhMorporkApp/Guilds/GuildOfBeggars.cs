using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AnkhMorporkApp
{
    public class GuildOfBeggars : Guilds<Beggar>
    {
        public Dictionary<int, Beggar> beggars;
        
        public GuildOfBeggars()
        {
            try
            {
                FileService fileService = new FileService();
                var beggarsData = fileService.GetText("listOfBeggars.json");
                beggars = JsonConvert.DeserializeObject<Dictionary<int, Beggar>>(beggarsData);
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
                Console.WriteLine($"You came across a beggar!\nEnter 's' to skip. Or give {beggar.Fee} AM$.");
                Console.ForegroundColor = ConsoleColor.White;
                if (player.IsOutOfMoney(beggar.Fee))
                    return;
                var validInput = false;
                do
                {
                    input = Console.ReadLine();
                    if (input == "s")
                    {
                        player.Skip(beggar);
                        return;
                    }
                    if (!Decimal.TryParse(input, out decimal result))
                    {
                        Console.WriteLine("Incorrect data! Please, try again:");
                        continue;
                    }
                    amount = Decimal.Parse(input);
                    if (amount != beggar.Fee)
                        Console.WriteLine($"The amount isn't equal to {beggar.Fee}! Please, try again:");
                    else if (!player.EnteredSumIsCorrect(amount))
                        return;
                    else
                        player.GiveMoney(amount, ref validInput);
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
