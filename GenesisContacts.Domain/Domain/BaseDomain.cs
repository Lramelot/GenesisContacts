using System;

namespace GenesisContacts.Core.Domain
{
    public class BaseDomain
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}