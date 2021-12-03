namespace AnkhMorporkApp
{
    public static class CurrencyConverter
    {
        public static string Convert(decimal AMDollar)
        {
            return AMDollar >= 1 ? $"{(AMDollar)} AM$" : $"{(int) (AMDollar * 100)} pennies";
        }
    }
}
