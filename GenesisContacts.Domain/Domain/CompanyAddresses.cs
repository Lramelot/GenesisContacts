using GenesisContacts.Core.Enum;

namespace GenesisContacts.Core.Domain
{
    public class CompanyAddresses : BaseDomain
    {
        public Address Address { get; set; }
        public Company Company { get; set; }
        public CompanyAddressType CompanyAddressType { get; set; }
    }
}