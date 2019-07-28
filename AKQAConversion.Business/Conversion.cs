using Utility;
namespace AKQAConversion.Business
{
    /// <summary>
    /// converts the number to word equivalent using third party Utility dll.
    /// </summary>
    public class Conversion : IConversion
    {
        public string NumberToString(int number)
        {
            var x = Converter.NumberToWords(number);
            return x;
        }
    }
}
