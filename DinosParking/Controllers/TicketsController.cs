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
    public class TicketsController : Controller
    {
        private readonly DinosParkingContext _context;

        public TicketsController(DinosParkingContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ticket.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Car_Number,Time_In,BarCode,Time_Out,Total_Fee")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Car_Number,Time_In,BarCode,Time_Out,Total_Fee")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
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
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }

        private string GenerateRandText(int requestedLength)
        {
            Random x = new Random();
            int txtLen = requestedLength;
            string randTxt = "";
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 0; i < txtLen; i++)
            {
                randTxt += chars[x.Next(chars.Length)];
            }

            return randTxt;
        }

        private string GetCarNumber()
        {
            Random x = new Random();
            string carNum = "";

            List<String> countyList = new List<string> { "NT", "B", "SV", "BT", "B", "CT", "VS", "IS" };
            int countyIndex = x.Next(countyList.Count());
            int carInt = x.Next(10, 999);
            string carChars = GenerateRandText(3);

            carNum += countyList[countyIndex] + carInt + carChars;

            return carNum;
        }

        public IActionResult NewTicket()
        {
            var parkingController = new ParkingSpotsController(_context);

            if (parkingController.ExistsEmptyParkingSpot())
            {
                string newCarNum = GetCarNumber();
                DateTime newTimeIn = DateTime.Now;
                string newBarcode = newCarNum + newTimeIn.Hour + newTimeIn.Minute + newTimeIn.Day + newTimeIn.Month;
                string barcodeUrl = "https://barcode.tec-it.com/barcode.ashx?data=" + newBarcode + "&code=Code128&translate-esc=on";
                ViewData["barcodeUrl"] = barcodeUrl;
                Console.WriteLine(newCarNum);

                Ticket t = new Ticket { Car_Number = newCarNum, Time_In = newTimeIn, BarCode = newBarcode };
                Create(t);
                parkingController.UpdateParkingEnter(t.Id);

                return View(t);
            } else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Scan()
        {
            return View();
        }

        public IActionResult ScanTicket(string inputBarcode)
        {
            Console.WriteLine(inputBarcode);
            if (!String.IsNullOrEmpty(inputBarcode))
            {
                //tickets = tickets.Where(t => t.BarCode!.Contains(inputBarcode));
                Ticket t = _context.Ticket.Where(t => t.BarCode == inputBarcode && t.Time_Out == null).FirstOrDefault();
                if (t != null)
                {
                    Console.WriteLine(t.BarCode);
                    DateTime timeOut = DateTime.Now;
                    int totalFee = GetParkingFee(timeOut);

                    t.Time_Out = timeOut;
                    t.Total_Fee = totalFee;

                    Edit(t.Id, t);

                    var parkingController = new ParkingSpotsController(_context);
                    parkingController.UpdateParkingLeave(t.Id);

                    return View("NewSummary");
                }
            }
            return View("Scan");
        }

        private int GetParkingFee(DateTime timeOut)
        {
            return 10;
        }

        public IActionResult NewSummary()
        {
            return View();
        }
    }
}
