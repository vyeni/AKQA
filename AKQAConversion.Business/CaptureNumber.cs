using System;

namespace AKQAConversion.Business
{
    /// <summary>
    /// Accepts number input and returns value in dollar and cents
    /// </summary>
    public class CaptureNumber:ICaptureNumber
    {
        public IConversion _conversion;
        public CaptureNumber(IConversion conversion)
        {
            this._conversion = conversion;
        }

        public string GetWords(double number)
        {
            string dollarValue=null;
            string centsValue = null ;
            
            String[] arr = number.ToString().Split('.');
            if (arr[0] != null)
            {
                dollarValue = _conversion.NumberToString((Convert.ToInt32(arr[0]))).Trim();
                dollarValue = dollarValue == "one" ? dollarValue + " dollar" : dollarValue + " dollars";
            }
            if (arr.Length == 2)
            {
                centsValue = _conversion.NumberToString((Convert.ToInt32(arr[1])));
                centsValue = centsValue == "one" ? centsValue + " cent" : centsValue + " cents";
                return dollarValue == null ? centsValue : dollarValue + " and " + centsValue;
            }
            else if (arr.Length == 1)
            {
                return dollarValue;
            }
            else
                return "no amount found";
        }
    }
}