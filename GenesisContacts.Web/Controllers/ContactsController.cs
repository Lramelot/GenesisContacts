using System.Collections.Generic;
using GenesisContacts.Core.Domain;
using GenesisContacts.Service.Contacts;
using GenesisContacts.Service.Contacts.Commands;
using Microsoft.AspNetCore.Mvc;

namespace GenesisContacts.Web.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Contact>> Get()
        {
            var contacts = _contactService.GetAll();
            return Ok(contacts);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Contact> Create([FromBody] CreateContactCommand command)
        {
            var contact = _contactService.Create(command);
            return Ok(contact);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<Contact> Update([FromRoute] int id, [FromBody] UpdateContactCommand command)
        {
            command.ContactId = id;

            var contact = _contactService.Update(command);
            return Ok(contact);
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _contactService.Delete(id);
            return Ok();
        }
    }
}