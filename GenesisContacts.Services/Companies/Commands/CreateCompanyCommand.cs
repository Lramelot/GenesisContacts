namespace GenesisContacts.Service.Companies.Commands
{
    public class CreateCompanyCommand
    {
        public string Name { get; set; }
        public string VATNumber { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Postcode { get; set; }
    }
}