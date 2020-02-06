namespace GenesisContacts.Service.Contacts.Commands
{
    public class UpdateContactCommand
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}