using System;
using System.Collections.Generic;

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

        public void Skip(Type enemy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            switch (enemy)
            {
                case var _ when (enemy.Equals(typeof(Thief))|| enemy.Equals(typeof(List<Assassin>))):
                    IsAlive = false;
                    Console.WriteLine("You're killed! Game is over.");
                    break;
                case var _ when enemy.Equals(typeof(Beggar)):
                    IsAlive = false;
                    Console.WriteLine("You're chased to death! Game is over.");
                    break;
                case var _ when enemy.Equals(typeof(Fool)):
                    Console.WriteLine("You rejected the offer.");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override string ToString()
        {
            if(this.Balance>=1)
                return $"\nYour current balance: {this.Balance} AM$ \n"; 
            return $"\nYour current balance: {CurrencyConverter.ConvertCurrency(this.Balance)} pennies\n";
        }
    }
}
