using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETWEBCORE.Controllers
{
    [Authorize(Policy = "Admins")]
    public class RoleController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
        
    }
}
