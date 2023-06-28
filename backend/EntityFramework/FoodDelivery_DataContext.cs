using Microsoft.EntityFrameworkCore;
using FoodDelivery.EntityFramework.Entities;
namespace FoodDelivery.EntityFramework{
    public class FoodDelivery_DataContext : DbContext {
        public FoodDelivery_DataContext(DbContextOptions<FoodDelivery_DataContext> options): base(options) { }
       
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}