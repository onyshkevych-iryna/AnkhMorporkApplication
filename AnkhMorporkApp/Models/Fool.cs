
namespace AnkhMorporkApp
{
    public class Fool : GuildOfFools
    {
        public string Practice { get; set; }
        public double Fee { get; set; }

        public Fool(string practice, double fee)
        {
            Practice = practice;
            Fee = fee;
        }

        public Fool()
        {
        }
    }
}
