using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteAPI.Models;

namespace WebSiteAPI.Controllers
{
    public class UserTidesController : Controller
    {
        private readonly WebSiteAPIContext _context;

        public UserTidesController(WebSiteAPIContext context)
        {
            _context = context;
        }

        // GET: UserTides
        public async Task<IActionResult> Index()
        {
            var webSiteAPIContext = _context.UserTides.Include(u => u.Tides).Include(u => u.User);
            return View(await webSiteAPIContext.ToListAsync());
        }

        // GET: UserTides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTide = await _context.UserTides
                .Include(u => u.Tides)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserTidesId == id);
            if (userTide == null)
            {
                return NotFound();
            }

            return View(userTide);
        }

        // GET: UserTides/Create
        public IActionResult Create()
        {
            ViewData["TidesId"] = new SelectList(_context.Tides, "TidesId", "TideType");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: UserTides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserTidesId,UserId,TidesId")] UserTide userTide)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTide);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TidesId"] = new SelectList(_context.Tides, "TidesId", "TideType", userTide.TidesId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", userTide.UserId);
            return View(userTide);
        }

        // GET: UserTides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTide = await _context.UserTides.FindAsync(id);
            if (userTide == null)
            {
                return NotFound();
            }
            ViewData["TidesId"] = new SelectList(_context.Tides, "TidesId", "TideType", userTide.TidesId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", userTide.UserId);
            return View(userTide);
        }

        // POST: UserTides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserTidesId,UserId,TidesId")] UserTide userTide)
        {
            if (id != userTide.UserTidesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTide);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTideExists(userTide.UserTidesId))
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
            ViewData["TidesId"] = new SelectList(_context.Tides, "TidesId", "TideType", userTide.TidesId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", userTide.UserId);
            return View(userTide);
        }

        // GET: UserTides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTide = await _context.UserTides
                .Include(u => u.Tides)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserTidesId == id);
            if (userTide == null)
            {
                return NotFound();
            }

            return View(userTide);
        }

        // POST: UserTides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTide = await _context.UserTides.FindAsync(id);
            _context.UserTides.Remove(userTide);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTideExists(int id)
        {
            return _context.UserTides.Any(e => e.UserTidesId == id);
        }
    }
}
