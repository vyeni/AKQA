using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AKQAConversion.UI.Controllers
{
  /// <summary>
  /// UI app
  /// </summary>
    public class HomeController : Controller
    {
        // Service to access App settings
        IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public IActionResult Index()
        {
            // Sending API url to UI 
            ViewData["API_URL"] = this._configuration.GetSection("AppSettings").GetSection("API_URL").Value;

            return View();
        }

    }
}
