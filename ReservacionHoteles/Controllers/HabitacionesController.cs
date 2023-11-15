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
    public class HabitacionesController : Controller
    {
        private readonly ReservacionHotelesContext _context;

        public HabitacionesController(ReservacionHotelesContext context)
        {
            _context = context;
        }

        // GET: Habitaciones
        public async Task<IActionResult> Index()
        {
              return _context.Habitaciones != null ? 
                          View(await _context.Habitaciones.ToListAsync()) :
                          Problem("Entity set 'ReservacionHotelesContext.Habitaciones'  is null.");
        }

        // GET: Habitaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Habitaciones == null)
            {
                return NotFound();
            }

            var habitaciones = await _context.Habitaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habitaciones == null)
            {
                return NotFound();
            }

            return View(habitaciones);
        }

        // GET: Habitaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habitaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumHabitaciones,NumPersonas,FechaRegistro")] Habitaciones habitaciones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habitaciones);
        }

        // GET: Habitaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Habitaciones == null)
            {
                return NotFound();
            }

            var habitaciones = await _context.Habitaciones.FindAsync(id);
            if (habitaciones == null)
            {
                return NotFound();
            }
            return View(habitaciones);
        }

        // POST: Habitaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumHabitaciones,NumPersonas,FechaRegistro")] Habitaciones habitaciones)
        {
            if (id != habitaciones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionesExists(habitaciones.Id))
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
            return View(habitaciones);
        }

        // GET: Habitaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Habitaciones == null)
            {
                return NotFound();
            }

            var habitaciones = await _context.Habitaciones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (habitaciones == null)
            {
                return NotFound();
            }

            return View(habitaciones);
        }

        // POST: Habitaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Habitaciones == null)
            {
                return Problem("Entity set 'ReservacionHotelesContext.Habitaciones'  is null.");
            }
            var habitaciones = await _context.Habitaciones.FindAsync(id);
            if (habitaciones != null)
            {
                _context.Habitaciones.Remove(habitaciones);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionesExists(int id)
        {
          return (_context.Habitaciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
