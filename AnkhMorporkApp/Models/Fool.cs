namespace AnkhMorporkApp
{
    public class Fool 
    {
        public string Practice { get; }
        public decimal Fee { get; }

        public Fool(string practice, decimal fee)
        {
            this.Practice = practice;
            this.Fee = fee;
        }
    }
}
