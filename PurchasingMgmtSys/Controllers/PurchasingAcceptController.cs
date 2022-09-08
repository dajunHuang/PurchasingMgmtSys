using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models.DataAccess;
using MVC.Models.Entities;

namespace PurchasingMgmtSys.Controllers
{
    public class PurchasingAcceptController : Controller
    {
        private readonly ApplicationDbContext db;

        public PurchasingAcceptController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var mmStoreSimpleDbContext = db.Record.Include(g => g.UID).Include(g => g.SID).Include(g => g.MID).OrderBy(g => g.State);
            var applicationDbContext = await mmStoreSimpleDbContext.ToListAsync();
            return View(applicationDbContext);
        }

        public async Task<IActionResult> Accept(int id)
        {
            Record record = db.Record.FirstOrDefault(p => p.RID == id);
            record.State = 1;
            db.Update(record);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}