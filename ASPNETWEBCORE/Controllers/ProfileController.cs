using ASPNETWEBCORE.Models;
using ASPNETWEBCORE.Models.data;
using ASPNETWEBCORE.Models.data.Entities;
using ASPNETWEBCORE.Models.Viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNETWEBCORE.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _host;

        public ProfileController(AppDbContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        public async Task<IActionResult> Index()
        {

            var viewModel = new ProfileViewModel();

           viewModel.Address = await _context.UserAddresses.Include(x => x.Address).FirstOrDefaultAsync(x => x.UserId == User.FindFirst("UserId").Value);
            

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ImageEntity imageEntity)
        {
            if (ModelState.IsValid)
            {
                string wwwroothPath = _host.WebRootPath;
                string fileName = $"{Path.GetFileNameWithoutExtension(imageEntity.File.FileName)}_{Guid.NewGuid()}{Path.GetExtension(imageEntity.File.FileName)}";         
                string filePath = Path.Combine($"{wwwroothPath}/images", fileName);

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    await imageEntity.File.CopyToAsync(fs);
                }

                imageEntity.FileName = fileName;
                _context.Add(imageEntity);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));

            }
            return View(imageEntity);
        }

    }
}
