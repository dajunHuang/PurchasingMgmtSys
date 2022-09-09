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


        //public DbSet<IdentityUser> Users { get; set; }
        public DbSet<Supplier_message> Supplier_message { get; set; }
        public DbSet<Supplier_material> Supplier_material { get; set; }
        public DbSet<Material_message> Material_message { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<Warehouse_material> Warehouse_material { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
