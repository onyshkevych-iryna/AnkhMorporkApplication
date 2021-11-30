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
            string input = null;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You came across a friend!\nTo join their offer to work as {fool.Practice} and earn {fool.Fee} AM$ - enter \"yes\". To skip - enter \"no\".");
            Console.ForegroundColor = ConsoleColor.White;
            var validInput = false;
            do
            {
                input = Console.ReadLine();
                if (input == "no")
                {
                    player.Skip(fool);
                    validInput = true;
                }
                else if (input == "yes")
                    player.GetMoney(fool.Fee, ref validInput);
                else
                    Console.WriteLine("Invalid input! Please, try again:");
            } while (!validInput);
        }
    }
}
