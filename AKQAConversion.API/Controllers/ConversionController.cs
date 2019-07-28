using System;
using AKQAConversion.Business;
using AKQAConversion.Model;
using Microsoft.AspNetCore.Mvc;

namespace AKQAConversion.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Conversion")]
    public class ConversionController : Controller
    {
        /// <summary>
        /// Interface for capture number method
        /// </summary>
        private  ICaptureNumber _iCaptureNumber;

        /// <summary>
        /// DI to assign interface 
        /// </summary>
        /// <param name="iCaptureNumber">iCaptureNumber input</param>
        public ConversionController(ICaptureNumber iCaptureNumber)
        {
            this._iCaptureNumber = iCaptureNumber;
        }


        // GET: api/Conversion/
        [HttpGet("{firstname}/{lastname}/{amount}")]
        public User Get(string firstname, string lastname, string amount)
        {
            try
            {
                double amt = Convert.ToDouble(amount);
                return new User
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Amount = amt,
                    AmountinText = this._iCaptureNumber.GetWords(amt)
                };
            }catch (Exception ex)
            {
                throw ex;
            }
        }
   
    }
}
