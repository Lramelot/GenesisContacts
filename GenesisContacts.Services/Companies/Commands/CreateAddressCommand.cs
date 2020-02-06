namespace GenesisContacts.Service.Companies.Commands
{
    public class CreateAddressCommand
    {
        public int CompanyId { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Postcode { get; set; }
    }
}