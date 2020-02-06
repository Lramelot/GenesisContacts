using GenesisContacts.Core.Enum;

namespace GenesisContacts.Core.Domain
{
    public class Contact : BaseDomain
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public SocialReason SocialReason { get; set; }
        public string VATNumber { get; set; }

        public Address Address { get; set; }
    }
}