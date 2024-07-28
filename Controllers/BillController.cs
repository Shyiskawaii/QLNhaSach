using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLNhaSach.Data;
using QLNhaSach.Models;

namespace QLNhaSach.Controllers
{
    public class BillController : Controller
    {
        private readonly QLNhaSachContext _context;
        private readonly Cart _cart;

        public BillController(QLNhaSachContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }
        public async Task<IActionResult> Index()
        {
            return _context.Bills != null ?
                        View(await _context.Bills.ToListAsync()) :
                        Problem("Entity set 'QLNhaSachContext.Bills'  is null.");
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Bill bill)
        {
            var cartItems = _cart.GetAllCartItems();
            _cart.CartItems = cartItems;

            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Cart is empty, please add a book first.");
            }

            if (ModelState.IsValid)
            {
                CreateBill(bill);
                _cart.ClearCart();
                return View("CheckoutComplete", bill);
            }

            return View(bill);
        }

        public IActionResult CheckoutComplete(Bill bill)
        {
            return View(bill);
        }

        public void CreateBill(Bill bill)
        {
            bill.BillDate = DateTime.Now;

            var cartItems = _cart.CartItems;

            foreach (var item in cartItems)
            {
                var orderItem = new BillItem()
                {
                    Quantity = item.Quantity,
                    BookId = item.Book.BookId,
                    BillId = bill.Id,
                    Price = item.Book.Price * item.Quantity
                };
                bill.BillItems.Add(orderItem);
                bill.BillTotal += orderItem.Price;
            }
            _context.Bills.Add(bill);
            _context.SaveChanges();
        }
    }
}
