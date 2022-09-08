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


        public Records1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Records1
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Record.Include(r => r.SID).Include(r => r.MID).Include(r => r.UID);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Records1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Record
                .Include(r => r.SID)
                .Include(r => r.UID)
                .FirstOrDefaultAsync(m => m.RID == id);
            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // GET: Records1/Create
        public IActionResult Create()
        {
            var ss = from b in _context.Supplier_message
                     orderby b.FactoryName
                     select b;
            var ms = from b in _context.Material_message
                     orderby b.MaterialName
                     select b;
            var us = from b in _context.Users
                     orderby b.UserName
                     select b;
            ViewBag.SID = new SelectList(ss.AsNoTracking(), "SId", "SId", null);
            
            ViewBag.MID = new SelectList(ms.AsNoTracking(), "MID", "MID", null);
            
            ViewBag.UID = new SelectList(us.AsNoTracking(), "Id", "Id", null);
            
    
            return View();
        }

        // POST: Records1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Record record)
        {
            int MID = int.Parse(Request.Form["MID"][0]);
            int SID = int.Parse(Request.Form["SID"][0]);           
            string UID = Request.Form["UID"][0];

            decimal Price = decimal.Parse(Request.Form["Price"][0]);
            int BuyNumber = int.Parse(Request.Form["BuyNumber"][0]);
            
            DateTime time = DateTime.Now;
            Material_message mm = _context.Material_message.FirstOrDefault(p => p.MID == MID);
            Supplier_message sm = _context.Supplier_message.FirstOrDefault(p => p.SId == SID);
            IdentityUser us = _context.Users.FirstOrDefault(p => p.Id == UID);
        
            Console.WriteLine(us.Id);
            Console.WriteLine(us.Id);
            Console.WriteLine(us.Id);
            Console.WriteLine(us.Id);
            Console.WriteLine(us.Id);
            Console.WriteLine(us.Id);
            Console.WriteLine(us.Id);

            Record record1 = new Record { MID = mm, SID = sm, UID = us, BuyNumber = BuyNumber, Price = Price, State = 0, Time = time, };
            if (mm != null && sm != null)
            {
                _context.Add(record1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(record1);
                    
        }

        // GET: Records1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var record = await _context.Record.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }
           
            return View(record);
        }

        // POST: Records1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Record record)
        {
            if (id != record.RID)
            {
                return NotFound();
            }
            
            record.State = 2;

          

            if (record.State==2)
            {
                try
                {
                    _context.Update(record);
                  
                    await _context.SaveChangesAsync();
                  
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                    if (!RecordExists(record.RID))
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
           
            return View(record);
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

        private bool RecordExists(int id)
        {
            return _context.Record.Any(e => e.RID == id);
        }
    }
}
