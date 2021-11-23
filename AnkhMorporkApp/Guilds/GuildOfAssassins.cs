using System;
using System.Collections.Generic;

namespace AnkhMorporkApp
{
    public class GuildOfAssassins :Guilds<Assassin>
    {
        public List<Assassin> assassins;

        public GuildOfAssassins()
        {
            assassins = new List<Assassin>()
            {
                new Assassin("Assassin1", 15, 30, true),
                new Assassin("Assassin2", 10, 20, false),
                new Assassin("Assassin3", 7, 12, true),
                new Assassin("Assassin4", 15, 19, false)
            };
        }

        public override void BalanceChange(Player player, Assassin assassin)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"Enter 's' to skip. Or give money in the range of [{assassin.MinReward}, {assassin.MaxReward}]");
            if(!player.IsMoneyEnough(assassin.MinReward))
                return;
            var validInput = false;
            do
            {
                number = Console.ReadLine();
                if(player.Skip(number,assassin)) 
                    return;
                if (!Double.TryParse(number, out double result))
                {
                    Console.WriteLine("Incorrect data! Try again");
                }
                else
                {
                    input = Double.Parse(number);
                    if (input < assassin.MinReward || input > assassin.MaxReward)
                    {
                        Console.WriteLine("Incorrect input! Try again");
                    }
                    else if (input > player.Balance)
                    {
                        Console.WriteLine("Incorrect data! Try again");
                    }
                    else
                    {
                        player.Balance -= input;
                        validInput = true;
                    }
                }
            }
         while (!validInput);
        }
    }
}
