using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AnkhMorporkApp
{
    public class Game<T>
    {
        public void BalanceChange(Player p, T assassin1)
        {
            string number = null;
            //double input = 0;
            //if (assassin1 is Assassin)
            //{
            //    Console.WriteLine("Yes");
            //}
            //else
            //{
            //    Console.WriteLine("no");
            //}
            //if (assassin1 is Assassin)
            //{
            //    var assassin = assassin1 as Assassin;
            //    Console.WriteLine(
            //        $"Enter \"s\" to skip. Or give money in the range of [{assassin.MinReward}, {assassin.MaxReward}]");
            //    if (p.Balance < assassin.MinReward)
            //    {
            //        Console.WriteLine("You don't have enough money!");
            //        p.IsAlive = false;
            //        return;
            //    }

            //    var validInput = false;
            //    do
            //    {
            //        number = Console.ReadLine();
            //        if (number == "s")
            //        {
            //            Console.WriteLine("Game is over. You're killed");
            //            p.IsAlive = false;
            //            return;
            //        }

            //        if (!Double.TryParse(number, out double result))
            //        {
            //            Console.WriteLine("There is no such command! Please, try again");
            //        }

            //        else if (input < assassin.MinReward || input > assassin.MaxReward)
            //        {
            //            Console.WriteLine("Incorrect input! Try again");
            //        }
            //        else if (input > p.Balance)
            //        {
            //            Console.WriteLine("Incorrect data! Try again");
            //        }
            //        else
            //        {
            //            p.Balance -= input;
            //            validInput = true;
            //        }
            //    } while (!validInput);
            //}
        }
    }
}
