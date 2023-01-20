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
    public class PagoDetallesController : Controller
    {
        private readonly ODAMuniDBContext _context;

        public PagoDetallesController(ODAMuniDBContext context)
        {
            _context = context;
        }

        // GET: PagoDetalles
        public async Task<IActionResult> Index()
        {
            var oDAMuniDBContext = _context.PagoDetalle.Include(p => p.Persona);
            return View(await oDAMuniDBContext.ToListAsync());
        }

        // GET: PagoDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PagoDetalle == null)
            {
                return NotFound();
            }

            var pagoDetalle = await _context.PagoDetalle
                .Include(p => p.Persona)
                .FirstOrDefaultAsync(m => m.PagoDetalleId == id);
            if (pagoDetalle == null)
            {
                return NotFound();
            }

            return View(pagoDetalle);
        }

        // GET: PagoDetalles/Create
        public IActionResult Create()
        {
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId");
            return View();
        }

        // POST: PagoDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagoDetalleId,collection_id,collection_status,external_reference,payment_type,merchant_order_id,preference_id,site_id,processing_mode,merchant_account_id,Fecha,Activo,total_paid_amount,net_received_amount,transaction_amount,SecuenciaId,PersonaId")] PagoDetalle pagoDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagoDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", pagoDetalle.PersonaId);
            return View(pagoDetalle);
        }

        // GET: PagoDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PagoDetalle == null)
            {
                return NotFound();
            }

            var pagoDetalle = await _context.PagoDetalle.FindAsync(id);
            if (pagoDetalle == null)
            {
                return NotFound();
            }
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", pagoDetalle.PersonaId);
            return View(pagoDetalle);
        }

        // POST: PagoDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagoDetalleId,collection_id,collection_status,external_reference,payment_type,merchant_order_id,preference_id,site_id,processing_mode,merchant_account_id,Fecha,Activo,total_paid_amount,net_received_amount,transaction_amount,SecuenciaId,PersonaId")] PagoDetalle pagoDetalle)
        {
            if (id != pagoDetalle.PagoDetalleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagoDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagoDetalleExists(pagoDetalle.PagoDetalleId))
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
            ViewData["PersonaId"] = new SelectList(_context.Persona, "PersonaId", "PersonaId", pagoDetalle.PersonaId);
            return View(pagoDetalle);
        }

        // GET: PagoDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PagoDetalle == null)
            {
                return NotFound();
            }

            var pagoDetalle = await _context.PagoDetalle
                .Include(p => p.Persona)
                .FirstOrDefaultAsync(m => m.PagoDetalleId == id);
            if (pagoDetalle == null)
            {
                return NotFound();
            }

            return View(pagoDetalle);
        }

        // POST: PagoDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PagoDetalle == null)
            {
                return Problem("Entity set 'ODAMuniDBContext.PagoDetalle'  is null.");
            }
            var pagoDetalle = await _context.PagoDetalle.FindAsync(id);
            if (pagoDetalle != null)
            {
                _context.PagoDetalle.Remove(pagoDetalle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagoDetalleExists(int id)
        {
          return (_context.PagoDetalle?.Any(e => e.PagoDetalleId == id)).GetValueOrDefault();
        }
    }
}
