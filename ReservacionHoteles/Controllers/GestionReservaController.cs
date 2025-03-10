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
    public class GestionReservaController : Controller
    {
        private readonly ReservacionHotelesContext _context;

        public GestionReservaController(ReservacionHotelesContext context)
        {
            _context = context;
        }

        // GET: GestionReserva
        public async Task<IActionResult> Index()
        {
            var reservacionHotelesContext = _context.GestionReservas.Include(g => g.Destinos).Include(g => g.Habitaciones).Include(g => g.Hotel).Include(g => g.Tarifa1);
            return View(await reservacionHotelesContext.ToListAsync());
        }

        // GET: GestionReserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GestionReservas == null)
            {
                return NotFound();
            }

            var gestionReserva = await _context.GestionReservas
                .Include(g => g.Destinos)
                .Include(g => g.Habitaciones)
                .Include(g => g.Hotel)
                .Include(g => g.Tarifa1)
                //.Include(g => g.Tarifa2)
                //.Include(g => g.Tarifa3)
                //.Include(g => g.Tarifa4)
                //.Include(g => g.Tarifa5)
                //.Include(g => g.Tarifa6)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestionReserva == null)
            {
                return NotFound();
            }

            return View(gestionReserva);
        }

        // GET: GestionReserva/Create
        public IActionResult Create()
        {
            ViewData["DestinosRefId"] = new SelectList(_context.Destinos, "Id", "Descripcion");
            ViewData["HabitacionesRefId"] = new SelectList(_context.Habitaciones, "Id", "NumHabitaciones", "NumPersonas");
            ViewData["HotelRefId"] = new SelectList(_context.Hotel, "Id", "Nombre");
            ViewData["Tarifa1RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion");
            //ViewData["Tarifa2RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion");
            //ViewData["Tarifa3RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion");
            //ViewData["Tarifa4RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion");
            //ViewData["Tarifa5RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion");
            //ViewData["Tarifa6RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion");
            return View();
        }

        // POST: GestionReserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaHoraEntrada,FechaHoraSalida,HotelRefId,DestinosRefId,HabitacionesRefId,Tarifa1RefId,FechaRegistro")] GestionReserva gestionReserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestionReserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var habitaciones = await _context.Habitaciones
                .Select(h => new
                {
                      ID = h.Id,
                      Descripcion = $"Habitación {h.NumHabitaciones} - {h.NumPersonas} personas"
                  })
                 .ToListAsync();
            ViewData["DestinosRefId"] = new SelectList(_context.Destinos, "Id", "Descripcion", gestionReserva.DestinosRefId);
            ViewData["HabitacionesRefId"] = new SelectList(_context.Habitaciones, "ID", "Descripcion", gestionReserva.HabitacionesRefId);
            ViewData["HotelRefId"] = new SelectList(_context.Hotel, "Id", "Nombre", gestionReserva.HotelRefId);
            ViewData["Tarifa1RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa1RefId);
            //ViewData["Tarifa2RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa2RefId);
            //ViewData["Tarifa3RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa3RefId);
            //ViewData["Tarifa4RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa4RefId);
            //ViewData["Tarifa5RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa5RefId);
            //ViewData["Tarifa6RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa6RefId);
            return View(gestionReserva);
        }

        // GET: GestionReserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GestionReservas == null)
            {
                return NotFound();
            }

            var gestionReserva = await _context.GestionReservas.FindAsync(id);
            if (gestionReserva == null)
            {
                return NotFound();
            }
            ViewData["DestinosRefId"] = new SelectList(_context.Destinos, "Id", "Descripcion", gestionReserva.DestinosRefId);
            ViewData["HabitacionesRefId"] = new SelectList(_context.Habitaciones, "Id", "NumHabitaciones", gestionReserva.DestinosRefId);
            ViewData["HotelRefId"] = new SelectList(_context.Hotel, "Id", "Nombre", gestionReserva.HotelRefId);
            ViewData["Tarifa1RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa1RefId);
            //ViewData["Tarifa2RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa2RefId);
            //ViewData["Tarifa3RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa3RefId);
            //ViewData["Tarifa4RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa4RefId);
            //ViewData["Tarifa5RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa5RefId);
            //ViewData["Tarifa6RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa6RefId);
            return View(gestionReserva);
        }

        // POST: GestionReserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaHoraEntrada,FechaHoraSalida,HotelRefId,DestinosRefId,HabitacionesRefId,Tarifa1RefId,FechaRegistro")] GestionReserva gestionReserva)
        {
            if (id != gestionReserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestionReserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestionReservaExists(gestionReserva.Id))
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
            ViewData["DestinosRefId"] = new SelectList(_context.Destinos, "Id", "Descripcion", gestionReserva.DestinosRefId);
            ViewData["HabitacionesRefId"] = new SelectList(_context.Habitaciones, "Id", "NumHabitaciones", gestionReserva.DestinosRefId);
            ViewData["HotelRefId"] = new SelectList(_context.Hotel, "Id", "Nombre", gestionReserva.HotelRefId);
            ViewData["Tarifa1RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa1RefId);
            //ViewData["Tarifa2RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa2RefId);
            //ViewData["Tarifa3RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa3RefId);
            //ViewData["Tarifa4RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa4RefId);
            //ViewData["Tarifa5RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa5RefId);
            //ViewData["Tarifa6RefId"] = new SelectList(_context.Tarifa, "Id", "Descripcion", gestionReserva.Tarifa6RefId);
            return View(gestionReserva);
        }

        // GET: GestionReserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GestionReservas == null)
            {
                return NotFound();
            }

            var gestionReserva = await _context.GestionReservas
                .Include(g => g.Destinos)
                .Include(g => g.Habitaciones)
                .Include(g => g.Hotel)
                .Include(g => g.Tarifa1)
                //.Include(g => g.Tarifa2)
                //.Include(g => g.Tarifa3)
                //.Include(g => g.Tarifa4)
                //.Include(g => g.Tarifa5)
                //.Include(g => g.Tarifa6)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestionReserva == null)
            {
                return NotFound();
            }

            return View(gestionReserva);
        }

        // POST: GestionReserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GestionReservas == null)
            {
                return Problem("Entity set 'ReservacionHotelesContext.GestionReservas'  is null.");
            }
            var gestionReserva = await _context.GestionReservas.FindAsync(id);
            if (gestionReserva != null)
            {
                _context.GestionReservas.Remove(gestionReserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GestionReservaExists(int id)
        {
          return (_context.GestionReservas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
