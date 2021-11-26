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

        public override void BalanceChange(Player player, Beggar beggar)
        {
            string number = null;
            decimal input = 0;
            Console.WriteLine($"You came across a beggar!\nEnter 's' to skip. Or give sum of {beggar.Fee}");
            if (player.IsOutOfMoney(beggar.Fee))
                return;
            var validInput = false;
            do
            {
                number = Console.ReadLine();
                if (number == "s")
                {
                    player.Skip(beggar);
                    return;
                }
                if (!Decimal.TryParse(number, out decimal result))
                {
                    Console.WriteLine("Incorrect data! Please, try again:");
                    continue;
                }
                input = Decimal.Parse(number);
                if (input != beggar.Fee)
                    Console.WriteLine($"The amount isn't equal {beggar.Fee}! Please, try again:");
                else if (!player.EnteredSumIsCorrect(input))
                    return;
                else
                    player.GiveMoney(input, ref validInput);
            } while (!validInput);
        }
    }
}
