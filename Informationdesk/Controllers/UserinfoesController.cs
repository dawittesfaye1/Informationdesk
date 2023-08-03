using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InformationDesk.Models;
using Informationdesk.Data;

namespace Informationdesk.Controllers
{
    public class UserinfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserinfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Userinfoes
        public async Task<IActionResult> Index()
        {
              return _context.Userinfo != null ? 
                          View(await _context.Userinfo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Userinfo'  is null.");
        }

        // GET: Userinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Userinfo == null)
            {
                return NotFound();
            }

            var userinfo = await _context.Userinfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userinfo == null)
            {
                return NotFound();
            }

            return View(userinfo);
        }

        // GET: Userinfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Userinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,OfiiceNumber,PhoneNumber,FloorNumber")] Userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userinfo);
        }

        // GET: Userinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Userinfo == null)
            {
                return NotFound();
            }

            var userinfo = await _context.Userinfo.FindAsync(id);
            if (userinfo == null)
            {
                return NotFound();
            }
            return View(userinfo);
        }

        // POST: Userinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,OfiiceNumber,PhoneNumber,FloorNumber")] Userinfo userinfo)
        {
            if (id != userinfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserinfoExists(userinfo.Id))
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
            return View(userinfo);
        }

        // GET: Userinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Userinfo == null)
            {
                return NotFound();
            }

            var userinfo = await _context.Userinfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userinfo == null)
            {
                return NotFound();
            }

            return View(userinfo);
        }

        // POST: Userinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Userinfo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Userinfo'  is null.");
            }
            var userinfo = await _context.Userinfo.FindAsync(id);
            if (userinfo != null)
            {
                _context.Userinfo.Remove(userinfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserinfoExists(int id)
        {
          return (_context.Userinfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
