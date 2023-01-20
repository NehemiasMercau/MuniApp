using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuniApp.Negocio.entidades;

namespace MuniApp.Controllers
{
    public class RubrosController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public RubrosController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: Rubros
        public async Task<IActionResult> Index()
        {
              return _context.Rubro != null ? 
                          View(await _context.Rubro.Where(x => x.Activo == true).ToListAsync()) :
                          Problem("Entity set 'ODAMuniDBContext.Rubro'  is null.");
        }

        // GET: Rubros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rubro == null)
            {
                return NotFound();
            }

            var rubro = await _context.Rubro
                .FirstOrDefaultAsync(m => m.RubroId == id);
            if (rubro == null)
            {
                return NotFound();
            }

            return View(rubro);
        }

        // GET: Rubros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rubros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RubroId,Nombre,Activo")] Rubro rubro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rubro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rubro);
        }

        // GET: Rubros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rubro == null)
            {
                return NotFound();
            }

            var rubro = await _context.Rubro.FindAsync(id);
            if (rubro == null)
            {
                return NotFound();
            }
            return View(rubro);
        }

        // POST: Rubros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RubroId,Nombre,Activo")] Rubro rubro)
        {
            if (id != rubro.RubroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rubro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RubroExists(rubro.RubroId))
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
            return View(rubro);
        }

        // GET: Rubros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rubro == null)
            {
                return NotFound();
            }

            var rubro = await _context.Rubro
                .FirstOrDefaultAsync(m => m.RubroId == id);
            if (rubro == null)
            {
                return NotFound();
            }

            return View(rubro);
        }

        // POST: Rubros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rubro == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.Rubro'  is null.");
            }
            var rubro = await _context.Rubro.FindAsync(id);
            if (rubro != null)
            {
                _context.Rubro.Remove(rubro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RubroExists(int id)
        {
          return (_context.Rubro?.Any(e => e.RubroId == id)).GetValueOrDefault();
        }
    }
}
