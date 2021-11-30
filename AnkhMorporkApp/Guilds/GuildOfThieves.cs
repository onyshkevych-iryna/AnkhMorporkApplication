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
            ConsoleColorChanger.ChangeColor($"You came across a thieve!\nTo pay him {CurrencyConverter.Convert(thief.Fee)} - enter \"yes\". To skip - enter \"no\".",ConsoleColor.Green);
            if (player.IsOutOfMoney(thief.Fee))
            {
                return;
            }
            var validInput = false;
            do
            {
                var input = Console.ReadLine();
                if (input == "yes")
                {
                    player.GiveMoney(thief.Fee, ref validInput);
                }
                else if (input == "no")
                {
                    player.Skip(thief.GetType());
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect data! Please, try again:");
                }
            } while (!validInput);
        }
    }
}
