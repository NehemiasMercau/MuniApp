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
    public class DomiciliosController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public DomiciliosController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: Domicilios
        public async Task<IActionResult> Index()
        {
            var oDAMuniDBContext = _context.Domicilio.Include(d => d.Persona).Include(d => d.PersonaEntidad);
            return View(await oDAMuniDBContext.ToListAsync());
        }

        // GET: Domicilios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Domicilio == null)
            {
                return NotFound();
            }

            var domicilio = await _context.Domicilio
                .Include(d => d.Persona)
                .Include(d => d.PersonaEntidad)
                .FirstOrDefaultAsync(m => m.DomicilioId == id);
            if (domicilio == null)
            {
                return NotFound();
            }

            return View(domicilio);
        }

        // GET: Domicilios/Create
        public IActionResult Create()
        {
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId");
            ViewData["PersonaEntidadId"] = new SelectList(_context.PersonaEntidad, "PersonaEntidadId", "PersonaEntidadId");
            return View();
        }

        // POST: Domicilios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DomicilioId,PersonaEntidadId,PersonaId,Barrio,Calle,Altura,Piso,Dpto,Activo")] Domicilio domicilio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(domicilio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", domicilio.PersonaId);
            ViewData["PersonaEntidadId"] = new SelectList(_context.PersonaEntidad, "PersonaEntidadId", "PersonaEntidadId", domicilio.PersonaEntidadId);
            return View(domicilio);
        }

        // GET: Domicilios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Domicilio == null)
            {
                return NotFound();
            }

            var domicilio = await _context.Domicilio.FindAsync(id);
            if (domicilio == null)
            {
                return NotFound();
            }
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", domicilio.PersonaId);
            ViewData["PersonaEntidadId"] = new SelectList(_context.PersonaEntidad, "PersonaEntidadId", "PersonaEntidadId", domicilio.PersonaEntidadId);
            return View(domicilio);
        }

        // POST: Domicilios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DomicilioId,PersonaEntidadId,PersonaId,Barrio,Calle,Altura,Piso,Dpto,Activo")] Domicilio domicilio)
        {
            if (id != domicilio.DomicilioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(domicilio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DomicilioExists(domicilio.DomicilioId))
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
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", domicilio.PersonaId);
            ViewData["PersonaEntidadId"] = new SelectList(_context.PersonaEntidad, "PersonaEntidadId", "PersonaEntidadId", domicilio.PersonaEntidadId);
            return View(domicilio);
        }

        // GET: Domicilios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Domicilio == null)
            {
                return NotFound();
            }

            var domicilio = await _context.Domicilio
                .Include(d => d.Persona)
                .Include(d => d.PersonaEntidad)
                .FirstOrDefaultAsync(m => m.DomicilioId == id);
            if (domicilio == null)
            {
                return NotFound();
            }

            return View(domicilio);
        }

        // POST: Domicilios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Domicilio == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.Domicilio'  is null.");
            }
            var domicilio = await _context.Domicilio.FindAsync(id);
            if (domicilio != null)
            {
                _context.Domicilio.Remove(domicilio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DomicilioExists(int id)
        {
          return (_context.Domicilio?.Any(e => e.DomicilioId == id)).GetValueOrDefault();
        }
    }
}
