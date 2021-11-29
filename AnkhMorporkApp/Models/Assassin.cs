namespace AnkhMorporkApp
{
    public class Assassin
    {
        public string Name { get; private set; }
        public decimal MinReward { get; private set; }
        public decimal MaxReward { get; private set; }
        public bool IsOccupied { get; private set; }

        public Assassin(string name, decimal minReward, decimal maxReward, bool isOccupied)
        {
            this.Name = name;
            this.MinReward = minReward;
            this.MaxReward = maxReward;
            this.IsOccupied = isOccupied;
        }
    }
}
