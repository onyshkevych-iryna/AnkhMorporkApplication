
namespace AnkhMorporkApp
{
    public class Assassin
    {
        public string Name { get; set; }
        public double MinReward { get; set; }
        public double MaxReward { get; set; }
        public bool IsOccupied { get; set; }

        public Assassin(string name, double minReward, double maxReward, bool isOccupied)
        {
            this.Name = name;
            this.MinReward = minReward;
            this.MaxReward = maxReward;
            this.IsOccupied = isOccupied;
        }
    }
}
