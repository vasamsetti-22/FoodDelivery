using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.EntityFramework.Entities{
    [Table("order")]
    public class Order : DbContext
    {
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")] 
    public string Id { get; internal set; }

    [Column("price")] 
    public double Price { get; internal set; }
    [Column("customerid")] 
    public double CustomerId { get; internal set; }
}
}
