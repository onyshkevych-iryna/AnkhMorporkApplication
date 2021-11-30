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

        public void GetMoney(decimal amount, ref bool validOutput)
        {
            this.Balance += amount;
            validOutput = true;
        }

        public void GiveMoney(decimal amount, ref bool validOutput)
        {
            this.Balance -= amount;
            validOutput = true;
            if (this.Balance <= 0)
            {
                IsAlive = false;
                ConsoleColorChanger.ChangeColor("You don't have enough money! Game is over.",ConsoleColor.Red);
            }
        }

        public bool IsOutOfMoney(decimal input)
        {
            if (Balance >= input)
            {
                return false;
            }
            ConsoleColorChanger.ChangeColor("You don't have enough money! Game is over.", ConsoleColor.Red);
            IsAlive = false;
            return true;
        }

        public bool EnteredSumIsCorrect(decimal input)
        {
            if (Balance >= input)
            {
                return true;
            }
            Console.WriteLine("You don't have that sum of money! Please, try again:");
            return false;
        }

        public void Skip(Type enemy)
        {
            switch (enemy)
            {
                case var _ when (enemy.Equals(typeof(Thief))|| enemy.Equals(typeof(List<Assassin>))):
                    IsAlive = false;
                    ConsoleColorChanger.ChangeColor("You're killed! Game is over.", ConsoleColor.Red);
                    break;
                case var _ when enemy.Equals(typeof(Beggar)):
                    IsAlive = false;
                    ConsoleColorChanger.ChangeColor("You're chased to death! Game is over.",ConsoleColor.Red);
                    break;
                case var _ when enemy.Equals(typeof(Fool)):
                    ConsoleColorChanger.ChangeColor("You rejected the offer.",ConsoleColor.Red);
                    break;
            }
        }

        public override string ToString()
        {
            return $"\nYour current balance: {CurrencyConverter.Convert(this.Balance)}\n";
        }
    }
}
