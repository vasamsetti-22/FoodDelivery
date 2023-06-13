using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prathusha.EntityFramework.Entities{
    [Table("item")]
    public class Item : DbContext
    {
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")] 
    public int Id { get; internal set; }

    [Column("name")] 
    public string Name { get; internal set; }

    [Column("price")] 
    public int Price { get; internal set; }
    
    [Column("restaurantid")] 
    public int RestaurantId { get; internal set; }
}
}
