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
        public DbSet<LinkRepo> LinkRepo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
