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
using Microsoft.AspNetCore.Identity;

namespace PurchasingMgmtSys.Controllers
{
    [Authorize]
    public class Records1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public Records1Controller(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Records1
        public async Task<IActionResult> Index()
        {
            var db = _context.Record.Where(a => a.UID.Id == _userManager.GetUserId(User));

            var applicationDbContext = db.Include(r => r.SID).Include(r => r.MID).Include(r => r.UID).OrderBy(r => r.State);

            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Records1/CreateC:\Users\djhua\Desktop\MVC\PurchasingMgmtSys\Controllers\Records1Controller.cs
        public IActionResult Create()
        {
            var ss = from b in _context.Supplier_message
                     orderby b.FactoryName
                     select b;
            var ms = from b in _context.Material_message
                     orderby b.MaterialName
                     select b;
            ViewBag.SID = new SelectList(ss.AsNoTracking(), "SId", "FactoryName", null);
            ViewBag.MID = new SelectList(ms.AsNoTracking(), "MID", "MaterialName", null);
            return View();
        }

        // POST: Records1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Record record)
        {
            int MID1 = int.Parse(Request.Form["MID"][0]);
            int SID = int.Parse(Request.Form["SID"][0]);
            int BuyNumber = int.Parse(Request.Form["BuyNumber"][0]);
            string UID = _userManager.GetUserId(User);

            decimal Price = _context.Supplier_material.FirstOrDefault(p => p.MID.MID == MID1).Price;
            
            DateTime time = DateTime.Now;
            Material_message mm = _context.Material_message.FirstOrDefault(p => p.MID == MID1);
            Supplier_message sm = _context.Supplier_message.FirstOrDefault(p => p.SId == SID);
            IdentityUser us = _context.Users.FirstOrDefault(p => p.Id == UID);

            Record record1 = new Record { MID = mm, SID = sm, UID = us, BuyNumber = BuyNumber, Price = Price, State = 0, Time = time, };
            if (mm != null && sm != null)
            {
                _context.Add(record1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(record1);
                    
        }

        public async Task<IActionResult> Edit(int id)
        {

            Record record = _context.Record.Include(g => g.MID).FirstOrDefault(p => p.RID == id);
            record.State = 2;
            _context.Update(record);
            await _context.SaveChangesAsync();

            Material_message MID1 = record.MID;
            var materials = _context.Warehouse_material.Include(g => g.MID);
            if (materials == null)
            {
                var warehouse_Material1 = new Warehouse_material
                {
                    NowNumber = record.BuyNumber,
                    MID = MID1
                };
                _context.Warehouse_material.Add(warehouse_Material1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var warehouse = materials.FirstOrDefault(p => p.MID.MID == MID1.MID);
            if (warehouse == null)
            {
                var warehouse_Material1 = new Warehouse_material
                {
                    NowNumber = record.BuyNumber,
                    MID = MID1
                };
                _context.Warehouse_material.Add(warehouse_Material1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            warehouse.NowNumber += record.BuyNumber;
            _context.Update(record);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Records1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Record
                .Include(r => r.SID)
                .Include(r => r.UID)
                .Include(r => r.MID)
                .FirstOrDefaultAsync(m => m.RID == id);
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // POST: Records1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var record = await _context.Record.FindAsync(id);
            _context.Record.Remove(record);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
