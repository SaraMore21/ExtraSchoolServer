using AutoMapper;
using DB.Model;
using DB.Repository.Interfaces;
using DTO.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    class ContactService : IContactService
    {

        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public ContactService(IMapper mapper, IContactRepository contactRepository)
        {
            _mapper = mapper;
            _contactRepository = contactRepository;
        }


        //הוספת איש קשר
        public ReturnObjectOfAddContactDTO AddContact(AppContactDTO Contact, int UserId, int SchoolId)
        {
            var c = _mapper.Map<AppContact>(Contact);
            var String = _contactRepository.AddContact(c, UserId, SchoolId);
            return new ReturnObjectOfAddContactDTO() { Contact = _mapper.Map<AppContactDTO>(c), ID = String != null ? String[1] : null, Name = String != null ? String[0] : null };
        }

        //הוספת קשר
        public bool AddContactPerPstudent(int ContactId, int StudentId, int TypeContactId)
        {
            return _contactRepository.AddContactPerPstudent(ContactId, StudentId, TypeContactId);
        }
        //מחיקת שיוך איש קשר לתלמיד
        public bool DeleteContactPerStudent(int idcontactPerStudent)
        {
            return _contactRepository.DeleteContactPerStudent(idcontactPerStudent);
        }

        //שליפת איש קשר לפי תז
        public AppContactDTO GetContactByTz(string Tz,int SchoolId)
        {
            var contact = _mapper.Map<AppContactDTO>(_contactRepository.GetContactByTz(Tz,SchoolId));

            return contact;
        }

        //עדכון איש קשר
        public AppContactDTO UpdateContact(AppContactDTO Contact, int UserId, int SchoolId)
        {
            var contact = _mapper.Map<AppContact>(Contact);
            return _mapper.Map<AppContactDTO>(_contactRepository.UpdateContact(contact, UserId, SchoolId));
        }

        public List<string> UpdateContactAndAddContactPerStudent(int TypeContactId, int UserId, int SchoolId,int StudentId, AppContactDTO Contact)
        {
            return _contactRepository.UpdateContactAndAddContactPerStudent(TypeContactId, UserId, SchoolId,StudentId,_mapper.Map<AppContact>(Contact));

        }

        //עדכון קשר
        public AppContactPerStudentDTO UpdateContactPerStudent(AppContactPerStudentDTO c, int UserId, int SchoolId)
        {
            var contactPerStudent = _mapper.Map<AppContactPerStudent>(c);
            return _mapper.Map<AppContactPerStudentDTO>(_contactRepository.UpdateContactPerStudent(contactPerStudent, UserId, SchoolId));
        }
    }
}
