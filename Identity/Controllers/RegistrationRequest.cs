using System.ComponentModel.DataAnnotations;

namespace FoodDelivery.Identity.Controllers;
    public class RegistrationRequest
    {
        [Required]
        public string Email { get; set; } = null!;
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public int RegistrationType { get; set; }
    }