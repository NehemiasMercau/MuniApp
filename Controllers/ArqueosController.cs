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
    public class ArqueosController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public ArqueosController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: Arqueos
        public async Task<IActionResult> Index()
        {
            var oDAMuniDBContext = _context.Arqueo.Include(a => a.UsuarioFinalizo).Include(a => a.UsuarioIncio);
            return View(await oDAMuniDBContext.ToListAsync());
        }

        // GET: Arqueos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Arqueo == null)
            {
                return NotFound();
            }

            var arqueo = await _context.Arqueo
                .Include(a => a.UsuarioFinalizo)
                .Include(a => a.UsuarioIncio)
                .FirstOrDefaultAsync(m => m.ArqueoId == id);
            if (arqueo == null)
            {
                return NotFound();
            }

            return View(arqueo);
        }

        // GET: Arqueos/Create
        public IActionResult Create()
        {
            ViewData["UsuarioFinalizoId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId");
            ViewData["UsuarioIncioId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId");
            return View();
        }

        // POST: Arqueos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArqueoId,FechaInicio,HoraInicio,HoraFin,FechaFin,Total,Faltante,Sobrante,Observaciones,Abierto,Iniciado,Finalizado,TotalEfectivo,UsuarioIncioId,UsuarioFinalizoId,Activo")] Arqueo arqueo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arqueo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioFinalizoId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", arqueo.UsuarioFinalizoId);
            ViewData["UsuarioIncioId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", arqueo.UsuarioIncioId);
            return View(arqueo);
        }

        // GET: Arqueos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Arqueo == null)
            {
                return NotFound();
            }

            var arqueo = await _context.Arqueo.FindAsync(id);
            if (arqueo == null)
            {
                return NotFound();
            }
            ViewData["UsuarioFinalizoId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", arqueo.UsuarioFinalizoId);
            ViewData["UsuarioIncioId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", arqueo.UsuarioIncioId);
            return View(arqueo);
        }

        // POST: Arqueos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArqueoId,FechaInicio,HoraInicio,HoraFin,FechaFin,Total,Faltante,Sobrante,Observaciones,Abierto,Iniciado,Finalizado,TotalEfectivo,UsuarioIncioId,UsuarioFinalizoId,Activo")] Arqueo arqueo)
        {
            if (id != arqueo.ArqueoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arqueo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArqueoExists(arqueo.ArqueoId))
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
            ViewData["UsuarioFinalizoId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", arqueo.UsuarioFinalizoId);
            ViewData["UsuarioIncioId"] = new SelectList(_context.UsuarioReferencia, "UsuarioRefId", "UsuarioRefId", arqueo.UsuarioIncioId);
            return View(arqueo);
        }

        // GET: Arqueos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Arqueo == null)
            {
                return NotFound();
            }

            var arqueo = await _context.Arqueo
                .Include(a => a.UsuarioFinalizo)
                .Include(a => a.UsuarioIncio)
                .FirstOrDefaultAsync(m => m.ArqueoId == id);
            if (arqueo == null)
            {
                return NotFound();
            }

            return View(arqueo);
        }

        // POST: Arqueos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Arqueo == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.Arqueo'  is null.");
            }
            var arqueo = await _context.Arqueo.FindAsync(id);
            if (arqueo != null)
            {
                _context.Arqueo.Remove(arqueo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArqueoExists(int id)
        {
          return (_context.Arqueo?.Any(e => e.ArqueoId == id)).GetValueOrDefault();
        }
    }
}
