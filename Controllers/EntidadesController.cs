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
    public class EntidadesController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public EntidadesController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: Entidades
        public async Task<IActionResult> Index()
        {
            var oDAMuniDBContext = _context.Entidad.Include(e => e.Rubro);
            return View(await oDAMuniDBContext.ToListAsync());
        }

        // GET: Entidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Entidad == null)
            {
                return NotFound();
            }

            var entidad = await _context.Entidad
                .Include(e => e.Rubro)
                .FirstOrDefaultAsync(m => m.EntidadId == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return View(entidad);
        }

        // GET: Entidades/Create
        public IActionResult Create()
        {
            ViewData["RubroId"] = new SelectList(_context.Rubro, "RubroId", "RubroId");
            return View();
        }

        // POST: Entidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntidadId,Nombre,RubroId,Activo")] Entidad entidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RubroId"] = new SelectList(_context.Rubro, "RubroId", "RubroId", entidad.RubroId);
            return View(entidad);
        }

        // GET: Entidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Entidad == null)
            {
                return NotFound();
            }

            var entidad = await _context.Entidad.FindAsync(id);
            if (entidad == null)
            {
                return NotFound();
            }
            ViewData["RubroId"] = new SelectList(_context.Rubro, "RubroId", "RubroId", entidad.RubroId);
            return View(entidad);
        }

        // POST: Entidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntidadId,Nombre,RubroId,Activo")] Entidad entidad)
        {
            if (id != entidad.EntidadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadExists(entidad.EntidadId))
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
            ViewData["RubroId"] = new SelectList(_context.Rubro, "RubroId", "RubroId", entidad.RubroId);
            return View(entidad);
        }

        // GET: Entidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Entidad == null)
            {
                return NotFound();
            }

            var entidad = await _context.Entidad
                .Include(e => e.Rubro)
                .FirstOrDefaultAsync(m => m.EntidadId == id);
            if (entidad == null)
            {
                return NotFound();
            }

            return View(entidad);
        }

        // POST: Entidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Entidad == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.Entidad'  is null.");
            }
            var entidad = await _context.Entidad.FindAsync(id);
            if (entidad != null)
            {
                _context.Entidad.Remove(entidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadExists(int id)
        {
          return (_context.Entidad?.Any(e => e.EntidadId == id)).GetValueOrDefault();
        }
    }
}
