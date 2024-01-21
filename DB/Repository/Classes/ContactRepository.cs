using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    class ContactRepository : IContactRepository
    {
        private readonly ExtraSchoolContext _context;
        private readonly ICheckTZRepository _checkTZRepository;


        public ContactRepository(ExtraSchoolContext context, ICheckTZRepository checkTZRepository)
        {
            _context = context;
            _checkTZRepository = checkTZRepository;
        }

        public bool AddListContacts(List<AppContact> contacts)
        {
            try
            {
                _context.AppContacts.AddRange(contacts);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }
        //הוספת איש קשר
        public List<string> AddContact(AppContact Contact, int UserId, int SchoolId)
        {
            try
            {
                bool isValid = true;
                if (Contact.TypeIdentityId == 2)
                    isValid = _checkTZRepository.CheckTZ(Contact.Tz);
                if (isValid == false) return new List<string>() { "תז לא תקינה", "1" };

                Contact.UserCreatedId = UserId;
                Contact.DateCreated = DateTime.UtcNow.AddHours(2);
                Contact.ContactInformation.UserCreatedId = UserId;
                Contact.ContactInformation.DateCreated = DateTime.UtcNow.AddHours(2);
                _context.AppContacts.Add(Contact);
                _context.SaveChanges();
                return new List<string>() { "איש קשר נוסף בהצלחה", "4" };
            }
            catch (Exception e)
            {
                throw e;
                return new List<string>() { "הוספה נכשלה", "2" };
            }

        }

        //הוספת איש קשר לתלמיד-שיוך
        public bool AddContactPerPstudent(int ContactId, int StudentId, int TypeContactId)
        {
            try
            {
                var contactPerStudent = new AppContactPerStudent();
                contactPerStudent.StudentId = StudentId;
                contactPerStudent.ContactId = ContactId;
                contactPerStudent.TypeContactId = TypeContactId;
                _context.AppContactPerStudents.Add(contactPerStudent);
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

        //שליפת איש קשר לפי תז ומוסד- בודק האם כבר קיים איש קשר זה  
        public AppContact GetContactByTz(string Tz,int SchoolId)
        {
            try
            {
                var Contact = _context.AppContacts.Include(i => i.ContactInformation).FirstOrDefault(f =>f.SchoolId== SchoolId&& f.Tz == Tz);
                return Contact;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //עדכון איש קשר
        public AppContact UpdateContact(AppContact c, int UserId, int SchoolId)
        {

            var contact = _context.AppContacts.Include(i => i.ContactInformation).FirstOrDefault(f => f.Idcontact == c.Idcontact);
            if (contact != null)
            {
                contact.FirstName = c.FirstName;
                contact.LastName = c.LastName;

                contact.UserUpdatedId = UserId;
                contact.DateUpdated = DateTime.Today;

                if (c.ContactInformation != null)
                {
                    if (contact.ContactInformation==null)
                    {
                        contact.ContactInformation = new AppContactInformation();
                        _context.SaveChanges();
                    }
                    contact.ContactInformation.Email = c.ContactInformation.Email;
                    contact.ContactInformation.PhoneNumber1 = c.ContactInformation.PhoneNumber1;
                    contact.ContactInformation.PhoneNumber2 = c.ContactInformation.PhoneNumber2;
                    contact.ContactInformation.PhoneNumber3 = c.ContactInformation.PhoneNumber3;
                    contact.ContactInformation.TelephoneNumber1 = c.ContactInformation.TelephoneNumber1;
                    contact.ContactInformation.TelephoneNumber2 = c.ContactInformation.TelephoneNumber2;
                    contact.ContactInformation.FaxNumber = c.ContactInformation.FaxNumber;
                    contact.ContactInformation.Comment = c.ContactInformation.Comment;

                    contact.ContactInformation.UserUpdatedId = UserId;
                    contact.ContactInformation.DateUpdated = DateTime.Today;
                }

                _context.SaveChanges();

            }
            return contact;
        }

        //עדכון קשר
        public AppContactPerStudent UpdateContactPerStudent(AppContactPerStudent c, int UserId, int SchoolId)
        {
            try
            {
                //var contactPerStudent = _context.AppContactPerStudents.Include(i => i.TypeContact).FirstOrDefault(w => w.ContactId == c.ContactId);
                var contactPerStudent = _context.AppContactPerStudents.Include(i => i.TypeContact).FirstOrDefault(w => w.IdcontactPerStudent == c.IdcontactPerStudent);
                if (contactPerStudent != null)
                {
                    contactPerStudent.ContactId = c.ContactId;
                    contactPerStudent.StudentId = c.StudentId;
                    contactPerStudent.TypeContactId = c.TypeContact.IdtypeContact;
                    contactPerStudent.UserUpdatedId = UserId;
                    contactPerStudent.DateUpdated = DateTime.UtcNow.AddHours(2);
                }
                _context.SaveChanges();
                return contactPerStudent;
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        //מחיקת שיוך איש קשר לתלמיד
        public bool DeleteContactPerStudent(int idcontactPerStudent)
        {
            var ContactPerStudent = _context.AppContactPerStudents.FirstOrDefault(f => f.IdcontactPerStudent == idcontactPerStudent);
            if (ContactPerStudent == null) return false;
            _context.AppContactPerStudents.Remove(ContactPerStudent);
            if (_context.AppContactPerStudents.FirstOrDefault(f =>f.IdcontactPerStudent!=ContactPerStudent.IdcontactPerStudent&& f.ContactId == ContactPerStudent.ContactId) == null&&
                _context.AppSchools.FirstOrDefault(f=>f.UserContactId==ContactPerStudent.ContactId)==null)

            {
                var contact = _context.AppContacts.Include(c=>c.ContactInformation).FirstOrDefault(f => f.Idcontact == ContactPerStudent.ContactId);
                _context.AppContacts.Remove(contact);
                _context.AppContactInformations.Remove(contact?.ContactInformation);
            }
            _context.SaveChanges();
            return true;
        }
        //עדכון איש קשר והוספת קשר
        public List<string> UpdateContactAndAddContactPerStudent(int TypeContactId, int UserId, int SchoolId,int StudentId, AppContact Contact)
        {
            // שליחה לפונקציית עדכון פרטי קשר
            AppContact contact=UpdateContact(Contact, UserId, SchoolId);
            if(contact==null)
                return new List<string>() { "ההוספה נכשלה", "2" };

            if(_context.AppContactPerStudents.FirstOrDefault(f=>f.StudentId==StudentId&&f.ContactId==contact.Idcontact)!=null)
                return new List<string>() { "איש קשר זה כבר משוייך לתלמיד המבוקש", "3" };
            //להוסיף בדיקת תקינות שזה סוג קשר שניתן להוסיף מספר פעמים -ואם לא ניתן לבדוק אם כבר קיים שיוך כזה
            //הוספת שיוך איש קשר לתלמיד
            var ContactPerStudent = new AppContactPerStudent()
            {
                ContactId = contact.Idcontact,
                TypeContactId = TypeContactId,
                StudentId=StudentId,
                DateCreated=DateTime.Today,
                UserCreatedId=UserId
            };
            _context.AppContactPerStudents.Add(ContactPerStudent);
            _context.SaveChanges();
            return new List<string>() { "איש קשר נוסף בהצלחה", "1" };

        }

        //עדכון או הוספה של איש קשר מאקסל
        public void UpdateOrAddContactPerStudentFromXl(AppContactPerStudent contactPerStudent)
        {
            try
            {
                AppContact contact = UpdateContactByTz(contactPerStudent.Contact);
                if (contact != null)
                {
                    AppContactPerStudent perStudent = _context.AppContactPerStudents.FirstOrDefault(f => f.StudentId == contactPerStudent.StudentId && f.ContactId == contact.Idcontact && f.TypeContactId == contactPerStudent.TypeContactId);
                    if (perStudent == null)
                    {
                        var ContactPerStudent = new AppContactPerStudent()
                        {
                            ContactId = contact.Idcontact,
                            TypeContactId = contactPerStudent.TypeContactId,
                            StudentId = contactPerStudent.StudentId,
                            DateCreated = DateTime.Today,
                            UserCreatedId = contactPerStudent.UserCreatedId
                        };
                        _context.AppContactPerStudents.Add(ContactPerStudent);
                        _context.SaveChanges();
                    }

                }
            }
            catch (Exception)
            {
                _context.AppContactPerStudents.Local.Remove(contactPerStudent);

                throw;
            }
         

  
        }

        //עדכון איש קשר
        public AppContact UpdateContactByTz(AppContact c)
        {

            var contact = _context.AppContacts.Include(i => i.ContactInformation.Address).FirstOrDefault(f => f.Tz == c.Tz && f.SchoolId == c.SchoolId);
            if (contact != null)
            {
                contact.FirstName = c.FirstName!= null && c.FirstName!=""? c.FirstName: contact.FirstName;
                contact.LastName = c.LastName != null && c.LastName != "" ? c.LastName : contact.LastName;
                contact.TypeIdentityId = c.TypeIdentityId != null && c.TypeIdentityId != 0 ? c.TypeIdentityId : contact.TypeIdentityId;

                contact.UserUpdatedId = c.UserCreatedId;
                contact.DateUpdated = DateTime.Today;

                if (contact.ContactInformation != null)
                {
                    if (c.ContactInformation == null)
                    {
                        c.ContactInformation = contact.ContactInformation;
                    }
                    else
                    {
                        contact.ContactInformation.Email = c.ContactInformation.Email!= null && c.ContactInformation.Email!=""? c.ContactInformation.Email:contact.ContactInformation.Email;
                        contact.ContactInformation.PhoneNumber1 = c.ContactInformation.PhoneNumber1 != null && c.ContactInformation.PhoneNumber1 != "" ? c.ContactInformation.PhoneNumber1 : contact.ContactInformation.PhoneNumber1;
                        contact.ContactInformation.PhoneNumber2 = c.ContactInformation.PhoneNumber2 != null && c.ContactInformation.PhoneNumber2 != "" ? c.ContactInformation.PhoneNumber2 : contact.ContactInformation.PhoneNumber2;
                        contact.ContactInformation.PhoneNumber3 = c.ContactInformation.PhoneNumber3 != null && c.ContactInformation.PhoneNumber3 != "" ? c.ContactInformation.PhoneNumber3 : contact.ContactInformation.PhoneNumber3;
                        contact.ContactInformation.TelephoneNumber1 = c.ContactInformation.TelephoneNumber1 != null && c.ContactInformation.TelephoneNumber1 != "" ? c.ContactInformation.TelephoneNumber1 : contact.ContactInformation.TelephoneNumber1;
                        contact.ContactInformation.TelephoneNumber2 = c.ContactInformation.TelephoneNumber2 != null && c.ContactInformation.TelephoneNumber2 != "" ? c.ContactInformation.TelephoneNumber2 : contact.ContactInformation.TelephoneNumber2;
                        contact.ContactInformation.FaxNumber = c.ContactInformation.FaxNumber != null && c.ContactInformation.FaxNumber != "" ? c.ContactInformation.FaxNumber : contact.ContactInformation.FaxNumber;
                        contact.ContactInformation.Comment = c.ContactInformation.Comment != null && c.ContactInformation.Comment != "" ? c.ContactInformation.Comment : contact.ContactInformation.Comment;
                        contact.ContactInformation.Job = c.ContactInformation.Job != null && c.ContactInformation.Job != "" ? c.ContactInformation.Job : contact.ContactInformation.Job;
                        contact.ContactInformation.UserUpdatedId = c.UserCreatedId;
                        contact.ContactInformation.DateUpdated = DateTime.Today;

                        if (c.ContactInformation.Address != null)
                        {
                            contact.ContactInformation.Address.UserUpdatedId = c.UserUpdatedId;
                            contact.ContactInformation.Address.DateUpdated = DateTime.Today;
                            contact.ContactInformation.Address.CityId = c.ContactInformation.Address.CityId != null ? c.ContactInformation.Address.CityId : contact.ContactInformation.Address.CityId;
                            contact.ContactInformation.Address.HouseNumber = c.ContactInformation.Address.HouseNumber != null ? c.ContactInformation.Address.HouseNumber : contact.ContactInformation.Address.HouseNumber;
                            contact.ContactInformation.Address.ApartmentNumber = c.ContactInformation.Address.ApartmentNumber != null ? c.ContactInformation.Address.ApartmentNumber : contact.ContactInformation.Address.ApartmentNumber;
                            contact.ContactInformation.Address.NeighborhoodId = c.ContactInformation.Address.NeighborhoodId != null ? c.ContactInformation.Address.NeighborhoodId : contact.ContactInformation.Address.NeighborhoodId;
                            contact.ContactInformation.Address.PoBox = c.ContactInformation.Address.PoBox != null ? c.ContactInformation.Address.PoBox : contact.ContactInformation.Address.PoBox;
                            contact.ContactInformation.Address.StreetId = c.ContactInformation.Address.StreetId != null ? c.ContactInformation.Address.StreetId : contact.ContactInformation.Address.StreetId;
                            contact.ContactInformation.Address.ZipCode = c.ContactInformation.Address.ZipCode != null ? c.ContactInformation.Address.ZipCode : contact.ContactInformation.Address.ZipCode;
                        }

                    }
                   
                }

            }
            else
            {
                _context.AppContacts.Add(c);
                _context.SaveChanges();

                contact = c;
            }
            _context.SaveChanges();
            return contact;
        }

        //מחיקת איש קשר
        //public bool DeleteContact(int ContactId, int UserId)
        //{

        //}
    }


    //********פונקצית עדכון-גיבוי
    //    public AppContact UpdateContact(AppContact c, int UserId, int SchoolId)
    //    {
    //        try
    //        {
    //            var contact = _context.AppContacts.Include(i => i.ContactInformation).FirstOrDefault(f => f.Idcontact == c.Idcontact);
    //            if (contact != null)
    //            {
    //                contact.FirstName = c.FirstName;
    //                contact.LastName = c.LastName;
    //                contact.UserUpdatedId = UserId;
    //                contact.DateUpdated = DateTime.UtcNow.AddHours(2);

    //                if (c.ContactInformation != null)
    //                {
    //                    contact.ContactInformation.Email = c.ContactInformation.Email;
    //                    contact.ContactInformation.PhoneNumber1 = c.ContactInformation.PhoneNumber1;
    //                    contact.ContactInformation.PhoneNumber2 = c.ContactInformation.PhoneNumber2;
    //                    contact.ContactInformation.PhoneNumber3 = c.ContactInformation.PhoneNumber3;
    //                    contact.ContactInformation.TelephoneNumber1 = c.ContactInformation.TelephoneNumber1;
    //                    contact.ContactInformation.TelephoneNumber2 = c.ContactInformation.TelephoneNumber2;
    //                    contact.ContactInformation.FaxNumber = c.ContactInformation.FaxNumber;
    //                    contact.ContactInformation.UserUpdatedId = UserId;
    //                    contact.ContactInformation.DateUpdated = DateTime.Today;
    //                }
    //                _context.SaveChanges();
    //            }
    //            return contact;
    //        }
    //        catch (Exception e)
    //        {

    //            throw e;
    //        }
    //    }
    //}
}
