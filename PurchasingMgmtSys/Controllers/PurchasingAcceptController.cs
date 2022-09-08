using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models.DataAccess;

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
            var mmStoreSimpleDbContext = db.Record.Include(g => g.UID).Include(g => g.SID).Include(g => g.MID);
            var applicationDbContext = await mmStoreSimpleDbContext.ToListAsync();
            return View(applicationDbContext);
        }

        public async Task<IActionResult> Accept(string id)
        {
            //var user = await db.Users.FindAsync(id);
            //db.Users.Remove(user);
            //await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}