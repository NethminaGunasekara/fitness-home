using System.ComponentModel.DataAnnotations;

namespace FitnessHome.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public UserRole Role { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(128)]
        public string Password { get; set; }
    }
    
    public enum UserRole
    {
        Admin,
        Trainer,
        Member
    }
}
