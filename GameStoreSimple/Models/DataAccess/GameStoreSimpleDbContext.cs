using MVC.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.DataAccess
{
    public class GameStoreSimpleDbContext : IdentityDbContext<ApplicationUser>
    {
        public GameStoreSimpleDbContext()
        {
        }

        public GameStoreSimpleDbContext(DbContextOptions<GameStoreSimpleDbContext> options)
            : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
        //public DbSet<PlayerGame> PlayerLibraries { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.User)
                .WithOne(u => u.Player)
                .HasForeignKey<Player>(p => p.UserId);

            //modelBuilder.Entity<PlayerGame>()
            //    .HasKey(pg => new { pg.PlayerId, pg.GameId });
        }
    }
}
