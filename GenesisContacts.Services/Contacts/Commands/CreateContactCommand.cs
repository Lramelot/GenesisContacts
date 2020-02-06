using GenesisContacts.Core.Enum;

namespace GenesisContacts.Service.Contacts.Commands
{
    public class CreateContactCommand
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public SocialReason SocialReason { get; set; }
        public string VATNumber { get; set; }

        public string Street { get; set; }
        public string Number { get; set; }
        public string Postcode { get; set; }
    }
}