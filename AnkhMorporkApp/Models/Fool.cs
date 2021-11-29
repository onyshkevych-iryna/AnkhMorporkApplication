namespace AnkhMorporkApp
{
    public class Fool 
    {
        public string Practice { get; private set; }
        public decimal Fee { get; private set; }

        public Fool(string practice, decimal fee)
        {
            this.Practice = practice;
            this.Fee = fee;
        }
    }
}
