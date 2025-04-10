using System.ComponentModel.DataAnnotations;

namespace CropWise.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; } // Farmer or Admin
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  // Auto-set timestamp

        public bool IsActive { get; set; } = true; // Default to true
        
        // Navigation property linking to the Farmer
        public virtual Farmer Farmer { get; set; }  // The farmer who owns the farm

    }
}