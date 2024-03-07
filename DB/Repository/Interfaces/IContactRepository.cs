using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IContactRepository
    {
        bool AddListContacts(List<AppContact> contacts);
        AppContact UpdateContact(AppContact Contact, int UserId, int SchoolId);
        AppContactPerStudent UpdateContactPerStudent(AppContactPerStudent ContactPerStudent, int UserId, int SchoolId);
        AppContact GetContactByTz(string Tz,int SchoolId);
        bool AddContactPerPstudent(int ContactId, int StudentId, int TypeContactId);
        List<string> AddContact(AppContact Contact, int UserId, int SchoolId);
        bool DeleteContactPerStudent(int idcontactPerStudent);
        List<string> UpdateContactAndAddContactPerStudent(int TypeContactId, int UserId, int SchoolId,int StudentId, AppContact Contact);
        public void UpdateOrAddContactPerStudentFromXl(AppContactPerStudent contactPerStudent);

        //bool DeleteContactPerStudent(int ContactId, int UserId);
    }
}
