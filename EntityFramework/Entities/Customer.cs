using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Prathusha.EntityFramework.Entities{
    [Table("costomer")]
    public class Customer : DbContext
    {
    [System.ComponentModel.DataAnnotations.Key]
    [Column("id")] 
    public int Id { get; internal set; }

    [Column("name")] 
    public string Name { get; internal set; }

    [Column("postalcode")] 
    public int PostalCode { get; internal set; }
}
}
