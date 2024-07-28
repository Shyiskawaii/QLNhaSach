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
                return RedirectToAction("CheckoutComplete", new { billId = bill.Id });
            }

            return View(bill);
        }

        public IActionResult CheckoutComplete(int billId)
        {
            // Retrieve the bill with its items
            var bill = _context.Bills
                .Include(b => b.BillItems)
                .ThenInclude(bi => bi.Book)
                .FirstOrDefault(b => b.Id == billId);

            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bill/CheckoutComplete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CheckoutComplete(Bill bill)
        {
            foreach (var item in bill.BillItems)
            {
                var book = await _context.Books.FindAsync(item.BookId);
                if (book != null)
                {
                    book.NumOfBook -= item.Quantity;
                    if (book.NumOfBook < 0)
                    {
                        book.NumOfBook = 0;
                    }
                    await _context.SaveChangesAsync();
                }
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
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
        // GET: Bill/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var bill = await _context.Bills
                .Include(b => b.BillItems)
                .ThenInclude(bi => bi.Book)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }
        // GET: Bill/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var bill = await _context.Bills
                .Include(b => b.BillItems)
                    .ThenInclude(bi => bi.Book)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: Bill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bill = await _context.Bills.FindAsync(id);

            if (bill != null)
            {
                _context.BillItems.RemoveRange(bill.BillItems);
                await _context.SaveChangesAsync();
                _context.Bills.Remove(bill);
                await _context.SaveChangesAsync();

            }
           
            return RedirectToAction(nameof(Index)); 
        }
    }
}
