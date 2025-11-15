using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppleStore.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppleStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppleStoreShopContext _context;

        public CategoryController(AppleStoreShopContext context)
        {
            _context = context;
        }

        // /danh-muc/{slug}
        [HttpGet("/danh-muc/{slug}")]
        public async Task<IActionResult> Index(string slug)
        {
            if (string.IsNullOrWhiteSpace(slug))
                return NotFound();

            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Slug == slug);

            if (category == null)
                return NotFound();

            var products = await _context.Products
                .Where(p => p.CategoryId == category.Id && p.IsActive)
                .OrderByDescending(p => p.Id)
                .ToListAsync();

            ViewBag.CategoryName = category.Name;

            return View(products);
        }
    }
}
