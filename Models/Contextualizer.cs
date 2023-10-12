using Microsoft.EntityFrameworkCore;

namespace Verzamelwoede_NonBroken.Models
{
    public class Contextualizer : DbContext
    {
        public DbSet<Item> Item { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Filter> Filter { get; set; }

        public Contextualizer(DbContextOptions<Contextualizer> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
                .Property(i => i.Name)
                .HasMaxLength(20);
            modelBuilder.Entity<Category>()
                .Property(i => i.Name)
                .HasMaxLength(20);
            modelBuilder.Entity<Filter>()
                .Property(i => i.Name)
                .HasMaxLength(20);

            // Voor de 1:n Item:Category Relatie
            modelBuilder.Entity<Item>()
                .HasOne(o => o.Category)
                .WithMany(v => v.Items)
                .HasForeignKey(o => o.CategoryId);

            // Voor de n:n Item:Filter Relatie.
            modelBuilder.Entity<Item>()
                .HasMany(f => f.Filters)
                .WithMany(i => i.Items);
            modelBuilder.Entity<Filter>()
                .HasMany(f => f.Items)
                .WithMany(i => i.Filters);
        }
    }
}
