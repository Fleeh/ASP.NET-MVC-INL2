using Microsoft.AspNetCore.Mvc;

namespace ASPNETWEBCORE.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
