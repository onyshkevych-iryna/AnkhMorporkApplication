namespace AnkhMorporkApp
{
    public class Assassin
    {
        public string Name { get; }
        public decimal MinReward { get; }
        public decimal MaxReward { get; }
        public bool IsOccupied { get; }

        public Assassin(string name, decimal minReward, decimal maxReward, bool isOccupied)
        {
            this.Name = name;
            this.MinReward = minReward;
            this.MaxReward = maxReward;
            this.IsOccupied = isOccupied;
        }
    }
}
