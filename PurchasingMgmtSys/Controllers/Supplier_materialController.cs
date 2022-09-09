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
    public class Supplier_materialController : Controller
    {
        private readonly ApplicationDbContext db;

        public Supplier_materialController(ApplicationDbContext db)
        {
            this.db = db;
        }

        // GET: Material_message
        public async Task<IActionResult> Index()
        {
            var mmStoreSimpleDbContext = db.Supplier_material.Include(g=>g.SID).Include(g=>g.MID);
            var applicationDbContext = await mmStoreSimpleDbContext.ToListAsync();
            return View(applicationDbContext);
        }

        // GET:  Material_message/Create
        public IActionResult Create()
        {
            var ss = from b in db.Supplier_message
                     orderby b.FactoryName
                     select b;

            var ms = from b in db.Material_message
                     orderby b.MaterialName
                     select b;

            ViewBag.SID = new SelectList(ss.AsNoTracking(), "SId", "FactoryName", null);
            ViewBag.MID = new SelectList(ms.AsNoTracking(), "MID", "MaterialName", null);
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Supplier_material ss)
        {
            int MID = int.Parse(Request.Form["MID"][0]);
            int SID = int.Parse(Request.Form["SID"][0]);
            decimal Price = decimal.Parse(Request.Form["Price"][0]);
            Material_message mm = db.Material_message.FirstOrDefault(p => p.MID == MID);
            Supplier_message sm = db.Supplier_message.FirstOrDefault(p => p.SId == SID);
            Supplier_material supplier_material = new Supplier_material { MID = mm, SID = sm, Price = Price };
            if (mm != null && sm != null)
            {
                db.Add(supplier_material);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier_material);
        }

        // GET: Material_message/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier_material = await db.Supplier_material
                .Include(g => g.SID).Include(g => g.MID)
                .FirstOrDefaultAsync(m => m.NoteId == id);

            var ss = from b in db.Supplier_message
                     orderby b.FactoryName
                     select b;

            var ms = from b in db.Material_message
                     orderby b.MaterialName
                     select b;

            ViewBag.SID = new SelectList(ss.AsNoTracking(), "SId", "FactoryName", null);
            ViewBag.MID = new SelectList(ms.AsNoTracking(), "MID", "MaterialName", null);
            return View(supplier_material);
        }

        // POST: Material_message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Supplier_material ss)
        {
            if (id != ss.NoteId)
            {
                return NotFound();
            }
            int MID = int.Parse(Request.Form["MID"][0]);
            int SID = int.Parse(Request.Form["SID"][0]);
            decimal Price = decimal.Parse(Request.Form["Price"][0]);
            Material_message mm = db.Material_message.FirstOrDefault(p => p.MID == MID);
            Supplier_message sm = db.Supplier_message.FirstOrDefault(p => p.SId == SID);
            ss.MID = mm;
            ss.SID = sm;

            if (mm != null && sm != null)
            {
                try
                {
                    db.Update(ss);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(ss.NoteId))
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
            return View(ss);
        }

        // GET: Games/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier_material = await db.Supplier_material
                .Include(g => g.SID).Include(g => g.MID)
                .FirstOrDefaultAsync(m => m.NoteId == id);
            if (supplier_material == null)
            {
                return NotFound();
            }

            return View(supplier_material);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier_material = await db.Supplier_material.FindAsync(id);
            db.Supplier_material.Remove(supplier_material);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
            return db.Supplier_material.Any(e => e.NoteId == id);
        }
    }
}
