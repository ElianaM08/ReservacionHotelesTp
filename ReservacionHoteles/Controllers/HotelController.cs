using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReservacionHoteles.Migrations;
using ReservacionHoteles.Models;
using ReservacionHoteles.Repos;
using ReservacionHoteles.ViewModels;

namespace ReservacionHoteles.Controllers
{
    public class HotelController : Controller
    {
        private readonly ReservacionHotelesContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HotelController(ReservacionHotelesContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Hotel
        public async Task<IActionResult> Index()
        {
              return _context.Hotel != null ? 
                          View(await _context.Hotel.ToListAsync()) :
                          Problem("Entity set 'ReservacionHotelesContext.Hotel'  is null.");
        }

        // GET: Hotel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hotel == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotel/Create
        public IActionResult Create()
        {
            ViewData["DestinosRefId"] = new SelectList(_context.Destinos, "Id", "Descripcion");
            ViewData["TipoRefId"] = new SelectList(_context.Tipo, "Id", "Descripcion");
            return View();
        }

        // POST: Hotel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HotelViewModels model)
        {


            string uniqueFileName = UploadedFile(model);

            if (ModelState.IsValid)
            {
                Hotel hotel = new Hotel()
                {
                    Nombre = model.Nombre,
                    ImagemHotel = uniqueFileName,
                    Calificacion = model.Calificacion,
                    Descripcion = model.Descripcion,
                    FechaEntrada = model.FechaEntrada,
                    FechaSalida = model.FechaSalida,
                    FechaRegistro = model.FechaRegistro,
                    DestinosRefId = model.DestinosRefId,
                    TipoRefId = model.TipoRefId,


                };
                 _context.Add(hotel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
          

            ViewData["DestinosRefId"] = new SelectList(_context.Destinos, "Id", "Descripcion", model.DestinosRefId);
            ViewData["TipoRefId"] = new SelectList(_context.Tipo, "Id", "Descripcion", model.TipoRefId);
            return View(model);
        }

        private string UploadedFile(HotelViewModels model)
        {
            string uniqueFileName = null;

            if (model.ImagemHotel != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagemHotel.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagemHotel.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: Hotel/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{

        //    if (id == null || _context.Hotel == null)
        //    {
        //        return NotFound();
        //    }

        //    var pelicula = await _context.Hotel.FindAsync(id);

            
            
        //        //HotelViewModels hotelViewModel = new HotelViewModels()
        //        //{
        //        //    Nombre = Hotel.Nombre,
                    
        //        //    Calificacion = hotel.Calificacion,
        //        //    Descripcion = hotel.Descripcion,
        //        //    FechaEntrada = hotel.FechaEntrada,
        //        //    FechaSalida = Hotel.FechaSalida,
        //        //    FechaRegistro = hotel.FechaRegistro,
        //        //    DestinosRefId = hotel.DestinosRefId,
        //        //    TipoRefId = hotel.TipoRefId,


        //        //};
        //        //_context.Add(hotelViewModel);
        //        //await _context.SaveChangesAsync();
        //        //return RedirectToAction(nameof(Index));



        //}

        // POST: Hotel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,ImagemHotel,Destino,Clasificacion,FechaEntrada,FechaSalida")] Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.Id))
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
            return View(hotel);
        }

        // GET: Hotel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hotel == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hotel == null)
            {
                return Problem("Entity set 'ReservacionHotelesContext.Hotel'  is null.");
            }
            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel != null)
            {
                _context.Hotel.Remove(hotel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
          return (_context.Hotel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
