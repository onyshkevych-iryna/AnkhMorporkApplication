using System;

namespace AnkhMorporkApp
{
    public class Player
    {
        public decimal Balance { get; set; } = 100;
        public bool IsAlive { get; set; } = true;

        public Player()
        {
        }

        public Player(decimal balance)
        {
            this.Balance = balance;
        }

        public void GetMoney(decimal amount, ref bool validoutput)
        {
            this.Balance += amount;
            validoutput = true;
        }

        public void GiveMoney(decimal amount, ref bool validoutput)
        {
            this.Balance -= amount;
            validoutput = true;
            if (this.Balance <= 0)
            {
                IsAlive = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have enough money! Game is over.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public bool IsOutOfMoney(decimal input)
        {
            if (Balance < input)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have enough money! Game is over.");
                Console.ForegroundColor = ConsoleColor.White;
                IsAlive = false;
                return true;
            }
            return false;
        }

        public bool EnteredSumIsCorrect(decimal input)
        {
            if (Balance < input)
            {
                Console.WriteLine("You don't have that sum of money! Please, try again:");
                return false;
            }
            return true;
        }

        public void Skip<T>(T enemy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if ((enemy is Assassin) || (enemy is Thief))
            {
                IsAlive = false;
                Console.WriteLine("You're killed! Game is over.");
            }
            else if (enemy is Beggar)
            {
                IsAlive = false;
                Console.WriteLine("You're chased to death! Game is over.");
            }
            else if (enemy is Fool)
                Console.WriteLine("You rejected the offer.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override string ToString()
        {
            return $"\nYour current balance: {this.Balance}\n";
        }
    }
}
