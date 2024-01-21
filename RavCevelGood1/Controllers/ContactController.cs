using DTO.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RavCevelGood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        //עדכון איש קשר
        [HttpPost("UpdateContact/{UserId}/{SchoolId}")]
        public IActionResult UpdateContact(int UserId, int SchoolId, [FromBody] AppContactDTO contact)
        {
            return Ok(_contactService.UpdateContact(contact, UserId, SchoolId));
        }

        //עדכון איש קשר והוספת קשר
        [HttpPost("UpdateContactAndAddContactPerStudent/{TypeContactId}/{UserId}/{SchoolId}")]
        public IActionResult UpdateContactAndAddContactPerStudent(int TypeContactId, int UserId, int SchoolId, [FromBody] AppContactDTO Contact) {

            return Ok();
        }


        //עדכון הקשר
        [HttpPost("UpdateContactPerStudent/{UserId}/{SchoolId}")]
        public IActionResult UpdateContactPerStudent(int UserId, int SchoolId, [FromBody] AppContactPerStudentDTO contactPerStudent)
        {
            return Ok(_contactService.UpdateContactPerStudent(contactPerStudent, UserId, SchoolId));
        }

        //שליפת איש קשר לפי תז- בודק אם קיים
        [HttpGet("GetContactByTz/{Tz}")]
        public IActionResult GetContactByTz(string Tz)
        {
            return Ok(_contactService.GetContactByTz(Tz));
        }

        //הוספת קשר-שיוך
        [HttpGet("AddContactPerPstudent/{ContactTz}/{StudentId}/{TypeContactId}")]
        public IActionResult AddContactPerPstudent(string ContactTz, int StudentId, int TypeContactId)
        {
            return Ok(_contactService.AddContactPerPstudent(ContactTz, StudentId, TypeContactId));
        }


        //הוספת איש קשר
        [HttpPost("AddContact/{UserId}/{SchoolId}/{StudentId}/{TypeContactId}")]
        public IActionResult AddContact(int UserId, int SchoolId, int StudentId, int TypeContactId, [FromBody] AppContactDTO Contact)
        {
            var c = _contactService.AddContact(Contact, UserId, SchoolId);
            if (c.ID == "4" || c.ID=="1")
            {

                _contactService.AddContactPerPstudent(Contact.Tz, StudentId, TypeContactId);
                return Ok(c);
            }

            return Ok(false);

        }

        //[HttpPost("AddContact/{UserId}/{SchoolId}/{StudentId}/{TypeContactId}")]
        //public IActionResult AddContact(int UserId, int SchoolId, int StudentId, int TypeContactId, [FromBody] AppContactDTO Contact)
        //{
        //    var c = _contactService.AddContact(Contact, UserId, SchoolId);
        //    if (c.ID == "4")
        //    {

        //        _contactService.AddContactPerPstudent(Contact.Tz, StudentId, TypeContactId);
        //        return Ok(c);
        //    }

        //    return Ok(false);
        //    return Ok();
        //}


    }
}
