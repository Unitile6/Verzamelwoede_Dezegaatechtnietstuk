using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Verzamelwoede_NonBroken.Models;
using Verzamelwoede_Dezegaatechtnietstuk.Models;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Verzamelwoede_Dezegaatechtnietstuk.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Item> Item { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Filter> Filter { get; set; }
        public DbSet<ItemFilterViewModel> ItemFilter { get; set; } //Ontbrak voor n:n gedrag.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(Console.WriteLine) // Console zonder logfiltering.
                .EnableSensitiveDataLogging();
            //           optionsBuilder.LogTo(WriteLine, // Console met log-filtering
            //new[] { RelationalEventId.CommandExecuting })
            //.EnableSensitiveDataLogging();

            //optionsBuilder.UseLazyLoadingProxies(); // p. 471, mist de package. using werkt niet.
        }

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
            //modelBuilder.Entity<Item>()
            //    .Property(i => i.Favourite)
            //    .HasDefaultValue(false); // Bereikt niet het gewenste resultaat.

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


        public DbSet<Verzamelwoede_Dezegaatechtnietstuk.Models.ItemFilterViewModel> ItemFilterViewModel { get; set; } = default!;
    }
}