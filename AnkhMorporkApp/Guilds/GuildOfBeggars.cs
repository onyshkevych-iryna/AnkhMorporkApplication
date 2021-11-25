using System;
using System.Collections.Generic;

namespace AnkhMorporkApp
{
    public class GuildOfBeggars : Guilds<Beggar>
    {
        public Dictionary<int, Beggar> beggars;

        public GuildOfBeggars()
        {
            beggars = new Dictionary<int, Beggar>()
            {
                { 1, new Beggar( "Twitchers", 3 )},
                { 2, new Beggar("Droolers", 2 )},
                { 3, new Beggar("Dribblers", 1 )},
                { 4, new Beggar("Mumblers", 1 )},
                { 5, new Beggar("Mutterers", 0.9 )},
                { 6, new Beggar("Walking-Along-Shouter", 0.8 )},
                { 7, new Beggar("Demanders of a Chip", 0.6 )},
                { 8, new Beggar("People Who Call Other People Jimmy", 0.5 )},
                { 9, new Beggar("People Who Need Eightpence For A Meal", 0.08 )},
                { 10,new Beggar( "People Who Need Tuppence For A Cup Of Tea", 0.02)},
                { 11,new Beggar("People Who Need Tuppence For A Cup Of Tea", 0.02 )}
            };
        }

        public override void BalanceChange(Player player, Beggar beggar)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"Enter 's' to skip. Or give sum of {beggar.Fee}");
            if (player.IsOutOfMoney(beggar.Fee))
                return;
            var validInput = false;
            do
            {
                number = Console.ReadLine();
                if (number == "s")
                {
                    player.Skip(number, beggar);
                    return;
                }
                if (!Double.TryParse(number, out double result))
                {
                    Console.WriteLine("Incorrect data! Please, try again:");
                    continue;
                }
                input = Double.Parse(number);
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
