
namespace AnkhMorporkApp
{
    public class Assassin
    {
        public string Name { get; set; }
        public decimal MinReward { get; set; }
        public decimal MaxReward { get; set; }
        public bool IsOccupied { get; set; }

        public Assassin(string name, decimal minReward, decimal maxReward, bool isOccupied)
        {
            this.Name = name;
            this.MinReward = minReward;
            this.MaxReward = maxReward;
            this.IsOccupied = isOccupied;
        }
    }
}
