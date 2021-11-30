using System;

namespace AnkhMorporkApp
{
    public static class ConsoleColorChanger
    {
        public static void ChangeColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
