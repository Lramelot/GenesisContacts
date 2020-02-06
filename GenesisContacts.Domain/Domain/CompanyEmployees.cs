namespace GenesisContacts.Core.Domain
{
    public class CompanyEmployees : BaseDomain
    {
        public Company Company { get; set; }
        public Contact Contact { get; set; }

        public int ContactId { get; set; }
    }
}