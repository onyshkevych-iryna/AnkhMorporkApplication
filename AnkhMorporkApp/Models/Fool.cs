
namespace AnkhMorporkApp
{
    public class Fool 
    {
        public string Practice { get; set; }
        public double Fee { get; set; }

        public Fool(string practice, double fee)
        {
            this.Practice = practice;
            this.Fee = fee;
        }

        public Fool()
        {
        }
    }
}
