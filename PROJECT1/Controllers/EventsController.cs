using Microsoft.AspNetCore.Mvc;
using PROJECT1.Models;
using Microsoft.EntityFrameworkCore;
using PROJECT1.Models.Data;

namespace PROJECT1.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var events = _context.Events.ToList();
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event events)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(events);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        public IActionResult Details(int id)
        {
            var evnt = _context.Events.Find(id);
            if (evnt == null) return NotFound();
            return View(evnt);
        }

        public IActionResult Delete(int id)
        {
            var evnt = _context.Events.Find(id);
            if (evnt != null)
            {
                _context.Events.Remove(evnt);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Events/Edit/5
        public IActionResult Edit(int id)
        {
            var evnt = _context.Events.Find(id);
            if (evnt == null)
            {
                return NotFound();
            }
            return View(evnt);
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("EventID,EventName,EventDate,VenueID,EventType,Description,TicketPrice")] Event events)
        {
            if (id != events.EventID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(events.EventID))
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
            return View(events);
        }

        // Check if the event exists
        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.EventID == id);
        }
    }
}