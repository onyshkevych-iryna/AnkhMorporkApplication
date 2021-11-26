
namespace AnkhMorporkApp
{
    public class Fool 
    {
        public string Practice { get; set; }
        public decimal Fee { get; set; }

        public Fool(string practice, decimal fee)
        {
            this.Practice = practice;
            this.Fee = fee;
        }

        public Fool()
        {
        }
    }
}
