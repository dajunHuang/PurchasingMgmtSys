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

        public async Task Seed()
        {
            //await db.Database.MigrateAsync();

            using (var transaction = await db.Database.BeginTransactionAsync())
            {
                var user = new IdentityUser {Email = "djhuang_1@qq.com", UserName = "Administrator1987" };
                var result = await _userManager.CreateAsync(user, "Administrator1987");
                if (result.Succeeded)
                {
                    await db.SaveChangesAsync();
                }

                if (!await db.Genres.AnyAsync())
                {
                    var genreList = new List<Genre>
                    {
                        new Genre
                        {
                            CreatedAt = _createdAt,
                            Name = "RPG"
                        },
                        new Genre
                        {
                            CreatedAt = _createdAt,
                            Name = "FPS"
                        },
                        new Genre
                        {
                            CreatedAt = _createdAt,
                            Name = "RTS"
                        }
                    };

                    await db.Genres.AddRangeAsync(genreList);
                    await db.SaveChangesAsync();
                }


                if (!await db.Games.AnyAsync())
                {
                    var rpg = await db.Genres.SingleOrDefaultAsync(g => g.Name == "RPG");

                    var gameList = new List<Game>();
                    for (int i = 0; i < 1000; i++)
                    {
                        Game game = new Game
                        {
                            GenreId = rpg.GenreId,
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
