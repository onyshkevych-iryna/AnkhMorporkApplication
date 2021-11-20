using System;
using System.Collections.Generic;
using System.Text;

namespace AnkhMorporkApp
{
    public class GuildOfBeggars
    {
        public Dictionary<string, double> beggars;

        public GuildOfBeggars()
        {
            beggars = new Dictionary<string, double>();
            beggars.Add("Twitchers", 3);
            beggars.Add("Droolers", 2);
            beggars.Add("Dribblers", 1);
            beggars.Add("Mumblers", 1);
            beggars.Add("Mutterers", 0.9);
            beggars.Add("Walking-Along-Shouter", 0.8);
            beggars.Add("Demanders of a Chip", 0.6);
            beggars.Add("People Who Call Other People Jimmy", 0.5);
            beggars.Add("People Who Need Eightpence For A Meal", 0.08);
            beggars.Add("People Who Need Tuppence For A Cup Of Tea", 0.02);
            beggars.Add("People With Placards Saying \"Why lie ? I need a beer\"", 0);
        }

        public void BeggarGetMoney(Player player, Beggar beggar)
        {
            string number = null;
            double input = 0;
            Console.WriteLine($"Skip to skip. Give sum of {beggar.Fee}");
            if (player.Balance < beggar.Fee)
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
                    Console.WriteLine("Game is over. You're chased to death");
                    player.IsAlive = false;
                    return;
                }
                input = Double.Parse(number);
                if (input != beggar.Fee)
                {
                    Console.WriteLine("Incorrect input! Try again");
                    break;
                }
                if (input > player.Balance)
                {
                    Console.WriteLine("Incorrect data! Try again");
                    break;
                }
                player.Balance -= input;
                validInput = true;
            } while (validInput == false);
        }
    }
}
