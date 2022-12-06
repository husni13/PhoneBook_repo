using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength (50)]
        public string Surname { get; set; }
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(3)]
        [ForeignKey("Country")]
        [DisplayName("Country")]
        public string? CountryCode { get; set; }
        public virtual Country Country { get; set; }
        [Required]
        [MaxLength(3)]
        [ForeignKey("City")]
        [DisplayName("City")]
        public string? CityCode { get; set; }
        public virtual City City { get; set; }

    }
}
