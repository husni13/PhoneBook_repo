using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhoneBook.Data;
using PhoneBook.Models.HelperModel;
using PhoneBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Forms;

namespace PhoneBook.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _db;

        public ContactController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Contact> contacts = _db.Contacts.Include(c => c.Country).Include(c => c.City).ToList();
            return View(contacts);
        }
        public IActionResult Create()
        {
            ContactCreateModel newContactCreateModel = new ContactCreateModel();
            newContactCreateModel.Contact = new Contact();

            List<SelectListItem> countries = _db.Countries.OrderBy(n => n.Name)
                .Select(n => new SelectListItem { Value = n.Code, Text = n.Name }).ToList();
            newContactCreateModel.Countries = countries;
         
            newContactCreateModel.Cities = new List<SelectListItem>();


            return View(newContactCreateModel);
        }

        [HttpPost]
        public IActionResult Create(ContactCreateModel element)
        {
            _db.Add(element.Contact);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            
            ContactCreateModel editContact = new ContactCreateModel();
            List<SelectListItem> countries = _db.Countries.OrderBy(n => n.Name)
                .Select(n => new SelectListItem { Value = n.Code, Text = n.Name }).ToList();
            editContact.Countries = countries;

            editContact.Cities = new List<SelectListItem>();
            editContact.Contact = _db.Contacts.Find(id);
            if(id == null || id == 0)
            {
                return NotFound();
            }
            if(editContact.Contact == null)
            {
                return NotFound();
            }

            return View(editContact);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ContactCreateModel editedElement)
        {
            _db.Contacts.Update(editedElement.Contact);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {


            ContactCreateModel theContact = new ContactCreateModel();
            List<SelectListItem> countries = _db.Countries.OrderBy(n => n.Name)
                .Select(n => new SelectListItem { Value = n.Code, Text = n.Name }).ToList();
            theContact.Countries = countries;

            List<SelectListItem> cities = _db.Cities.OrderBy(n => n.Name)
                .Select(n => new SelectListItem { Value = n.Code, Text = n.Name }).ToList();
            theContact.Cities = cities;

            theContact.Contact = _db.Contacts.Find(id);
            if (id == null || id == 0)
            {
                return NotFound();
            }
            if (theContact == null)
            {
                return NotFound();
            }

            return View(theContact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(ContactCreateModel theDel)
        {
            var obj = _db.Contacts.Find(theDel.Contact.Id);
            _db.Contacts.Remove(obj);   
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetCities(string CountryCode)
        {
            if(!string.IsNullOrWhiteSpace(CountryCode) && CountryCode.Length ==3)
            {
                List<SelectListItem> citiesSel = _db.Cities.Where(c => c.CountryCode == CountryCode)
                    .OrderBy(n => n.Name)
                    .Select(n => new SelectListItem
                    {
                        Value = n.Code,
                        Text = n.Name
                    }).ToList();
                return Json(citiesSel);
            }
            return null;
        }


    }
}

