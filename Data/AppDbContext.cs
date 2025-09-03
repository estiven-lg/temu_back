using Microsoft.EntityFrameworkCore;
using temu_back.Models;

namespace temu_back.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Item> Items => Set<Item>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Order>()
        .HasMany(t => t.OrderDetails)
        .WithOne(t => t.Order)
        .HasForeignKey(t => t.OrderId);

        modelBuilder.Entity<Item>()
        .HasMany(t => t.OrderDetails)
        .WithOne(t => t.Item)
        .HasForeignKey(t => t.ItemId);

        modelBuilder.Entity<Person>()
        .HasMany(t => t.Orders)
        .WithOne(t => t.Person)
        .HasForeignKey(t => t.PersonId);

    }
    
}
