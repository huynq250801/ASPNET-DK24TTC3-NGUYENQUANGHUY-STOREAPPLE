using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppleStore.Data;
using WebAppleStore.Models;

namespace WebAppleStore.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly AppleStoreShopContext _context;

        public CheckoutController(AppleStoreShopContext context)
        {
            _context = context;
        }

        // GET: /Checkout/Index/1  hoặc /Checkout?id=1
        public async Task<IActionResult> Index(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

            if (product == null)
                return NotFound();

            var vm = new CheckoutViewModel
            {
                ProductId = product.Id,
                Product = product,
                Quantity = 1
            };

            return View(vm);
        }

        // POST: /Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CheckoutViewModel model)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == model.ProductId && p.IsActive);

            if (product == null)
            {
                ModelState.AddModelError(string.Empty, "Sản phẩm không tồn tại hoặc đã ngừng kinh doanh.");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                // nạp lại thông tin sản phẩm để hiển thị trên view
                model.Product = product;
                return View(model);
            }

            // Tạo mã đơn đơn giản: DH + yyyyMMddHHmmss
            var orderCode = $"DH{DateTime.Now:yyyyMMddHHmmss}";

            var order = new Order
            {
                OrderCode = orderCode,
                CustomerName = model.CustomerName,
                Phone = model.Phone,
                Email = model.Email,
                Address = model.Address,
                Note = model.Note,
                OrderDate = DateTime.Now,
                Status = "Chờ xử lý",
                TotalAmount = product.Price * model.Quantity
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var orderItem = new OrderItem
            {
                OrderId = order.Id,
                ProductId = product.Id,
                Quantity = model.Quantity,
                UnitPrice = product.Price,
                DiscountPercent = 0,
                Subtotal = product.Price * model.Quantity
            };

            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Success", new { id = order.Id });
        }

        // Trang cảm ơn
        public async Task<IActionResult> Success(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }
    }
}
