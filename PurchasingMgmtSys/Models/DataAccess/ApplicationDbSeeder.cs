using MVC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC.Models.DataAccess
{
    public class ApplicationDbSeeder
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly DateTime _createdAt = DateTime.UtcNow;

        private readonly Random _random = new Random();

        public ApplicationDbSeeder(ApplicationDbContext db,
            UserManager<IdentityUser> userManager)
        {
            this.db = db;
            this._userManager = userManager;
        }

        public async Task Seed() //数据库添加初始数据
        {
            using (var transaction = await db.Database.BeginTransactionAsync())
            {
                //var material = new Material_message { MaterialName = "测试物资" };
                //await db.Material_message.AddAsync(material);
                //var warehouse = new Warehouse_material { MID = material, NowNumber = 10 };
                //await db.Warehouse_material.AddAsync(warehouse);
                //var supplier1 = new Supplier_message { FactoryName = "供方1", Director = "余则成" };
                //await db.Supplier_message.AddAsync(supplier1);

                var user1 = new IdentityUser { Email = "djhuang_1@163.com", UserName = "djhuang_1@163.com" };
                await _userManager.CreateAsync(user1, "djhuang_1@163.com");
                var user = new IdentityUser { Email = "djhuang_1@qq.com", UserName = "Administrator1987" };
                await _userManager.CreateAsync(user, "Administrator1987");
                await db.SaveChangesAsync();
                transaction.Commit();
            }
        }
    }
}
