﻿using Microsoft.AspNetCore.Mvc;

namespace ASPNETWEBCORE.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.errorMessage = "Page Not Found";
                    break;
            }

            return View("NotFound");
        }





    }
}
