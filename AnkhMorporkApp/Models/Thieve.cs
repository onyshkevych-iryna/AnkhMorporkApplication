namespace AnkhMorporkApp
{
    public class Thieve
    {
        public decimal Fee { get; set; } = 10;

        public Thieve(decimal fee)
        {
            this.Fee = fee;
        }

        public Thieve()
        {
        }
    }
}
