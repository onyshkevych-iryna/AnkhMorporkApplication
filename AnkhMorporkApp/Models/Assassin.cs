
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
            Name = name;
            MinReward = minReward;
            MaxReward = maxReward;
            IsOccupied = isOccupied;
        }
    }
}
