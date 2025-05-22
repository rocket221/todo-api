using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Sheet> Sheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .ToTable("Items")
                .HasOne(item => item.Sheet)
                .WithMany(sheet => sheet.Items);

            modelBuilder.Entity<Sheet>()
                .ToTable("Sheets")
                .HasMany(sheet => sheet.Items)
                .WithOne(item => item.Sheet)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
