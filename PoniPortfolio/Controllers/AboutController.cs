using Microsoft.AspNetCore.Mvc;

namespace PoniPortfolio.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
