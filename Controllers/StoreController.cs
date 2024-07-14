using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLNhaSach.Data;

namespace QLNhaSach.Controllers
{
    public class StoreController : Controller
    {
        private readonly QLNhaSachContext _context;

        public StoreController(QLNhaSachContext context)
        {
            _context = context;
        }
     
        public async Task<IActionResult> Index()
        { 
            return View(await _context.Books.ToListAsync());
        }
    public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    }
}
