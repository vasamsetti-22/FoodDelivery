using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prathusha.EntityFramework.Entities{
    [Table("delivery")]
    public class Delivery : DbContext
    {
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")] 
    public int Id { get; internal set; }

    [Column("orderid")] 
    public string OrderId { get; internal set; }

    [Column("driverid")] 
    public int DriverId { get; internal set; }
}
}
