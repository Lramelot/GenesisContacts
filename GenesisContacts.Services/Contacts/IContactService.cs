using System.Collections.Generic;
using GenesisContacts.Core.Domain;
using GenesisContacts.Service.Contacts.Commands;

namespace GenesisContacts.Service.Contacts
{
    public interface IContactService
    {
        Contact Create(CreateContactCommand command);
        Contact Update(UpdateContactCommand command);
        void Delete(int id);
        IEnumerable<Contact> GetAll();
    }
}