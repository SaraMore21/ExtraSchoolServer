using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Classes;


namespace Services.Interfaces
{
    public interface IContactService
    {
        public AppContactDTO UpdateContact(AppContactDTO Contact, int UserId, int SchoolId);
        public AppContactPerStudentDTO UpdateContactPerStudent(AppContactPerStudentDTO c, int UserId, int SchoolId);
        public AppContactDTO GetContactByTz(string Tz,int SchoolId);
        public bool AddContactPerPstudent(int ContactId, int StudentId, int TypeContactId);
        public ReturnObjectOfAddContactDTO AddContact(AppContactDTO Contact, int UserId, int SchoolId);
        public bool DeleteContactPerStudent(int idcontactPerStudent);
        public List<string> UpdateContactAndAddContactPerStudent(int TypeContactId, int UserId, int SchoolId,int StudentId, AppContactDTO Contact);
    }
}