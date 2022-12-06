using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
    public class Country
    {
        [Key]
        [MaxLength(3)]
        public string Code { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

    }
}
