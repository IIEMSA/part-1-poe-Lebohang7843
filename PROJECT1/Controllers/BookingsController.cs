using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT1.Models;
using PROJECT1.Models.Data;

public class BookingsController : Controller
{
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
        Console.WriteLine("BookingsController Index action hit");

        var bookings = _context.Booking.ToList();
            return View(bookings); // Make sure you return the bookings list to the view
        }

        // Other actions (Create, Edit, Delete, Details) should also be here
    


    public IActionResult Create()
    {
        ViewBag.EventID = new SelectList(_context.Events, "EventID", "EventName");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Booking booking)
    {
        if (ModelState.IsValid)
        {
            _context.Booking.Add(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.EventID = new SelectList(_context.Events, "EventID", "EventName", booking.EventID);
        return View(booking);
    }

    public IActionResult Details(int id)
    {
        var booking = _context.Booking.Find(id);
        if (booking == null) return NotFound();
        return View(booking);
    }

    public IActionResult Delete(int id)
    {
        var booking = _context.Booking.Find(id);
        if (booking != null)
        {
            _context.Booking.Remove(booking);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: Bookings/Edit/5
    public IActionResult Edit(int id)
    {
        var booking = _context.Booking.Find(id);
        if (booking == null)
        {
            return NotFound();
        }

        ViewBag.EventID = new SelectList(_context.Events, "EventID", "EventName", booking.EventID);
        return View(booking);
    }

    // POST: Bookings/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("BookingID,CustomerID,EventID,BookingDate,SeatsBooked,BookingStatus,VenueID")] Booking booking)
    {
        if (id != booking.BookingID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(booking);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(booking.BookingID))
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

        ViewBag.EventID = new SelectList(_context.Events, "EventID", "EventName", booking.EventID);
        return View(booking);
    }

    private bool BookingExists(int id)
    {
        return _context.Booking.Any(b => b.BookingID == id);
    }
}

