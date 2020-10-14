using Microsoft.EntityFrameworkCore;
using Startup_models;
using System.Linq;

namespace Startup_API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Sources> Sources { get; set; }
        public DbSet<LinkType> LinkType { get; set; }
        public DbSet<linkRepository> LinkRepo { get; set; }
        public DbSet<LinkRepository> LinkRepository { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                  .SelectMany(t => t.GetForeignKeys())
                  .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            base.OnModelCreating(modelBuilder);

        }
    }
}
