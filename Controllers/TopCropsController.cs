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
    public class TopCropsController : Controller
    {
        private readonly GardenerContext _context;

        public TopCropsController(GardenerContext context)
        {
            _context = context;
        }

        // GET: TopCrops
        public async Task<IActionResult> Index()
        {
              return _context.TopCrops != null ? 
                          View(await _context.TopCrops.ToListAsync()) :
                          Problem("Entity set 'GardenerContext.TopCrops'  is null.");
        }

        // GET: TopCrops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TopCrops == null)
            {
                return NotFound();
            }

            var topCrop = await _context.TopCrops
                .FirstOrDefaultAsync(m => m.CropId == id);
            if (topCrop == null)
            {
                return NotFound();
            }

            return View(topCrop);
        }

        // GET: TopCrops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TopCrops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CropId,Name,Description")] TopCrop topCrop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topCrop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topCrop);
        }

        // GET: TopCrops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TopCrops == null)
            {
                return NotFound();
            }

            var topCrop = await _context.TopCrops.FindAsync(id);
            if (topCrop == null)
            {
                return NotFound();
            }
            return View(topCrop);
        }

        // POST: TopCrops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CropId,Name,Description")] TopCrop topCrop)
        {
            if (id != topCrop.CropId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topCrop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopCropExists(topCrop.CropId))
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
            return View(topCrop);
        }

        // GET: TopCrops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TopCrops == null)
            {
                return NotFound();
            }

            var topCrop = await _context.TopCrops
                .FirstOrDefaultAsync(m => m.CropId == id);
            if (topCrop == null)
            {
                return NotFound();
            }

            return View(topCrop);
        }

        // POST: TopCrops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TopCrops == null)
            {
                return Problem("Entity set 'GardenerContext.TopCrops'  is null.");
            }
            var topCrop = await _context.TopCrops.FindAsync(id);
            if (topCrop != null)
            {
                _context.TopCrops.Remove(topCrop);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopCropExists(int id)
        {
          return (_context.TopCrops?.Any(e => e.CropId == id)).GetValueOrDefault();
        }
    }
}
