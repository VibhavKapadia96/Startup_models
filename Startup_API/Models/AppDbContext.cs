using Microsoft.EntityFrameworkCore;
using Startup_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup_API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Sources> Sources { get; set; }
        public DbSet<LinkType> LinkType { get; set; }
        public DbSet<linkRepo> LinkRepo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed Categories Table
            modelBuilder.Entity<Categories>().HasData(
                new Categories { Id = 1, Category_Parent = null, Category_Name="GRE" , Parent_Id=0}); 
            
            modelBuilder.Entity<Categories>().HasData(
                new Categories { Id = 2, Category_Parent = null, Category_Name="GMATE", Parent_Id = 0 });


            modelBuilder.Entity<Categories>().HasData(
                new Categories { Id = 3, Category_Parent = "GRE", Category_Name = "Quant", Parent_Id = 1 });

        }
    }
}
