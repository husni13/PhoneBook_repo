using Microsoft.AspNetCore.Mvc.Rendering;

namespace PhoneBook.Models.HelperModel
{
    public class ContactCreateModel
    {
        public Contact Contact { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
