using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Web.Data;
using BookStore.Web.Data.Entity;

namespace BookStore.Web.Controllers
{
    public class BookGenresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookGenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BookGenres
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookGenres.Include(b => b.Book).Include(b => b.Genre);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BookGenres/Details/5
        public async Task<IActionResult> Details(int? IdGenre, int? IdBook)
        {
            if (IdBook == null||IdGenre==null)
            {
                return NotFound();
            }

            var bookGenre = await _context.BookGenres
                .Include(b => b.Book)
                .Include(b => b.Genre)
                .Where(g=>g.IdGenre==IdGenre)
                .FirstOrDefaultAsync(b => b.IdBook == IdBook);
            if (bookGenre == null)
            {
                return NotFound();
            }

            return View(bookGenre);
        }

        // GET: BookGenres/Create
        public IActionResult Create()
        {
            ViewData["IdBook"] = new SelectList(_context.Books, "Id", "Title");
            ViewData["IdGenre"] = new SelectList(_context.Genre, "Id", "Name");
            return View();
        }

        // POST: BookGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBook,IdGenre")] BookGenre bookGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdBook"] = new SelectList(_context.Books, "Id", "Id", bookGenre.IdBook);
            ViewData["IdGenre"] = new SelectList(_context.Genre, "Id", "Id", bookGenre.IdGenre);
            return View(bookGenre);
        }

        // GET: BookGenres/Edit/5
        public async Task<IActionResult> Edit(int? IdGenre, int? IdBook)
        {
            if (IdBook == null||IdGenre==null)
            {
                return NotFound();
            }

            var bookGenre = await _context.BookGenres.Where(g=>g.IdGenre==IdGenre).FirstAsync(b => b.IdBook == IdBook);
            if (bookGenre == null)
            {
                return NotFound();
            }
            ViewData["IdBook"] = new SelectList(_context.Books, "Id", "Id", bookGenre.IdBook);
            ViewData["IdGenre"] = new SelectList(_context.Genre, "Id", "Id", bookGenre.IdGenre);
            return View(bookGenre);
        }

        // POST: BookGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int IdBook,int IdGenre, [Bind("IdBook,IdGenre")] BookGenre bookGenre)
        {
            if (IdGenre != bookGenre.IdGenre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookGenreExists(bookGenre.IdGenre))
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
            ViewData["IdBook"] = new SelectList(_context.Books, "Id", "Id", bookGenre.IdBook);
            ViewData["IdGenre"] = new SelectList(_context.Genre, "Id", "Id", bookGenre.IdGenre);
            return View(bookGenre);
        }

        // GET: BookGenres/Delete/5
        public async Task<IActionResult> Delete(int? IdGenre, int? IdBook)
        {
            if (IdGenre==null||IdBook==null)
            {
                return NotFound();
            }

            var bookGenre = await _context.BookGenres
                .Include(b => b.Book)
                .Include(b => b.Genre)
                .Where(g=>g.IdGenre==IdGenre)
                .FirstOrDefaultAsync(b => b.IdBook == IdBook);
            if (bookGenre == null)
            {
                return NotFound();
            }

            return View(bookGenre);
        }

        // POST: BookGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookGenre = await _context.BookGenres.FindAsync(id);
            if (bookGenre != null)
            {
                _context.BookGenres.Remove(bookGenre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookGenreExists(int id)
        {
            return _context.BookGenres.Any(e => e.IdGenre == id);
        }
    }
}
