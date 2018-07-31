using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotterWeb.Data;
using HotterWeb.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HotterWeb.Controllers
{
    public class JobsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);//gets the userId 
            
            var applicationDbContext = _context.Job.Where(j => j.IdNumber == UserId);//selects jobs with specific userid
            return View(await applicationDbContext.ToListAsync());


            /*OG stuff
            var applicationDbContext = _context.Job.Include(j => j.ApplicationUser);
            return View(await applicationDbContext.ToListAsync());
            */
        }

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.ApplicationUser)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId");
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,JobTitle,IdNumber,LocationId")] Job job)
        {
            if (ModelState.IsValid)
            {
                
                if(job.JobTitle == "Manager" || job.JobTitle == "manager")
                {
                    var manager = new Manager() { IdNumber = job.IdNumber, LocationId = job.LocationId };//DONE: Location id is null right here,  fix!! -- Added LocationId to Create([Bind(.... in line 71 above 
                    _context.Manager.Add(manager);
                    await _context.SaveChangesAsync();

                }
                else
                {
                    job.ID = Guid.NewGuid();
                    _context.Add(job);
                    await _context.SaveChangesAsync();
                }
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId", job.LocationId);
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id", job.IdNumber);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job.SingleOrDefaultAsync(m => m.ID == id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id", job.IdNumber);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,JobTitle,IdNumber")] Job job)
        {
            if (id != job.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.ID))
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
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id", job.IdNumber);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var job = await _context.Job
                .Include(j => j.ApplicationUser)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var job = await _context.Job.SingleOrDefaultAsync(m => m.ID == id);
            _context.Job.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(Guid id)
        {
            return _context.Job.Any(e => e.ID == id);
        }
    }
}
