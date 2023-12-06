using Microsoft.AspNetCore.Mvc;

namespace ASPNET_TP3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
