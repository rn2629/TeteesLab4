using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeteesLab4.Models;

namespace TeteesLab4.Controllers
{
    public class TeteesController : Controller
    {
        private readonly TeteesLab4Context _context;

        public TeteesController(TeteesLab4Context context)
        {
            _context = context;
        }

        // GET: Tetees
        public async Task<IActionResult> Index(string teteeCote, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Tetees
                                            orderby m.Cote
                                            select m.Cote;

            var tetees = from m in _context.Tetees
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                tetees = tetees.Where(s => s.Title.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(teteeCote))
            {
                tetees = tetees.Where(x => x.Cote == teteeCote);
            }

            var teteesCoteVM = new TeteesCoteViewModel
            {
                Cotes = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Tetees = await tetees.ToListAsync()
            };

            return View(teteesCoteVM);
        }

        // GET: Tetees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tetees = await _context.Tetees
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tetees == null)
            {
                return NotFound();
            }

            return View(tetees);
        }

        // GET: Tetees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tetees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Heure,Cote,Technique,Commentaire")] Tetees tetees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tetees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tetees);
        }


        // GET: Tetees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tetees = await _context.Tetees.SingleOrDefaultAsync(m => m.Id == id);
            if (tetees == null)
            {
                return NotFound();
            }
            return View(tetees);
        }

        // POST: Tetees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Heure,Cote,Technique,Commentaire")] Tetees tetees)
        {
            if (id != tetees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tetees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeteesExists(tetees.Id))
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
            return View(tetees);
        }

        // GET: Tetees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tetees = await _context.Tetees
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tetees == null)
            {
                return NotFound();
            }

            return View(tetees);
        }

        // POST: Tetees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tetees = await _context.Tetees.SingleOrDefaultAsync(m => m.Id == id);
            _context.Tetees.Remove(tetees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeteesExists(int id)
        {
            return _context.Tetees.Any(e => e.Id == id);
        }
    }
}
