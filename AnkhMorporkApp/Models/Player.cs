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
                Console.WriteLine("You don't have enough money! Game is over.");
            }
        }

        public bool IsOutOfMoney(decimal input)
        {
            if (Balance < input)
            {
                Console.WriteLine("You don't have enough money! Game is over.");
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
            if ((enemy is Assassin) || (enemy is Thieve))
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
                Console.WriteLine("You skipped that fool!");
        }

        public override string ToString()
        {
            return $"\nYour current balance: {this.Balance}\n";
        }
    }
}
