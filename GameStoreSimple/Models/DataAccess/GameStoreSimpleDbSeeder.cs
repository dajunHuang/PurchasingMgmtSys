using MVC.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC.Models.DataAccess
{
    public class GameStoreSimpleDbSeeder
    {
        private readonly GameStoreSimpleDbContext db;
        private readonly DateTime _createdAt = DateTime.UtcNow;

        private readonly Random _random = new Random();

        public GameStoreSimpleDbSeeder(GameStoreSimpleDbContext db)
        {
            this.db = db;
        }

        public async Task Seed()
        {
            //await db.Database.MigrateAsync();

            using (var transaction = await db.Database.BeginTransactionAsync())
            {
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
                    var fps = await db.Genres.SingleOrDefaultAsync(g => g.Name == "FPS");
                    var rts = await db.Genres.SingleOrDefaultAsync(g => g.Name == "RTS");

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
                    for (int i = 0; i < 1000; i++)
                    {
                        Game game = new Game
                        {
                            GenreId = fps.GenreId,
                            Name = "FPS GAME" + (i + 1).ToString(),
                            Price = _random.Next(10, 120)
                        };
                        gameList.Add(game);
                    }
                    for (int i = 0; i < 1000; i++)
                    {
                        Game game = new Game
                        {
                            GenreId = rts.GenreId,
                            Name = "RTS GAME" + (i + 1).ToString(),
                            Price = _random.Next(20, 150)
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
