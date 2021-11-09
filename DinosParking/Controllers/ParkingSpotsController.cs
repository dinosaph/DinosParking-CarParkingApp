using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DinosParking.Data;
using DinosParking.Models;

namespace DinosParking.Controllers
{
    public class ParkingSpotsController : Controller
    {
        private readonly DinosParkingContext _context;

        public ParkingSpotsController(DinosParkingContext context)
        {
            _context = context;
        }

        // GET: ParkingSpots
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkingSpot.ToListAsync());
        }

        // GET: ParkingSpots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpot = await _context.ParkingSpot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            return View(parkingSpot);
        }

        // GET: ParkingSpots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkingSpots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Occupant_Id")] ParkingSpot parkingSpot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingSpot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingSpot);
        }

        // GET: ParkingSpots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpot = await _context.ParkingSpot.FindAsync(id);
            if (parkingSpot == null)
            {
                return NotFound();
            }
            return View(parkingSpot);
        }

        // POST: ParkingSpots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Occupant_Id")] ParkingSpot parkingSpot)
        {
            if (id != parkingSpot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingSpot);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingSpotExists(parkingSpot.Id))
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
            return View(parkingSpot);
        }

        // GET: ParkingSpots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpot = await _context.ParkingSpot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingSpot == null)
            {
                return NotFound();
            }

            return View(parkingSpot);
        }

        // POST: ParkingSpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingSpot = await _context.ParkingSpot.FindAsync(id);
            _context.ParkingSpot.Remove(parkingSpot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingSpotExists(int id)
        {
            return _context.ParkingSpot.Any(e => e.Id == id);
        }

        public int GetCountAllParkingSpots()
        {
            int allSpots = _context.ParkingSpot.Count();
            return allSpots;
        }

        public int GetCountOccupiedParkingSpots()
        {
            int occupiedSpots = _context.ParkingSpot.Where(e => e.Occupant_Id != null).Count();
            return occupiedSpots;
        }

        public bool ExistsEmptyParkingSpot()
        {
            return GetCountAllParkingSpots() - GetCountOccupiedParkingSpots() > 0;
        }

        public void InitializeParkingSpace()
        {
            int parkingSpots = 10;

            if (_context.ParkingSpot.Any())
            {
                // No need to seed. Data already exists.
                return;
            }

            List<ParkingSpot> parkingToAdd = new List<ParkingSpot>();
            for (int i = 0; i < parkingSpots; i++)
            {
                parkingToAdd.Add(new ParkingSpot { });
            }

            _context.AddRange(parkingToAdd);
            _context.SaveChanges();
        }

        public void UpdateParkingEnter(int ticketId)
        {
            ParkingSpot luckySpot = _context.ParkingSpot.Where(e => e.Occupant_Id == null).FirstOrDefault();

            luckySpot.Occupant_Id = ticketId;

            Edit(luckySpot.Id, luckySpot);
        }

        public void UpdateParkingLeave(int ticketId)
        {
            ParkingSpot occupiedSpot = _context.ParkingSpot.Where(e => e.Occupant_Id == ticketId).FirstOrDefault();

            occupiedSpot.Occupant_Id = null;

            Edit(occupiedSpot.Id, occupiedSpot);
        }
    }
}
