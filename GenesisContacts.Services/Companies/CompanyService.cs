using System.Collections.Generic;
using System.Linq;
using GenesisContacts.Core.Domain;
using GenesisContacts.Core.Enum;
using GenesisContacts.Data.Contexts;
using GenesisContacts.Service.Companies.Commands;
using Microsoft.EntityFrameworkCore;

namespace GenesisContacts.Service.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly ContactsContext _contactsContext;

        public CompanyService(ContactsContext contactsContext)
        {
            _contactsContext = contactsContext;
        }

        public Company Create(CreateCompanyCommand command)
        {
            var company = new Company
            {
                Name = command.Name,
                VATNumber = command.VATNumber,
                Addresses = new List<CompanyAddresses>
                {
                    new CompanyAddresses
                    {
                        CompanyAddressType = CompanyAddressType.Headquarter,
                        Address = new Address
                        {
                            Street = command.Street,
                            Number = command.Number,
                            Postcode = command.Postcode
                        }
                    }
                }
            };

            _contactsContext.Companies.Add(company);
            _contactsContext.SaveChanges();

            return company;
        }

        public Company CreateAddress(CreateAddressCommand command)
        {
            var company = GetCompany(command.CompanyId);

            company.Addresses.Add(new CompanyAddresses
            {
                CompanyAddressType = CompanyAddressType.Office,
                Address = new Address
                {
                    Street = command.Street,
                    Number = command.Number,
                    Postcode = command.Postcode
                }
            });

            _contactsContext.SaveChanges();
            return company;
        }

        public IEnumerable<Company> GetAll()
        {
            var companies = _contactsContext
                .Companies
                .Include(c => c.Addresses)
                .ThenInclude(a => a.Address)
                .Include(c => c.CompanyEmployees)
                .ThenInclude(e => e.Contact)
                .ToList();

            return companies;
        }

        public Company Hire(HireEmployeeCommand command)
        {
            var company = GetCompany(command.CompanyId);

            company.CompanyEmployees.Add(new CompanyEmployees
            {
                ContactId = command.ContactId
            });

            _contactsContext.SaveChanges();

            return company;
        }

        private Company GetCompany(int companyId)
        {
            var company = _contactsContext
                .Companies
                .Include(c => c.Addresses)
                .ThenInclude(a => a.Address)
                .Include(c => c.CompanyEmployees)
                .ThenInclude(e => e.Contact)
                .First(c => c.Id == companyId);

            return company;
        }
    }
}