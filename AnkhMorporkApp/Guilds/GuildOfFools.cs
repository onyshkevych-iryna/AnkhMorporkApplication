using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AnkhMorporkApp
{
    public class GuildOfFools: Guilds<Fool>
    {
        public Dictionary<int, Fool> fools;

        public GuildOfFools()
        {
            try
            {
                FileService fileService = new FileService();
                var foolsData = fileService.GetText("listOfFools.json");
                fools = JsonConvert.DeserializeObject<Dictionary<int, Fool>>(foolsData);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public override void BalanceChange(Player player, Fool fool)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"You came across a friend!\nEnter \'s\' to skip or \'j\' to join their offer to work as {fool.Practice}. You'll earn sum of {fool.Fee}");
            var validInput = false;
            do
            {
                number = Console.ReadLine();
                if (number == "s")
                {
                    player.Skip(number, fool);
                    validInput = true;
                }
                else if (number == "j")
                    player.GetMoney(fool.Fee, ref validInput);
                else
                    Console.WriteLine("Invalid input! Please, try again:");
            } while (!validInput);
        }
    }
}
