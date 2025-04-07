using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT1.Models.Data;
using PROJECT1.Models;

namespace PROJECT1.Controllers
{
    public class VenuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VenuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var venues = _context.Venues.ToList();
            return View(venues);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venue venue)
        {
            if (ModelState.IsValid)
            {
                _context.Venues.Add(venue);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(venue);
        }

        public IActionResult Details(int id)
        {
            var venues = _context.Venues.Find(id);
            if (venues == null)
            {
                return NotFound();
            }
            return View(venues);
        }

        public IActionResult Delete(int id)
        {
            var venues = _context.Venues.Find(id);
            if (venues != null)
            {
                _context.Venues.Remove(venues);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Venues/Edit/5
        public IActionResult Edit(int id)
        {
            var venues = _context.Venues.Find(id);
            if (venues == null)
            {
                return NotFound();
            }
            return View(venues);
        }

        // POST: Venues/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("VenueID, VenueName, Address, City, Country, Capacity")] Venue venues)
        {
            if (id != venues.VenueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venues);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenueExists(venues.VenueId))
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
            return View(venues);
        }

        private bool VenueExists(int id)
        {
            return _context.Venues.Any(v => v.VenueId == id);
        }
    }
}
