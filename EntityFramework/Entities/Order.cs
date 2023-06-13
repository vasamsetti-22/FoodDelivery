using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.EntityFramework.Entities{
    [Table("order")]
    public class Order : DbContext
    {
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")] 
    public int Id { get; internal set; }

    [Column("price")] 
    public int Price { get; internal set; }
}
}
