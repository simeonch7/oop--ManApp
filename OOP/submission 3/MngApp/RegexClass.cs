using System.Text.RegularExpressions;

namespace MngApp
{
    static public class RegexClass
    {
        static public readonly Regex rgxName = new Regex(@"[A-Z][a-zA-Z][^?!#&<>\~;$^%{}?123456789]{1,20}$");
        static public readonly Regex rgxSalary = new Regex(@"^\d+$");
        static public readonly Regex rgxLevel = new Regex(@"^\d$");

        /*static public Regex RgxSalary
        {
            get => rgxSalary;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new ArgumentException("Regex cannot be null or empty");
            }
        }

        static public Regex RgxName
        {
            get => rgxName;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new ArgumentException("Regex cannot be null or empty");
            }
        }

        static public Regex RgxLevel
        {
            get => rgxLevel;
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    throw new ArgumentException("Regex cannot be null or empty");
            }
        }*/
    }
}
