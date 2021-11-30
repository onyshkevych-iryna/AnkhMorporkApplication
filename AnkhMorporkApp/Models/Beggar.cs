namespace AnkhMorporkApp
{
    public class Beggar
    {
        public string Practice { get; }
        public decimal Fee { get; }

        public Beggar(string practice, decimal fee)
        {
            this.Practice = practice;
            this.Fee = fee;
        }
    }
}
