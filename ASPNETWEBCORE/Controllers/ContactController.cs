using Microsoft.AspNetCore.Mvc;

namespace ASPNETWEBCORE.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
