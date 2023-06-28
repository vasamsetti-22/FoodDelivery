using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.EntityFramework.Entities{
    [Table("restaurant")]
    public class Restaurant : DbContext
    {
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")] 
    public string Id { get; internal set; }

    [Column("name")] 
    public string Name { get; internal set; }
    
    [Column("postcode")] 
    public string PostCode { get; internal set; }

}
}