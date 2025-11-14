using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppleStore.Data;
using WebAppleStore.Models;

namespace WebAppleStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppleStoreShopContext _context;

        public HomeController(AppleStoreShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var iphones = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Slug == "iphone" && p.IsActive)
                .Take(3)
                .ToListAsync();

            var ipads = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Slug == "ipad" && p.IsActive)
                .Take(3)
                .ToListAsync();

            var watches = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Slug == "watch" && p.IsActive)
                .Take(3)
                .ToListAsync();

            var accessories = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.Category.Slug == "phu-kien" && p.IsActive)
                .Take(3)
                .ToListAsync();

            var vm = new HomeViewModel
            {
                Iphones = iphones,
                Ipads = ipads,
                Watches = watches,
                Accessories = accessories
            };

            return View(vm);
        }
    }
}
