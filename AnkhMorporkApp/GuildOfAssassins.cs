using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

namespace AnkhMorporkApp
{
    public class GuildOfAssassins :Guilds
    {
        public List<Assassin> assassins;

        public GuildOfAssassins()
        {
            assassins = new List<Assassin>();
            Assassin assassin1 = new Assassin("Assassin1", 15, 30, true);
            Assassin assassin2= new Assassin("Assassin2", 10, 20, false);
            Assassin assassin3 = new Assassin("Assassin3", 7, 12, true);
            Assassin assassin4 = new Assassin("Assassin4", 15, 19, false);

            assassins.Add(assassin1);
            assassins.Add(assassin2);
            assassins.Add(assassin3);
            assassins.Add(assassin4);
        }

        public void AssassinGetMoney(Assassin assassin, Player player)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"Skip to skip. Give money in the range of [{assassin.MinReward}, {assassin.MaxReward}]");
            if (player.Balance < assassin.MinReward)
            {
                Console.WriteLine("You don't have enough money!");
                player.IsAlive = false;
                return;
            }
            bool validInput = false;
            do
            {
                number = Console.ReadLine();
                if (number == "skip")
                {
                    Console.WriteLine("Game is over. You're killed");
                    return;
                }
                input = Double.Parse(number);
                if (input < assassin.MinReward || input > assassin.MaxReward)
                {
                    Console.WriteLine("Incorrect input! Try again");
                    break;
                }
                if (input > player.Balance){
                    Console.WriteLine("Incorrect data! Try again");
                    break;
                }
                player.Balance -= input;
                validInput = true;
            } while (validInput==false);
        }
    }
}
