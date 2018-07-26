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
    public class UnavailableTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnavailableTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UnavailableTimes
        public async Task<IActionResult> Index()
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);//gets the userId 

            var applicationDbContext = _context.UnavailableTime.Where(j => j.IdNumber == UserId);//selects Schedules with specific userid
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UnavailableTimes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unavailableTime = await _context.UnavailableTime
                .SingleOrDefaultAsync(m => m.ID == id);
            if (unavailableTime == null)
            {
                return NotFound();
            }

            return View(unavailableTime);
        }

        // GET: UnavailableTimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnavailableTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IdNumber,Day,BeginningTime,EndTime")] UnavailableTime unavailableTime)
        {
            if (ModelState.IsValid)
            {
                unavailableTime.ID = Guid.NewGuid();
                _context.Add(unavailableTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unavailableTime);
        }

        // GET: UnavailableTimes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unavailableTime = await _context.UnavailableTime.SingleOrDefaultAsync(m => m.ID == id);
            if (unavailableTime == null)
            {
                return NotFound();
            }
            return View(unavailableTime);
        }

        // POST: UnavailableTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,IdNumber,Day,BeginningTime,EndTime")] UnavailableTime unavailableTime)
        {
            if (id != unavailableTime.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unavailableTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnavailableTimeExists(unavailableTime.ID))
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
            return View(unavailableTime);
        }

        // GET: UnavailableTimes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unavailableTime = await _context.UnavailableTime
                .SingleOrDefaultAsync(m => m.ID == id);
            if (unavailableTime == null)
            {
                return NotFound();
            }

            return View(unavailableTime);
        }

        // POST: UnavailableTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var unavailableTime = await _context.UnavailableTime.SingleOrDefaultAsync(m => m.ID == id);
            _context.UnavailableTime.Remove(unavailableTime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnavailableTimeExists(Guid id)
        {
            return _context.UnavailableTime.Any(e => e.ID == id);
        }
    }
}
