namespace AnkhMorporkApp
{
    public abstract class Guilds <T>
    {
        public Guilds()
        {
        }
        public abstract void BalanceChange(Player player, T guildMember);
    }
}
