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
                var material = new Material_message { MaterialName = "测试物资" };
                await db.Material_message.AddAsync(material);
                var warehouse = new Warehouse_material { MID = material, NowNumber = 10 };
                await db.Warehouse_material.AddAsync(warehouse);
                var user = new IdentityUser { Email = "djhuang_1@qq.com", UserName = "Administrator1987" };
                var supplier1 = new Supplier_message { FactoryName = "供方1", Director = "余则成" };

                await db.Supplier_message.AddAsync(supplier1);
                var result = await _userManager.CreateAsync(user, "Administrator1987");
                await db.SaveChangesAsync();

                if (!await db.Games.AnyAsync())
                {
                    var gameList = new List<Game>();
                    for (int i = 0; i < 20; i++)
                    {
                        Game game = new Game
                        {
                            Name = "RPG GAME" + (i + 1).ToString(),
                            Price = _random.Next(5, 100)
                        };
                        gameList.Add(game);
                    }
                    await db.Games.AddRangeAsync(gameList);
                    await db.SaveChangesAsync();
                }
                transaction.Commit();
            }
        }
    }
}
