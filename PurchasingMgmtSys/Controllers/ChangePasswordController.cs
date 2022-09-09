using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.Models.DataAccess;

namespace PurchasingMgmtSys.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> _userManager;

        public ChangePasswordController(ApplicationDbContext db,
            UserManager<IdentityUser> userManager)
        {
            this.db = db;
            _userManager = userManager;
        }

        // GET: Games
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = await db.Users.ToListAsync();
            //applicationDbContext.RemoveAt(applicationDbContext.Count-1); //删除管理员那一条记录
            applicationDbContext.RemoveAt(0);
            return View(applicationDbContext);
        }


        // GET: Games/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            ChangePasswordViewModel changePassword = new ChangePasswordViewModel
            {
                Id = id
            };
            return View(changePassword);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,NewPassword,ConfirmPassword")] ChangePasswordViewModel password)
        {
            var user = await db.Users.FindAsync(password.Id);
            if (ModelState.IsValid)
            {
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, password.NewPassword);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}