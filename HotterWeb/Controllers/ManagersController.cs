﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotterWeb.Data;
using HotterWeb.Models;

namespace HotterWeb.Controllers
{
    public class ManagersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Managers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Manager.Include(m => m.ApplicationUser).Include(m => m.Location);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Managers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager
                .Include(m => m.ApplicationUser)
                .Include(m => m.Location)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        // GET: Managers/Create
        public IActionResult Create()
        {
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId");
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdNumber,LocationId")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                manager.Id = Guid.NewGuid();
                _context.Add(manager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id", manager.IdNumber);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId", manager.LocationId);
            return View(manager);
        }

        // GET: Managers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager.SingleOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id", manager.IdNumber);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId", manager.LocationId);
            return View(manager);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,IdNumber,LocationId")] Manager manager)
        {
            if (id != manager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManagerExists(manager.Id))
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
            ViewData["IdNumber"] = new SelectList(_context.Users, "Id", "Id", manager.IdNumber);
            ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId", manager.LocationId);
            return View(manager);
        }

        // GET: Managers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manager = await _context.Manager
                .Include(m => m.ApplicationUser)
                .Include(m => m.Location)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (manager == null)
            {
                return NotFound();
            }

            return View(manager);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var manager = await _context.Manager.SingleOrDefaultAsync(m => m.Id == id);
            _context.Manager.Remove(manager);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManagerExists(Guid id)
        {
            return _context.Manager.Any(e => e.Id == id);
        }
    }
}
