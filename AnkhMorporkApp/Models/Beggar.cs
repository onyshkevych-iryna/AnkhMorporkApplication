
namespace AnkhMorporkApp
{
    public class Beggar
    {
        public string Practice { get; set; }
        public decimal Fee { get; set; }

        public Beggar(string practice, decimal fee)
        {
            this.Practice = practice;
            this.Fee = fee;
        }

        public Beggar()
        {
        }
    }
}
