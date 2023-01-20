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
    public class EventualidadesController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public EventualidadesController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: Eventualidades
        public async Task<IActionResult> Index()
        {
              return _context.Eventualidad != null ? 
                          View(await _context.Eventualidad.ToListAsync()) :
                          Problem("Entity set 'ODAMuniDBContext.Eventualidad'  is null.");
        }

        // GET: Eventualidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Eventualidad == null)
            {
                return NotFound();
            }

            var eventualidad = await _context.Eventualidad
                .FirstOrDefaultAsync(m => m.EventualidadId == id);
            if (eventualidad == null)
            {
                return NotFound();
            }

            return View(eventualidad);
        }

        // GET: Eventualidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eventualidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventualidadId,Nombre,Descripción,Fecha,Monto,Activo")] Eventualidad eventualidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventualidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventualidad);
        }

        // GET: Eventualidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Eventualidad == null)
            {
                return NotFound();
            }

            var eventualidad = await _context.Eventualidad.FindAsync(id);
            if (eventualidad == null)
            {
                return NotFound();
            }
            return View(eventualidad);
        }

        // POST: Eventualidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventualidadId,Nombre,Descripción,Fecha,Monto,Activo")] Eventualidad eventualidad)
        {
            if (id != eventualidad.EventualidadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventualidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventualidadExists(eventualidad.EventualidadId))
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
            return View(eventualidad);
        }

        // GET: Eventualidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Eventualidad == null)
            {
                return NotFound();
            }

            var eventualidad = await _context.Eventualidad
                .FirstOrDefaultAsync(m => m.EventualidadId == id);
            if (eventualidad == null)
            {
                return NotFound();
            }

            return View(eventualidad);
        }

        // POST: Eventualidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Eventualidad == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.Eventualidad'  is null.");
            }
            var eventualidad = await _context.Eventualidad.FindAsync(id);
            if (eventualidad != null)
            {
                _context.Eventualidad.Remove(eventualidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventualidadExists(int id)
        {
          return (_context.Eventualidad?.Any(e => e.EventualidadId == id)).GetValueOrDefault();
        }
    }
}
