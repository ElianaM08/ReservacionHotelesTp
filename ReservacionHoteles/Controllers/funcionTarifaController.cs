using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReservacionHoteles.Models;
using ReservacionHoteles.Repos;

namespace ReservacionHoteles.Controllers
{
    public class funcionTarifaController : Controller
    {
        private readonly ReservacionHotelesContext _context;

        public funcionTarifaController(ReservacionHotelesContext context)
        {
            _context = context;
        }

        // GET: funcionTarifa
        public async Task<IActionResult> Index()
        {
            var reservacionHotelesContext = _context.FuncionTarifas.Include(f => f.Tarifa);
            return View(await reservacionHotelesContext.ToListAsync());
        }

        // GET: funcionTarifa/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FuncionTarifas == null)
            {
                return NotFound();
            }

            var funcionTarifa = await _context.FuncionTarifas
                .Include(f => f.Tarifa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionTarifa == null)
            {
                return NotFound();
            }

            return View(funcionTarifa);
        }

        // GET: funcionTarifa/Create
        public IActionResult Create()
        {
            ViewData["TarifaRefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion");
            return View();
        }

        // POST: funcionTarifa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TarifaRefId,FuncionId,Created")] funcionTarifa funcionTarifa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionTarifa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TarifaRefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", funcionTarifa.TarifaRefId);
            return View(funcionTarifa);
        }

        // GET: funcionTarifa/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FuncionTarifas == null)
            {
                return NotFound();
            }

            var funcionTarifa = await _context.FuncionTarifas.FindAsync(id);
            if (funcionTarifa == null)
            {
                return NotFound();
            }
            ViewData["TarifaRefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", funcionTarifa.TarifaRefId);
            return View(funcionTarifa);
        }

        // POST: funcionTarifa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TarifaRefId,FuncionId,Created")] funcionTarifa funcionTarifa)
        {
            if (id != funcionTarifa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionTarifa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!funcionTarifaExists(funcionTarifa.Id))
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
            ViewData["TarifaRefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", funcionTarifa.TarifaRefId);
            return View(funcionTarifa);
        }

        // GET: funcionTarifa/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FuncionTarifas == null)
            {
                return NotFound();
            }

            var funcionTarifa = await _context.FuncionTarifas
                .Include(f => f.Tarifa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionTarifa == null)
            {
                return NotFound();
            }

            return View(funcionTarifa);
        }

        // POST: funcionTarifa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FuncionTarifas == null)
            {
                return Problem("Entity set 'ReservacionHotelesContext.FuncionTarifas'  is null.");
            }
            var funcionTarifa = await _context.FuncionTarifas.FindAsync(id);
            if (funcionTarifa != null)
            {
                _context.FuncionTarifas.Remove(funcionTarifa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool funcionTarifaExists(int id)
        {
          return (_context.FuncionTarifas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
