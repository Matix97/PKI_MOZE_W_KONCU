using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DotNetCoreSqlDb.Models;

namespace DotNetCoreSqlDb.Controllers
{
    public class NoteSetController : Controller
    {
        private readonly MyDatabaseContext _context;

        public NoteSetController(MyDatabaseContext context)
        {
            _context = context;    
        }

        // GET: NoteSet
        public async Task<IActionResult> Index()
        {
            return View(await _context.NoteSet.ToListAsync());
        }

           // GET: Todos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adres = await _context.NoteSet
                .SingleOrDefaultAsync(m => m.note_id == id);
            if (adres == null)
            {
                return NotFound();
            }

            return View(adres);
        }

        // GET: Todos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("note_id,category,main_name,long_description,tags")] NoteSet adres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adres);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(adres);
        }

        // GET: Todos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adres = await _context.NoteSet.SingleOrDefaultAsync(m => m.note_id == id);
            if (adres == null)
            {
                return NotFound();
            }
            return View(adres);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("note_id,category,main_name,long_description,tags")] NoteSet adres)
        {
            if (id != adres.note_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlientExists(adres.note_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(adres);
        }

        // GET: Todos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adres = await _context.NoteSet
                .SingleOrDefaultAsync(m => m.note_id == id);
            if (adres == null)
            {
                return NotFound();
            }

            return View(adres);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adres = await _context.NoteSet.SingleOrDefaultAsync(m => m.note_id == id);
            _context.NoteSet.Remove(adres);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool KlientExists(int id)
        {
            return _context.NoteSet.Any(e => e.note_id == id);
        }





    }
}
