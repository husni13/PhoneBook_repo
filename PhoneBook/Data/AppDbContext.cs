using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PhoneBook.Models;

namespace PhoneBook.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
       // public DbSet<Gender> Genders { get; set; }

    }
}
