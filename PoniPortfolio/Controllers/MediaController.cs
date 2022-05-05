#nullable disable
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
    public class MediaController : Controller
    {
        private readonly PoniPortfolioContext _context;

        public MediaController(PoniPortfolioContext context)
        {
            _context = context;
        }

        // GET: Media
        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
        {
            int pageIndex = page;
            int pageSize = 5;

            IQueryable<Media> mediaIQ = from m in _context.Media select m;
            mediaIQ = mediaIQ.OrderByDescending(m => m.Date);

            PagedList<Media> medias = await PagedList<Media>.CreateAsync(mediaIQ, pageIndex, pageSize);

            return View(medias);
        }
        public async Task<IActionResult> Admin(int page = 1)
        {
            int pageIndex = page;
            int pageSize = 5;

            IQueryable<Media> mediaIQ = from m in _context.Media select m;
            mediaIQ = mediaIQ.OrderByDescending(m => m.Date);

            PagedList<Media> medias = await PagedList<Media>.CreateAsync(mediaIQ, pageIndex, pageSize);

            return View(medias);
        }

        // GET: Media/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Media
                .FirstOrDefaultAsync(m => m.Id == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // GET: Media/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Media/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Source,ThumbNail,IsFeatured,Decsription,Tags,Date")] Media media)
        {
            if (ModelState.IsValid)
            {
                _context.Add(media);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(media);
        }

        // GET: Media/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Media.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }
            return View(media);
        }

        // POST: Media/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Source,ThumbNail,IsFeatured,Decsription,Tags,Date")] Media media)
        {
            if (id != media.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(media);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaExists(media.Id))
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
            return View(media);
        }

        // GET: Media/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Media
                .FirstOrDefaultAsync(m => m.Id == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // POST: Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var media = await _context.Media.FindAsync(id);
            _context.Media.Remove(media);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaExists(int id)
        {
            return _context.Media.Any(e => e.Id == id);
        }
    }
}
