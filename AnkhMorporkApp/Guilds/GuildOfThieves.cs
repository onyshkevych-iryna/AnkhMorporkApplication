using System;
using System.Collections.Generic;

namespace AnkhMorporkApp
{
    public class GuildOfThieves : Guilds<Thief>
    {
        public static int NumberOfThieves = 6;
        public List<Thief> Theves;

        public GuildOfThieves()
        {
            Theves = new List<Thief>();
        }

        public override void InteractionWithPlayer(Player player, Thief thief)
        {
            string input = null;
            decimal amount = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You came across a thieve!\nTo pay him {thief.Fee} AM$ - enter \"yes\". To skip - enter \"no");
            Console.ForegroundColor = ConsoleColor.White;
            if (player.IsOutOfMoney(thief.Fee))
                return;
            var validInput = false;
            do
            {
                input = Console.ReadLine();
                if (input == "no")
                {
                    player.Skip(thief);
                    return;
                }
                if (input == "yes")
                {
                    player.GiveMoney(thief.Fee, ref validInput);
                }
                else
                {
                    Console.WriteLine("Incorrect data! Please, try again:");
                }
            } while (!validInput);
        }
    }
}
