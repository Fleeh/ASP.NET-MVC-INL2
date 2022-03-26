using Microsoft.AspNetCore.Mvc;

namespace ASPNETWEBCORE.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
