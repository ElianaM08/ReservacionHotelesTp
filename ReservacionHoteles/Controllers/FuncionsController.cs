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
    public class FuncionsController : Controller
    {
        private readonly ReservacionHotelesContext _context;

        public FuncionsController(ReservacionHotelesContext context)
        {
            _context = context;
        }

        // GET: Funcions
        public async Task<IActionResult> Index()
        {
            var reservacionHotelesContext = _context.Funcion.Include(f => f.Destinos).Include(f => f.Habitaciones).Include(f => f.Hotel);
            return View(await reservacionHotelesContext.ToListAsync());
        }

        // GET: Funcions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funcion == null)
            {
                return NotFound();
            }

            var funcion = await _context.Funcion
                .Include(f => f.Destinos)
                .Include(f => f.Habitaciones)
                .Include(f => f.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcion == null)
            {
                return NotFound();
            }

            return View(funcion);
        }

        // GET: Funcions/Create
        public IActionResult Create()
        {
            ViewData["DestinoRefId"] = new SelectList(_context.Destinos, "Id", "Descripcion");
            ViewData["HabitacionesRefId"] = new SelectList(_context.Habitaciones, "Id", "NumeroHabitaciones");
            ViewData["HotelRefId"] = new SelectList(_context.Hotel, "Id", "Nombre");
            return View();
        }

        // POST: Funcions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaHoraEntrada,FechaHoraSalida,HotelRefId,DestinoRefId,HabitacionesRefId,FechaRegistro")] Funcion funcion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DestinoRefId"] = new SelectList(_context.Destinos, "Id", "Descripcion", funcion.DestinoRefId);
            ViewData["HabitacionesRefId"] = new SelectList(_context.Habitaciones, "Id", "NumeroHabitaciones", funcion.HabitacionesRefId);
            ViewData["HotelRefId"] = new SelectList(_context.Hotel, "Id", "Nombre", funcion.HotelRefId);
            return View(funcion);
        }

        // GET: Funcions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Funcion == null)
            {
                return NotFound();
            }

            var funcion = await _context.Funcion.FindAsync(id);
            if (funcion == null)
            {
                return NotFound();
            }
            ViewData["DestinoRefId"] = new SelectList(_context.Destinos, "Id", "Descripcion", funcion.DestinoRefId);
            ViewData["HabitacionesRefId"] = new SelectList(_context.Habitaciones, "Id", "NumeroHabitaciones", funcion.HabitacionesRefId);
            ViewData["HotelRefId"] = new SelectList(_context.Hotel, "Id", "Nombre", funcion.HotelRefId);
            return View(funcion);
        }

        // POST: Funcions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaHoraEntrada,FechaHoraSalida,HotelRefId,DestinoRefId,HabitacionesRefId,FechaRegistro")] Funcion funcion)
        {
            if (id != funcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionExists(funcion.Id))
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
            ViewData["DestinoRefId"] = new SelectList(_context.Destinos, "Id", "Descripcion", funcion.DestinoRefId);
            ViewData["HabitacionesRefId"] = new SelectList(_context.Habitaciones, "Id", "NumeroHabitaciones", funcion.HabitacionesRefId);
            ViewData["HotelRefId"] = new SelectList(_context.Hotel, "Id", "Nombre", funcion.HotelRefId);
            return View(funcion);
        }

        // GET: Funcions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funcion == null)
            {
                return NotFound();
            }

            var funcion = await _context.Funcion
                .Include(f => f.Destinos)
                .Include(f => f.Habitaciones)
                .Include(f => f.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcion == null)
            {
                return NotFound();
            }

            return View(funcion);
        }

        // POST: Funcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funcion == null)
            {
                return Problem("Entity set 'ReservacionHotelesContext.Funcion'  is null.");
            }
            var funcion = await _context.Funcion.FindAsync(id);
            if (funcion != null)
            {
                _context.Funcion.Remove(funcion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionExists(int id)
        {
          return (_context.Funcion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
