using System.ComponentModel.DataAnnotations;

namespace InformationDesk.Models
{
    public class Userinfo
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(50)] 
        public string OfiiceNumber { get; set; } = string.Empty;
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }= string.Empty;
        
        [Required]
        [StringLength(5)]
        public string FloorNumber { get; set; } = string.Empty;
    }
}
