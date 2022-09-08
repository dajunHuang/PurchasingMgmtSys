using MVC.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;  
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC.Models.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        //public DbSet<IdentityUser> Users { get; set; } //自带的表，可代替User和Buyer_message表用
        
        //下面是在数据库中创建的表
        public DbSet<Supplier_message> Supplier_message { get; set; }
        public DbSet<Supplier_material> Supplier_material { get; set; }
        public DbSet<Material_message> Material_message { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<Warehouse_material> Warehouse_material { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Player>()
            //    .HasOne(p => p.User)
            //    .WithOne(u => u.Player)
            //    .HasForeignKey<Player>(p => p.UserId);

            //modelBuilder.Entity<PlayerGame>()
            //    .HasKey(pg => new { pg.PlayerId, pg.GameId });
        }
    }
}
