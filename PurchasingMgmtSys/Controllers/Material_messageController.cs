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
    public class Material_messageController : Controller
    {
        private readonly ApplicationDbContext db;

        public Material_messageController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET: Material_message
        public async Task<IActionResult> Index()
        {
            var mmStoreSimpleDbContext = db.Warehouse_material.Include(g => g.MID);
            var applicationDbContext = await mmStoreSimpleDbContext.ToListAsync();
            return View(applicationDbContext);
        }

        // GET: Material_message/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material_message = await db.Material_message
                .FirstOrDefaultAsync(m => m.MID == id);
            if (material_message == null)
            {
                return NotFound();
            }

            return View(material_message);
        }

        public async Task<IActionResult> Categories()
        {
            var applicationDbContext = await db.Material_message.ToListAsync();
            return View(applicationDbContext);
        }

        // GET:  Material_message/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MID,MaterialName")]Material_message material_message)
        {
            if (ModelState.IsValid)
            {
                db.Add(material_message);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Categories));
            }
            return View(material_message);
        }

        // GET: Material_message/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material_message = await db.Material_message.FindAsync(id);
            if (material_message == null)
            {
                return NotFound();
            }
            return View(material_message);
        }

        // POST: Material_message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MID,MaterialName")] Material_message material_message)
        {
            if (id != material_message.MID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(material_message);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material_message.MID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Categories));
            }
            return View(material_message);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material_message = await db.Material_message
                .FirstOrDefaultAsync(m => m.MID == id);
            if (material_message == null)
            {
                return NotFound();
            }

            return View(material_message);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material_message = await db.Material_message.FindAsync(id);
            db.Material_message.Remove(material_message);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Categories));
        }

        private bool MaterialExists(int id)
        {
            return db.Material_message.Any(e => e.MID == id);
        }
    }
}
