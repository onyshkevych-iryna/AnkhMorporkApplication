namespace AnkhMorporkApp
{
    public class Beggar
    {
        public string Practice { get; private set; }
        public decimal Fee { get; private set; }

        public Beggar(string practice, decimal fee)
        {
            this.Practice = practice;
            this.Fee = fee;
        }
    }
}
