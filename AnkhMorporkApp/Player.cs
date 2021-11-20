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

        public void Skip()
        {
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
