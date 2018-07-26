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
    public class RequestOffsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestOffsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RequestOffs
        public async Task<IActionResult> Index()
        {
            var UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);//gets the userId 

            var applicationDbContext = _context.RequestOff.Where(j => j.IdNumber == UserId);//selects Requests off with specific userid
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RequestOffs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestOff = await _context.RequestOff
                .Include(r => r.ApplicationUser)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (requestOff == null)
            {
                return NotFound();
            }

            return View(requestOff);
        }

        // GET: RequestOffs/Create
        public IActionResult Create()
        {
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: RequestOffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IdNumber,DayOff")] RequestOff requestOff)
        {
            if (ModelState.IsValid)
            {
                requestOff.ID = Guid.NewGuid();
                _context.Add(requestOff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id", requestOff.IdNumber);
            return View(requestOff);
        }

        // GET: RequestOffs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestOff = await _context.RequestOff.SingleOrDefaultAsync(m => m.ID == id);
            if (requestOff == null)
            {
                return NotFound();
            }
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id", requestOff.IdNumber);
            return View(requestOff);
        }

        // POST: RequestOffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,IdNumber,DayOff")] RequestOff requestOff)
        {
            if (id != requestOff.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestOff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestOffExists(requestOff.ID))
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
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id", requestOff.IdNumber);
            return View(requestOff);
        }

        // GET: RequestOffs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestOff = await _context.RequestOff
                .Include(r => r.ApplicationUser)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (requestOff == null)
            {
                return NotFound();
            }

            return View(requestOff);
        }

        // POST: RequestOffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var requestOff = await _context.RequestOff.SingleOrDefaultAsync(m => m.ID == id);
            _context.RequestOff.Remove(requestOff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestOffExists(Guid id)
        {
            return _context.RequestOff.Any(e => e.ID == id);
        }
    }
}
