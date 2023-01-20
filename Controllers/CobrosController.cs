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
    public class CobrosController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public CobrosController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: Cobros
        public async Task<IActionResult> Index()
        {
            var oDAMuniDBContext = _context.Cobro.Include(c => c.Arqueo).Include(c => c.Persona).Include(c => c.Usuario);
            return View(await oDAMuniDBContext.ToListAsync());
        }

        // GET: Cobros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cobro == null)
            {
                return NotFound();
            }

            var cobro = await _context.Cobro
                .Include(c => c.Arqueo)
                .Include(c => c.Persona)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CobroId == id);
            if (cobro == null)
            {
                return NotFound();
            }

            return View(cobro);
        }

        // GET: Cobros/Create
        public IActionResult Create()
        {
            ViewData["ArqueoId"] = new SelectList(_context.Arqueo, "ArqueoId", "ArqueoId");
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId");
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId");
            return View();
        }

        // POST: Cobros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CobroId,ArqueoId,Total,Fecha,PersonaId,Descuento,Recargo,Final,UsuarioId,Activo,SecuenciaId")] Cobro cobro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cobro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArqueoId"] = new SelectList(_context.Arqueo, "ArqueoId", "ArqueoId", cobro.ArqueoId);
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", cobro.PersonaId);
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", cobro.UsuarioId);
            return View(cobro);
        }

        // GET: Cobros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cobro == null)
            {
                return NotFound();
            }

            var cobro = await _context.Cobro.FindAsync(id);
            if (cobro == null)
            {
                return NotFound();
            }
            ViewData["ArqueoId"] = new SelectList(_context.Arqueo, "ArqueoId", "ArqueoId", cobro.ArqueoId);
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", cobro.PersonaId);
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", cobro.UsuarioId);
            return View(cobro);
        }

        // POST: Cobros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CobroId,ArqueoId,Total,Fecha,PersonaId,Descuento,Recargo,Final,UsuarioId,Activo,SecuenciaId")] Cobro cobro)
        {
            if (id != cobro.CobroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cobro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CobroExists(cobro.CobroId))
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
            ViewData["ArqueoId"] = new SelectList(_context.Arqueo, "ArqueoId", "ArqueoId", cobro.ArqueoId);
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", cobro.PersonaId);
            ViewData["UsuarioId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", cobro.UsuarioId);
            return View(cobro);
        }

        // GET: Cobros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cobro == null)
            {
                return NotFound();
            }

            var cobro = await _context.Cobro
                .Include(c => c.Arqueo)
                .Include(c => c.Persona)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CobroId == id);
            if (cobro == null)
            {
                return NotFound();
            }

            return View(cobro);
        }

        // POST: Cobros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cobro == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.Cobro'  is null.");
            }
            var cobro = await _context.Cobro.FindAsync(id);
            if (cobro != null)
            {
                _context.Cobro.Remove(cobro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CobroExists(int id)
        {
          return (_context.Cobro?.Any(e => e.CobroId == id)).GetValueOrDefault();
        }
    }
}
