﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PoniPortfolio.Data;
using PoniPortfolio.Models;

namespace PoniPortfolio.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class QualificationsController : Controller
    {
        private readonly PoniPortfolioContext _context;

        public QualificationsController(PoniPortfolioContext context)
        {
            _context = context;
        }

        // GET: Qualifications
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Qualifications.ToListAsync());
        }
        public async Task<IActionResult> Admin()
        {
            return View(await _context.Qualifications.ToListAsync());
        }

        // GET: Qualifications/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualifications = await _context.Qualifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qualifications == null)
            {
                return NotFound();
            }

            return View(qualifications);
        }

        // GET: Qualifications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Qualification,Major,Institution,IsFeatured,Completed")] Qualifications qualifications)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qualifications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qualifications);
        }

        // GET: Qualifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualifications = await _context.Qualifications.FindAsync(id);
            if (qualifications == null)
            {
                return NotFound();
            }
            return View(qualifications);
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Qualification,Major,Institution,IsFeatured,Completed")] Qualifications qualifications)
        {
            if (id != qualifications.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qualifications);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QualificationsExists(qualifications.Id))
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
            return View(qualifications);
        }

        // GET: Qualifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qualifications = await _context.Qualifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qualifications == null)
            {
                return NotFound();
            }

            return View(qualifications);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qualifications = await _context.Qualifications.FindAsync(id);
            _context.Qualifications.Remove(qualifications);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QualificationsExists(int id)
        {
            return _context.Qualifications.Any(e => e.Id == id);
        }
    }
}
