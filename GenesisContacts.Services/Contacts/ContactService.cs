using System.Collections.Generic;
using System.Linq;
using GenesisContacts.Core.Domain;
using GenesisContacts.Data.Contexts;
using GenesisContacts.Service.Contacts.Commands;
using Microsoft.EntityFrameworkCore;

namespace GenesisContacts.Service.Contacts
{
    public class ContactService : IContactService
    {
        private readonly ContactsContext _contactsContext;

        public ContactService(ContactsContext contactsContext)
        {
            _contactsContext = contactsContext;
        }

        public Contact Create(CreateContactCommand command)
        {
            var contact = new Contact
            {
                Name = command.Name,
                Surname = command.Surname,
                SocialReason = command.SocialReason,
                VATNumber = command.VATNumber,
                Address = new Address
                {
                    Number = command.Number,
                    Street = command.Street,
                    Postcode = command.Postcode
                }
            };

            _contactsContext.Contacts.Add(contact);
            _contactsContext.SaveChanges();

            return contact;
        }

        public Contact Update(UpdateContactCommand command)
        {
            var contact = _contactsContext
                .Contacts
                .Include(c => c.Address)
                .First(c => c.Id == command.ContactId);

            if (!string.IsNullOrWhiteSpace(command.Surname))
            {
                contact.Surname = command.Surname;
            }

            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                contact.Name = command.Name;
            }

            _contactsContext.SaveChanges();
            return contact;
        }

        public void Delete(int id)
        {
            var contact = _contactsContext
                .Contacts
                .First(c => c.Id == id);

            _contactsContext.Remove(contact);
            _contactsContext.SaveChanges();
        }

        public IEnumerable<Contact> GetAll()
        {
            var contacts = _contactsContext
                .Contacts
                .Include(c => c.Address)
                .ToList();

            return contacts;
        }
    }
}