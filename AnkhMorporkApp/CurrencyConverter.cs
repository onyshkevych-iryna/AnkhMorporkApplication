namespace AnkhMorporkApp
{
    public static class CurrencyConverter
    {
        public static string Convert(decimal AMDollar)
        {
            if (AMDollar >= 1)
            {
                return $"{AMDollar} AM$";
            }
            return $"{AMDollar*100} pennies";
        }
    }
}
