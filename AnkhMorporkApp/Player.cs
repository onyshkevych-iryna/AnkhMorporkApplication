using System;

namespace AnkhMorporkApp
{
    public class Player
    {
        public double Balance { get; set; } = 100;
        public bool IsAlive { get; set; } = true;

        public Player()
        {
        }

        public Player(double balance)
        {
            this.Balance = balance;
        }

        public void GetMoney(double amount)
        {
            this.Balance = this.Balance + amount;
        }

        public void GiveMoney(double amount)
        {
            if(amount> this.Balance)
                Console.WriteLine("Incorrect data!");
            this.Balance = this.Balance - amount;
        }

        public bool IsMoneyEnough(double input)
        {
            if (Balance < input)
            {
                Console.WriteLine("You don't have enough money!");
                IsAlive = false;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Skip(string number)
        {
            if (number == "s")
            {
                Console.WriteLine("Game is over. You're killed");
                IsAlive = false;
                return true;
            }

            return false;
        }

        public void Play()
        {
        }

        public override string ToString()
        {
            return $"Current balance {this.Balance}";
        }
    }
}
