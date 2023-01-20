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
    public class DeudaDetallesController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public DeudaDetallesController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: DeudaDetalles
        public async Task<IActionResult> Index()
        {
            var oDAMuniDBContext = _context.DeudaDetalle.Include(d => d.Deuda).Include(d => d.Periodo);
            return View(await oDAMuniDBContext.ToListAsync());
        }

        // GET: DeudaDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DeudaDetalle == null)
            {
                return NotFound();
            }

            var deudaDetalle = await _context.DeudaDetalle
                .Include(d => d.Deuda)
                .Include(d => d.Periodo)
                .FirstOrDefaultAsync(m => m.DeudaDetalleId == id);
            if (deudaDetalle == null)
            {
                return NotFound();
            }

            return View(deudaDetalle);
        }

        // GET: DeudaDetalles/Create
        public IActionResult Create()
        {
            ViewData["DeudaId"] = new SelectList(_context.Deuda, "DeudaId", "DeudaId");
            ViewData["PeriodoId"] = new SelectList(_context.Periodo, "PeriodoId", "PeriodoId");
            return View();
        }

        // POST: DeudaDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeudaDetalleId,DeudaId,Importe,Recargo,FechaVencimiento,PeriodoId,Activo")] DeudaDetalle deudaDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deudaDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeudaId"] = new SelectList(_context.Deuda, "DeudaId", "DeudaId", deudaDetalle.DeudaId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodo, "PeriodoId", "PeriodoId", deudaDetalle.PeriodoId);
            return View(deudaDetalle);
        }

        // GET: DeudaDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeudaDetalle == null)
            {
                return NotFound();
            }

            var deudaDetalle = await _context.DeudaDetalle.FindAsync(id);
            if (deudaDetalle == null)
            {
                return NotFound();
            }
            ViewData["DeudaId"] = new SelectList(_context.Deuda, "DeudaId", "DeudaId", deudaDetalle.DeudaId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodo, "PeriodoId", "PeriodoId", deudaDetalle.PeriodoId);
            return View(deudaDetalle);
        }

        // POST: DeudaDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeudaDetalleId,DeudaId,Importe,Recargo,FechaVencimiento,PeriodoId,Activo")] DeudaDetalle deudaDetalle)
        {
            if (id != deudaDetalle.DeudaDetalleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deudaDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeudaDetalleExists(deudaDetalle.DeudaDetalleId))
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
            ViewData["DeudaId"] = new SelectList(_context.Deuda, "DeudaId", "DeudaId", deudaDetalle.DeudaId);
            ViewData["PeriodoId"] = new SelectList(_context.Periodo, "PeriodoId", "PeriodoId", deudaDetalle.PeriodoId);
            return View(deudaDetalle);
        }

        // GET: DeudaDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DeudaDetalle == null)
            {
                return NotFound();
            }

            var deudaDetalle = await _context.DeudaDetalle
                .Include(d => d.Deuda)
                .Include(d => d.Periodo)
                .FirstOrDefaultAsync(m => m.DeudaDetalleId == id);
            if (deudaDetalle == null)
            {
                return NotFound();
            }

            return View(deudaDetalle);
        }

        // POST: DeudaDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeudaDetalle == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.DeudaDetalle'  is null.");
            }
            var deudaDetalle = await _context.DeudaDetalle.FindAsync(id);
            if (deudaDetalle != null)
            {
                _context.DeudaDetalle.Remove(deudaDetalle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeudaDetalleExists(int id)
        {
          return (_context.DeudaDetalle?.Any(e => e.DeudaDetalleId == id)).GetValueOrDefault();
        }
    }
}
