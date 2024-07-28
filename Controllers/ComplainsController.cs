using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLNhaSach.Data;
using QLNhaSach.Models;

namespace QLNhaSach.Controllers
{
    public class ComplainsController : Controller
    {
        private readonly QLNhaSachContext _context;
        public ComplainsController(QLNhaSachContext context)
        {
            _context = context;
        }
      

        // GET: Complains
        public async Task<IActionResult> Index()
        {
              return _context.Complain != null ? 
                          View(await _context.Complain.ToListAsync()) :
                          Problem("Entity set 'QLNhaSachContext.Complain'  is null.");
        }

        // GET: Complains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Complain == null)
            {
                return NotFound();
            }

            var complain = await _context.Complain
                .FirstOrDefaultAsync(m => m.ComplainId == id);
            if (complain == null)
            {
                return NotFound();
            }

            return View(complain);
        }

        // GET: Complains/Create
        public IActionResult Create()
        {
            var userId = 1;
            ViewBag.UserId = userId;
            return View();
        }

        // POST: Complains/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComplainId,Description,UserId")] Complain complain)
        {
            if (ModelState.IsValid)
            {
                complain.Status = false;
                complain.Response = false;


                _context.Add(complain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(complain);
        }

        // GET: Complains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Complain == null)
            {
                return NotFound();
            }

            var complain = await _context.Complain.FindAsync(id);
            if (complain == null)
            {
                return NotFound();
            }
            return View(complain);
        }

        // POST: Complains/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComplainId,Description,Status,Response,UserId")] Complain complain)
        {
            if (id != complain.ComplainId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplainExists(complain.ComplainId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(complain);
        }

        // GET: Complains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Complain == null)
            {
                return NotFound();
            }

            var complain = await _context.Complain
                .FirstOrDefaultAsync(m => m.ComplainId == id);
            if (complain == null)
            {
                return NotFound();
            }

            return View(complain);
        }

        // POST: Complains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Complain == null)
            {
                return Problem("Entity set 'QLNhaSachContext.Complain'  is null.");
            }
            var complain = await _context.Complain.FindAsync(id);
            if (complain != null)
            {
                _context.Complain.Remove(complain);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplainExists(int id)
        {
          return (_context.Complain?.Any(e => e.ComplainId == id)).GetValueOrDefault();
        }
    }
}
