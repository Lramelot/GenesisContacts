using System.Collections.Generic;
using GenesisContacts.Core.Domain;
using GenesisContacts.Service.Companies.Commands;

namespace GenesisContacts.Service.Companies
{
    public interface ICompanyService
    {
        Company Create(CreateCompanyCommand command);
        Company CreateAddress(CreateAddressCommand command);
        IEnumerable<Company> GetAll();
        Company Hire(HireEmployeeCommand command);
    }
}