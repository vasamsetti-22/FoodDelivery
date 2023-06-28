using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.EntityFramework.Entities{
    [Table("item")]
    public class Item : DbContext
    {
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")] 
    public string Id { get; internal set; }

    [Column("name")] 
    public string Name { get; internal set; }

    [Column("price")] 
    public double Price { get; internal set; }
    
    [Column("restaurantid")] 
    public string RestaurantId { get; internal set; }
}
}
