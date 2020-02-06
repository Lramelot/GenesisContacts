using System.Collections.Generic;

namespace GenesisContacts.Core.Domain
{
    public class Company : BaseDomain
    {
        public string Name { get; set; }
        public string VATNumber { get; set; }

        public ICollection<CompanyAddresses> Addresses { get; set; }
        public ICollection<CompanyEmployees> CompanyEmployees { get; set; }
    }
}