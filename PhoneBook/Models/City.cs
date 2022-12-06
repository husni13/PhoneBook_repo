using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Models
{
    public class City
    {
        [Key]
        [MaxLength(3)]
        public string Code { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(3)]
        [ForeignKey("Country")]
        public string CountryCode { get; set; }
        public virtual Country Country  { get; set; }
    }
}
