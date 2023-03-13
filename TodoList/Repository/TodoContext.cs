using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TodoList.Models;

namespace TodoList.Repository
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemsList> ItemsLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .ToTable("Item")
                .HasOne(item => item.ItemsList)
                .WithMany(list => list.Items);

            modelBuilder.Entity<ItemsList>()
                .ToTable("ItemsList")
                .HasMany(list => list.Items)
                .WithOne(item => item.ItemsList)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
