namespace AnkhMorporkApp
{
    public abstract class Guilds <T>
    {
        public Guilds()
        {
        }
        public abstract void InteractionWithPlayer(Player player, T guildMember);
    }
}
