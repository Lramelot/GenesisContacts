namespace GenesisContacts.Core.Domain
{
    public class Address : BaseDomain
    {
        public string Street { get; set; }
        public string Number { get; set; }
        public string Postcode { get; set; }
    }
}