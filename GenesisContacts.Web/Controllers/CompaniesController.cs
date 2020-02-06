using System.Collections.Generic;
using GenesisContacts.Core.Domain;
using GenesisContacts.Service.Companies;
using GenesisContacts.Service.Companies.Commands;
using Microsoft.AspNetCore.Mvc;

namespace GenesisContacts.Web.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Company>> Get()
        {
            var contacts = _companyService.GetAll();
            return Ok(contacts);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Company> Create([FromBody] CreateCompanyCommand command)
        {
            var company = _companyService.Create(command);
            return Ok(company);
        }

        [HttpPost]
        [Route("{id}/addresses")]
        public ActionResult<Company> CreateAddress([FromRoute] int id, [FromBody] CreateAddressCommand command)
        {
            command.CompanyId = id;

            var company = _companyService.CreateAddress(command);
            return Ok(company);
        }

        [HttpPut]
        [Route("{companyId}/hire/{contactId}")]
        public ActionResult<Company> Hire([FromRoute] int companyId, [FromRoute] int contactId)
        {
            var command = new HireEmployeeCommand { CompanyId = companyId, ContactId = contactId };
            var company = _companyService.Hire(command);

            return Ok(company);
        }
    }
}