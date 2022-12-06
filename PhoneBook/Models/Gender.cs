using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Models
{
    public class Gender
    {
        [Key]
        [MaxLength(3)]
        public string GenderCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string GenderName { get; set; }
        [Required]
        public bool GenderStatus { get; set; }
    }
}
