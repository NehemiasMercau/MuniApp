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
    public class PersonaEntidadDeudaDetallesController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public PersonaEntidadDeudaDetallesController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: PersonaEntidadDeudaDetalles
        public async Task<IActionResult> Index()
        {
            var oDAMuniDBContext = _context.PersonaEntidadDeudaDetalle.Include(p => p.DeudaDetalle).Include(p => p.Persona).Include(p => p.PersonaEntidad).Include(p => p.UsuarioIdAnuloNavigation);
            return View(await oDAMuniDBContext.ToListAsync());
        }

        // GET: PersonaEntidadDeudaDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonaEntidadDeudaDetalle == null)
            {
                return NotFound();
            }

            var personaEntidadDeudaDetalle = await _context.PersonaEntidadDeudaDetalle
                .Include(p => p.DeudaDetalle)
                .Include(p => p.Persona)
                .Include(p => p.PersonaEntidad)
                .Include(p => p.UsuarioIdAnuloNavigation)
                .FirstOrDefaultAsync(m => m.PersonaEntidadDeudaDetalleId == id);
            if (personaEntidadDeudaDetalle == null)
            {
                return NotFound();
            }

            return View(personaEntidadDeudaDetalle);
        }

        // GET: PersonaEntidadDeudaDetalles/Create
        public IActionResult Create()
        {
            ViewData["DeudaDetalleId"] = new SelectList(_context.DeudaDetalle, "DeudaDetalleId", "DeudaDetalleId");
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId");
            ViewData["PersonaEntidadId"] = new SelectList(_context.PersonaEntidad, "PersonaEntidadId", "PersonaEntidadId");
            ViewData["UsuarioIdAnulo"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId");
            return View();
        }

        // POST: PersonaEntidadDeudaDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonaEntidadDeudaDetalleId,PersonaEntidadId,PersonaId,DeudaDetalleId,Pagado,FechaPago,Mora,MoraDias,Importe,Recargo,PrePago,Anulado,Activo,UsuarioIdAnulo")] PersonaEntidadDeudaDetalle personaEntidadDeudaDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personaEntidadDeudaDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeudaDetalleId"] = new SelectList(_context.DeudaDetalle, "DeudaDetalleId", "DeudaDetalleId", personaEntidadDeudaDetalle.DeudaDetalleId);
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", personaEntidadDeudaDetalle.PersonaId);
            ViewData["PersonaEntidadId"] = new SelectList(_context.PersonaEntidad, "PersonaEntidadId", "PersonaEntidadId", personaEntidadDeudaDetalle.PersonaEntidadId);
            ViewData["UsuarioIdAnulo"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", personaEntidadDeudaDetalle.UsuarioIdAnulo);
            return View(personaEntidadDeudaDetalle);
        }

        // GET: PersonaEntidadDeudaDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonaEntidadDeudaDetalle == null)
            {
                return NotFound();
            }

            var personaEntidadDeudaDetalle = await _context.PersonaEntidadDeudaDetalle.FindAsync(id);
            if (personaEntidadDeudaDetalle == null)
            {
                return NotFound();
            }
            ViewData["DeudaDetalleId"] = new SelectList(_context.DeudaDetalle, "DeudaDetalleId", "DeudaDetalleId", personaEntidadDeudaDetalle.DeudaDetalleId);
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", personaEntidadDeudaDetalle.PersonaId);
            ViewData["PersonaEntidadId"] = new SelectList(_context.PersonaEntidad, "PersonaEntidadId", "PersonaEntidadId", personaEntidadDeudaDetalle.PersonaEntidadId);
            ViewData["UsuarioIdAnulo"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", personaEntidadDeudaDetalle.UsuarioIdAnulo);
            return View(personaEntidadDeudaDetalle);
        }

        // POST: PersonaEntidadDeudaDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonaEntidadDeudaDetalleId,PersonaEntidadId,PersonaId,DeudaDetalleId,Pagado,FechaPago,Mora,MoraDias,Importe,Recargo,PrePago,Anulado,Activo,UsuarioIdAnulo")] PersonaEntidadDeudaDetalle personaEntidadDeudaDetalle)
        {
            if (id != personaEntidadDeudaDetalle.PersonaEntidadDeudaDetalleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personaEntidadDeudaDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaEntidadDeudaDetalleExists(personaEntidadDeudaDetalle.PersonaEntidadDeudaDetalleId))
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
            ViewData["DeudaDetalleId"] = new SelectList(_context.DeudaDetalle, "DeudaDetalleId", "DeudaDetalleId", personaEntidadDeudaDetalle.DeudaDetalleId);
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", personaEntidadDeudaDetalle.PersonaId);
            ViewData["PersonaEntidadId"] = new SelectList(_context.PersonaEntidad, "PersonaEntidadId", "PersonaEntidadId", personaEntidadDeudaDetalle.PersonaEntidadId);
            ViewData["UsuarioIdAnulo"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", personaEntidadDeudaDetalle.UsuarioIdAnulo);
            return View(personaEntidadDeudaDetalle);
        }

        // GET: PersonaEntidadDeudaDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonaEntidadDeudaDetalle == null)
            {
                return NotFound();
            }

            var personaEntidadDeudaDetalle = await _context.PersonaEntidadDeudaDetalle
                .Include(p => p.DeudaDetalle)
                .Include(p => p.Persona)
                .Include(p => p.PersonaEntidad)
                .Include(p => p.UsuarioIdAnuloNavigation)
                .FirstOrDefaultAsync(m => m.PersonaEntidadDeudaDetalleId == id);
            if (personaEntidadDeudaDetalle == null)
            {
                return NotFound();
            }

            return View(personaEntidadDeudaDetalle);
        }

        // POST: PersonaEntidadDeudaDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonaEntidadDeudaDetalle == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.PersonaEntidadDeudaDetalle'  is null.");
            }
            var personaEntidadDeudaDetalle = await _context.PersonaEntidadDeudaDetalle.FindAsync(id);
            if (personaEntidadDeudaDetalle != null)
            {
                _context.PersonaEntidadDeudaDetalle.Remove(personaEntidadDeudaDetalle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaEntidadDeudaDetalleExists(int id)
        {
          return (_context.PersonaEntidadDeudaDetalle?.Any(e => e.PersonaEntidadDeudaDetalleId == id)).GetValueOrDefault();
        }
    }
}
