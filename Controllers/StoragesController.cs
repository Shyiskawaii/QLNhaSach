using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLNhaSach.Data;
using QLNhaSach.Models;

namespace QLNhaSach.Controllers
{
    public class StoragesController : Controller
    {
        private readonly QLNhaSachContext _context;

        public StoragesController(QLNhaSachContext context)
        {
            _context = context;
        }

        // GET: Storages
        public async Task<IActionResult> Index()
        {
              return _context.Storage != null ? 
                          View(await _context.Storage.ToListAsync()) :
                          Problem("Entity set 'QLNhaSachContext.Storage'  is null.");
        }

        // GET: Storages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Storage == null)
            {
                return NotFound();
            }

            var storage = await _context.Storage
                .FirstOrDefaultAsync(m => m.StorageID == id);
            if (storage == null)
            {
                return NotFound();
            }

            return View(storage);
        }

        // GET: Storages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Storages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StorageID,BookId,Transfer,Cost,Note")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storage);
        }

        // GET: Storages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Storage == null)
            {
                return NotFound();
            }

            var storage = await _context.Storage.FindAsync(id);
            if (storage == null)
            {
                return NotFound();
            }
            return View(storage);
        }

        // POST: Storages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StorageID,BookId,Transfer,Cost,Note")] Storage storage)
        {
            if (id != storage.StorageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorageExists(storage.StorageID))
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
            return View(storage);
        }

        // GET: Storages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Storage == null)
            {
                return NotFound();
            }

            var storage = await _context.Storage
                .FirstOrDefaultAsync(m => m.StorageID == id);
            if (storage == null)
            {
                return NotFound();
            }

            return View(storage);
        }

        // POST: Storages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Storage == null)
            {
                return Problem("Entity set 'QLNhaSachContext.Storage'  is null.");
            }
            var storage = await _context.Storage.FindAsync(id);
            if (storage != null)
            {
                _context.Storage.Remove(storage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StorageExists(int id)
        {
          return (_context.Storage?.Any(e => e.StorageID == id)).GetValueOrDefault();
        }
    }
}
