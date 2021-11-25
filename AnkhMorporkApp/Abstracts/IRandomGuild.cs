using System;

namespace AnkhMorporkApp
{
    interface IRandomGuild
    {
        public void Assassins(Player player);
        public void Theves(Random rnd, Player player);
        public void Fools(Random rnd, Player player);
        public void Beggars(Random rnd, Player player);
    }
}
