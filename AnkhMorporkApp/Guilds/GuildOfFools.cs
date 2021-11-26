using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
                var foolsData = FileReader.GetText("listOfFools.json");
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
            Console.WriteLine($"Enter \'s\' to skip or \'j\' to join. You'll earn sum of {fool.Fee}");
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
