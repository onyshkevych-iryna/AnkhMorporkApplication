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

        public void GetMoney(double amount, ref bool validoutput)
        {
            this.Balance += amount;
            validoutput = true;
        }

        public void GiveMoney(double amount, ref bool validoutput)
        {
            this.Balance -= amount;
            validoutput = true;
        }

        public bool IsMoneyEnough(double input)
        {
            if (Balance < input)
            {
                Console.WriteLine("You don't have enough money!");
                IsAlive = false;
                return false;
            }
            return true;
        }

        public bool Skip<T>(string number, T enemy)
        {
            if ((number == "s"))
            {
                if ((enemy is Assassin) || (enemy is Thieve))
                {
                    IsAlive = false;
                    Console.WriteLine("Game is over. You're killed");
                }
                else if (enemy is Beggar)
                {
                    IsAlive = false;
                    Console.WriteLine("Game is over. You're chased to death");
                }
                else if (enemy is Fool) 
                    Console.WriteLine("You skipped that fool");
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Current balance {this.Balance}";
        }
    }
}
