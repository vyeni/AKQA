using System;
using System.Collections.Generic;
using System.Text;

namespace AKQAConversion.Business
{
    /// <summary>
    /// Interface to capture number and return dollar and cents value
    /// </summary>
    public interface ICaptureNumber
    {
         string GetWords(double number);
    }
}
