using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreenGarden.Models;

namespace GreenGarden.Controllers
{
    public class GardenersController : Controller
    {
        private readonly GardenerContext _context;

        public GardenersController(GardenerContext context)
        {
            _context = context;
        }

        // GET: Gardeners
        public async Task<IActionResult> Index()
        {
              return _context.Gardenership != null ? 
                          View(await _context.Gardenership.ToListAsync()) :
                          Problem("Entity set 'GardenerContext.Gardenership'  is null.");
        }

        // GET: Gardeners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Gardenership == null)
            {
                return NotFound();
            }

            var gardeners = await _context.Gardenership
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gardeners == null)
            {
                return NotFound();
            }

            return View(gardeners);
        }

        // GET: Gardeners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gardeners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,GenderIdentity,Address,City,State,Zip,Email,Cell")] Gardeners gardeners)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gardeners);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gardeners);
        }

        // GET: Gardeners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Gardenership == null)
            {
                return NotFound();
            }

            var gardeners = await _context.Gardenership.FindAsync(id);
            if (gardeners == null)
            {
                return NotFound();
            }
            return View(gardeners);
        }

        // POST: Gardeners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,GenderIdentity,Address,City,State,Zip,Email,Cell")] Gardeners gardeners)
        {
            if (id != gardeners.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gardeners);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GardenersExists(gardeners.ID))
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
            return View(gardeners);
        }

        // GET: Gardeners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Gardenership == null)
            {
                return NotFound();
            }

            var gardeners = await _context.Gardenership
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gardeners == null)
            {
                return NotFound();
            }

            return View(gardeners);
        }

        // POST: Gardeners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Gardenership == null)
            {
                return Problem("Entity set 'GardenerContext.Gardenership'  is null.");
            }
            var gardeners = await _context.Gardenership.FindAsync(id);
            if (gardeners != null)
            {
                _context.Gardenership.Remove(gardeners);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GardenersExists(int id)
        {
          return (_context.Gardenership?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
