using GenesisContacts.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace GenesisContacts.Data.Contexts
{
    public class ContactsContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GenesisContacts;Trusted_Connection=True;");
        }
    }
}