using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Models.DataAccess;
using MVC.Models.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MVC.Controllers
{
    [Authorize]
    public class Supplier_messageController : Controller
    {
        private readonly ApplicationDbContext db;

        public Supplier_messageController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET: Supplier_message
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await db.Supplier_message.ToListAsync();
            return View(applicationDbContext);
        }

        // GET: Supplier_message/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplier_message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SId,FactoryName,Director")] Supplier_message supplier_message)
        {
            if (ModelState.IsValid)
            {
                db.Add(supplier_message);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier_message);
        }

        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier_message = await db.Supplier_message.FindAsync(id);
            if (supplier_message == null)
            {
                return NotFound();
            }
            return View(supplier_message);
        }

        // POST: Supplier_message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SId,FactoryName,Director")] Supplier_message supplier_message)
        {
            if (id != supplier_message.SId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(supplier_message);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Supplier_messageExists(supplier_message.SId))
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
            return View(supplier_message);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier_message = await db.Supplier_message
                .FirstOrDefaultAsync(m => m.SId == id);
            if (supplier_message == null)
            {
                return NotFound();
            }

            return View(supplier_message);
        }

        // POST: Supplier_message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier_message = await db.Supplier_message.FindAsync(id);
            db.Supplier_message.Remove(supplier_message);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Supplier_messageExists(int id)
        {
            return db.Supplier_message.Any(e => e.SId == id);
        }
    }
}
