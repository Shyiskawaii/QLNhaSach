using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLNhaSach.Data;
using System.Linq;
using System.Threading.Tasks;

namespace QLNhaSach.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private readonly QLNhaSachContext _context;

        public StoreController(QLNhaSachContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString, decimal? minPrice, decimal? maxPrice)
        {
            var books = from b in _context.Books
                        select b;

            if (!string.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.BookName.Contains(searchString) || s.Author.Contains(searchString));
            }

            if (minPrice.HasValue)
            {
                books = books.Where(s => s.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                books = books.Where(s => s.Price <= maxPrice.Value);
            }

            return View(await books.ToListAsync());
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
