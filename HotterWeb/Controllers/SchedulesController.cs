using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotterWeb.Data;
using HotterWeb.Models;
using System.Security.Claims;

namespace HotterWeb.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);//gets the userId 

            if (_context.Manager.Any(m => m.IdNumber == UserId))
            {
                string _LocationId = _context.Manager.Where(m => m.IdNumber == UserId).Select(s => s.LocationId).SingleOrDefault();//gets location id from manager id
                var applicationDbContext = _context.Schedule.Where(j => j.LocationId == _LocationId);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                Response.Redirect("/MyStuff");
                
                var applicationDbContext = _context.Schedule.Where(j => j.IdNumber == UserId);//selects jobs with specific userid
                return View(await applicationDbContext.ToListAsync());

            }
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.ApplicationUser)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IdNumber,Day,ClockIn,ClockOut,Position,LocationId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                schedule.ID = Guid.NewGuid();
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id", schedule.IdNumber);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId", schedule.LocationId);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule.SingleOrDefaultAsync(m => m.ID == id);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id", schedule.IdNumber);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId", schedule.LocationId);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,IdNumber,Day,ClockIn,ClockOut,Position,LocationId")] Schedule schedule)
        {
            if (id != schedule.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.ID))
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
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id", schedule.IdNumber);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId", schedule.LocationId);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedule
                .Include(s => s.ApplicationUser)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var schedule = await _context.Schedule.SingleOrDefaultAsync(m => m.ID == id);
            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(Guid id)
        {
            return _context.Schedule.Any(e => e.ID == id);
        }
    }
}
