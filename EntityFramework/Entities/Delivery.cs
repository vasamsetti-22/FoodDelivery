using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.EntityFramework.Entities{
    [Table("delivery")]
    public class Delivery : DbContext
    {
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")] 
    public string Id { get; internal set; }

    [Column("orderid")] 
    public string OrderId { get; internal set; }

    [Column("driverid")] 
    public string DriverId { get; internal set; }
}
}
