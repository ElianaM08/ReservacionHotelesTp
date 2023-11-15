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
    public class DisponibilidadController : Controller
    {
        private readonly ReservacionHotelesContext _context;

        public DisponibilidadController(ReservacionHotelesContext context)
        {
            _context = context;
        }

        // GET: Disponibilidad
        public async Task<IActionResult> Index()
        {
            var reservacionHotelesContext = _context.Disponibilidad.Include(d => d.Hotel).Include(d => d.Tipo);
            return View(await reservacionHotelesContext.ToListAsync());
        }

        // GET: Disponibilidad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Disponibilidad == null)
            {
                return NotFound();
            }

            var disponibilidad = await _context.Disponibilidad
                .Include(d => d.Hotel)
                .Include(d => d.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            return View(disponibilidad);
        }

        // GET: Disponibilidad/Create
        public IActionResult Create()
        {
            ViewData["HotelRefId"] = new SelectList(_context.Hotel, "Id", "Nombre");
            ViewData["TipoRefId"] = new SelectList(_context.Tipo, "Id", "Descripcion");
            return View();
        }

        // POST: Disponibilidad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoRefId,HotelRefId,FechaRegistro")] Disponibilidad disponibilidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disponibilidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelRefId"] = new SelectList(_context.Hotel, "Id", "Nombre", disponibilidad.HotelRefId);
            ViewData["TipoRefId"] = new SelectList(_context.Tipo, "Id", "Descripcion", disponibilidad.TipoRefId);
            return View(disponibilidad);
        }

        // GET: Disponibilidad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Disponibilidad == null)
            {
                return NotFound();
            }

            var disponibilidad = await _context.Disponibilidad.FindAsync(id);
            if (disponibilidad == null)
            {
                return NotFound();
            }
            ViewData["HotelRefId"] = new SelectList(_context.Hotel, "Id", "Nombre", disponibilidad.HotelRefId);
            ViewData["TipoRefId"] = new SelectList(_context.Tipo, "Id", "Descripcion", disponibilidad.TipoRefId);
            return View(disponibilidad);
        }

        // POST: Disponibilidad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoRefId,HotelRefId,FechaRegistro")] Disponibilidad disponibilidad)
        {
            if (id != disponibilidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disponibilidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisponibilidadExists(disponibilidad.Id))
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
            ViewData["HotelRefId"] = new SelectList(_context.Hotel, "Id", "Nombre", disponibilidad.HotelRefId);
            ViewData["TipoRefId"] = new SelectList(_context.Tipo, "Id", "Descripcion", disponibilidad.TipoRefId);
            return View(disponibilidad);
        }

        // GET: Disponibilidad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Disponibilidad == null)
            {
                return NotFound();
            }

            var disponibilidad = await _context.Disponibilidad
                .Include(d => d.Hotel)
                .Include(d => d.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            return View(disponibilidad);
        }

        // POST: Disponibilidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Disponibilidad == null)
            {
                return Problem("Entity set 'ReservacionHotelesContext.Disponibilidad'  is null.");
            }
            var disponibilidad = await _context.Disponibilidad.FindAsync(id);
            if (disponibilidad != null)
            {
                _context.Disponibilidad.Remove(disponibilidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisponibilidadExists(int id)
        {
          return (_context.Disponibilidad?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
