namespace HomeService_front.Helpers
{
    public class FormatterHelper
    {
        public static string CapitalizeFirstLetter(string str)
            => char.ToUpper(str[0]) + str.Substring(1);

        public static string GetFormatedDate(DateTime date)
        => date.ToString().Substring(0, 10);


    }
}
