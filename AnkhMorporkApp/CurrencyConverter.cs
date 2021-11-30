namespace AnkhMorporkApp
{
    public static class CurrencyConverter
    {
        public static decimal ConvertCurrency(decimal AMDollar)
        {
            return AMDollar * 100;
        }
    }
}
