namespace AnkhMorporkApp
{
    public class Thief
    {
        public decimal Fee { get; set; } = 10;

        public Thief(decimal fee)
        {
            this.Fee = fee;
        }

        public Thief()
        {
        }
    }
}
