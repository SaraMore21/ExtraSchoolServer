using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using DB.Repository.Classes;
using Microsoft.Data.SqlClient;

namespace DB.Repository.Classes
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ExtraSchoolContext _context;
        private readonly ICheckTZRepository _checkTZRepository;
        private readonly IGroupRepository _GroupRepository;

        public StudentRepository(ExtraSchoolContext context, ICheckTZRepository checkTZRepository, IGroupRepository GroupRepository)
        {
            _context = context;
            _checkTZRepository = checkTZRepository;
            _GroupRepository = GroupRepository;
        }


        public bool AddListStudents(List<AppStudent> students, int SchoolId)
        {
            try
            {
                _context.AppStudents.AddRange(students);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }

        //IDשליפת תלמידים במוסד עפ"י מוסד
        public List<AppStudent> GetListStudentsBySchoolId(int SchoolId)
        {
            try
            {
                var a = _context.AppStudents.Where(w => w.IsActive == true && w.SchoolId == SchoolId).ToList();
                //var a = _context.AppStudentPerSchools.Where(w => w.SchoolId == SchoolId).Select(s => s.Student).Where(w => w.IsActive == true).ToList();
                return a;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //ושנתוןID IDשליפת תלמידים במוסד עפ"י מוסד
        public List<AppStudent> GetListStudentsBySchoolIdAndYearbookId(string SchoolsId, int YearbookId)
        {
            try
            {










                //using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                //{

                //    cmd.CommandText = "select * from App_StudentPerYearbook as spy  join[dbo].[APP_Student] as s on s.[IDStudent] = spy.[StudentID] join App_DocumentPerStudent as dps on dps.studentid = s.idstudentjoin app_school as sc on sc.idschool = s.schoolidjoin Tab_RequiredDocumentPerStudent as trdpson trdps.schoolid = sc.idschool join[APP_YearbookPerSchool] as yps on yps.idYearbookPerSchool = spy.yearbookid where" + SchoolsId + " like '%' + cast(s.schoolid AS varchar) + '%' and spy.yearbookid = " + YearbookId;
                //    cmd.CommandType = System.Data.CommandType.Text;
                //    if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();



                //    SqlDataReader rdr = (SqlDataReader)cmd.ExecuteReader();


                //    if (rdr.HasRows)
                //    {
                //        List<AppStudent> ls = new List<AppStudent>();
                //        while (rdr.Read())
                //        {
                //            AppStudent std = new AppStudent();
                //            if (rdr["StudentId"] != DBNull.Value) std.Idstudent = int.Parse(rdr["StudentId"].ToString());
                //            if (rdr["StudentId"] != DBNull.Value) std.Idstudent = int.Parse(rdr["StudentId"].ToString());
                //            if (rdr["StudentId"] != DBNull.Value) std.Idstudent = int.Parse(rdr["StudentId"].ToString());
                //        }
                //    }

                //    gvGrid.DataSource = lessons;
                //    gvGrid.DataBind();
                //    cmd.Connection.Close();
                //}














                SchoolsId = SchoolsId.Remove(SchoolsId.Length - 1);

                var Array = SchoolsId.Split(",").ToList();
                var a = _context.AppStudentPerYearbooks.Include(s => s.Student.AppDocumentPerStudents).Include(i => i.Student.School.TabRequiredDocumentPerStudents).Include(y => y.Yearbook).Where(w => Array.Contains(w.Student.SchoolId.ToString()) == true && w.Yearbook != null && w.Yearbook.YearbookId == YearbookId).Select(s => s.Student).ToList();
                return a;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public List<AppStudent> SearchInStudentList(string str, int YearbookId, string SchoolsId)
        {
            try
            {
                SchoolsId = SchoolsId.Remove(SchoolsId.Length - 1);
                var Array = SchoolsId.Split(",").ToList();
                return _context.AppStudentPerYearbooks.Include(s=>s.Student).ThenInclude(sc=>sc.School).Include(y=>y.Yearbook).Where(w => Array.Contains(w.Student.SchoolId.ToString()) == true && w.Yearbook != null && w.Yearbook.YearbookId == YearbookId
                && (w.Student.Tz.Contains(str)|| w.Student.FirstName.Contains(str)|| w.Student.LastName.Contains(str)|| w.Student.School.Name.Contains(str))
                ).Select(s => s.Student).ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }



        public List<AppStudent> GetPartlyListStudent(int page, int pageSize,int YearbookId, string SchoolsId)
        {
            try
            {
                SchoolsId = SchoolsId.Remove(SchoolsId.Length - 1);
                var Array = SchoolsId.Split(",").ToList();
                int skipCount = (page - 1) * pageSize;
                return _context.AppStudentPerYearbooks.Include(s => s.Student.AppDocumentPerStudents).Include(i => i.Student.School.TabRequiredDocumentPerStudents).Include(y => y.Yearbook).Include(s=>s.Student.Address).ThenInclude(s=>s.City).Include(s=>s.Student.Address.Neighborhood).Include(s=>s.Student.Birth).ThenInclude(s=>s.BirthCountry).Include(s=>s.Student.ContactInformation).Include(s=>s.Student.Status).Include(s=>s.Student.StatusStudent).Include(s=>s.Student.MotherTypeIdentity).Include(s=>s.Student.FatherTypeIdentity).Include(s=>s.Student.Gender).Include(s=>s.Student.TypeIdentity).Include(s=>s.Student.Birth.Citizenship).Include(s=>s.Student.Address.Street)
                    .Where(w => Array.Contains(w.Student.SchoolId.ToString()) == true && w.Yearbook != null && w.Yearbook.YearbookId == YearbookId).Select(s => s.Student).Skip(skipCount).Take(pageSize).ToList();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        //מחיקת תלמיד
        public bool DeleteStudent(int StudentID)
        {
            try
            {
                var Student = _context.AppStudents.FirstOrDefault(f => f.Idstudent == StudentID);
                if (Student != null)
                {
                    var address = _context.AppAddresses.FirstOrDefault(f => f.Idaddress == Student.AddressId);
                    if (address != null) _context.AppAddresses.Remove(address);
                    var birth = _context.AppBirths.FirstOrDefault(f => f.Idbirth == Student.BirthId);
                    if (birth != null) _context.AppBirths.Remove(birth);
                    var contactInformation = _context.AppContactInformations.FirstOrDefault(f => f.IdcontactInformation == Student.ContactInformationId);
                    if (contactInformation != null) _context.AppContactInformations.Remove(contactInformation);
                    var studentPerYearbook = _context.AppStudentPerYearbooks.Where(w => w.StudentId == StudentID);
                    if (studentPerYearbook != null) _context.AppStudentPerYearbooks.RemoveRange(studentPerYearbook);

                    var list = _context.AppContactPerStudents.Where(w => w.StudentId == StudentID).ToList();
                    _context.AppContactPerStudents.RemoveRange(list);
                    var listDocument = _context.AppDocumentPerStudents.Where(d => d.StudentId == StudentID).ToList();
                    _context.AppDocumentPerStudents.RemoveRange(listDocument);
                    var g =(int) _context.AppStudentPerGroups.FirstOrDefault(g => g.StudentId == StudentID).GroupId;
                    if (g != null)
                    _GroupRepository.DeleteStudentInGroup(StudentID,g);
                    
                }
                
                _context.AppStudents.Remove(Student);
                //Student.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // ID שליפת פרטי תלמיד עפ"י 
        public AppStudent GetStudentDetailsByIDStudent(int StudentID)
        {
            //var stu = _context.AppStudents.Include(b => b.Birth).Include(a => a.Address).Include(c => c.ContactInformation).Include(i => i.AppContactPerStudents).ThenInclude(l=>l.Contact).FirstOrDefault(f => f.Idstudent == StudentID);
            var stu = _context.AppStudents.Include(b => b.Birth).Include(a => a.Address).Include(c => c.ContactInformation).Include(i => i.AppContactPerStudents).ThenInclude(l => l.Contact).ThenInclude(t => t.ContactInformation).Include(i => i.AppContactPerStudents).ThenInclude(i => i.TypeContact).FirstOrDefault(f => f.Idstudent == StudentID);
            if (stu != null && stu.PassportPicture != null)
                stu.PassportPicture = stu.PassportPicture + "?sp=r&st=2021-09-05T07:09:22Z&se=4000-01-01T16:09:22Z&spr=https&sv=2020-08-04&sr=c&sig=rfQUXoumLEarC%2BNrpsSX1d0tH%2FmupgC%2F0QWn4qpq49k%3D";
            //var contactList = _context.AppContactPerStudents.Include(i=>i.Contact).Where(w => w.StudentId == StudentID).ToList();//רשימת קודי האנשי קשר

            return stu;
        }

        //הוספת תלמיד
        public List<string> AddStudent(AppStudent student, int UserCreatedId, int SchoolId, int YearbookId)
        {
            try
            {
                bool isValid = true;
                if (student.TypeIdentityId == 2)
                {
                    isValid = _checkTZRepository.CheckTZ(student.Tz);
                    if (isValid == false) return new List<string>() { "תז לא תקינה", "1" };
                }
                if (student.FatherTz != null && student.FatherTz != "" && student.FatherTypeIdentityId == 2)
                {
                    isValid = _checkTZRepository.CheckTZ(student.FatherTz);
                    if (isValid == false) return new List<string>() { "תז אב לא תקינה", "1" };
                }
                if (student.MotherTz != null && student.MotherTz != "" && student.MotherTypeIdentityId == 2)
                {
                    isValid = _checkTZRepository.CheckTZ(student.MotherTz);
                    if (isValid == false) return new List<string>() { "תז אם לא תקינה", "1" };
                }
                if (student.ApotropusTz != null && student.ApotropusTz != "" && student.ApotropusTypeIdentityId == 2)
                {
                    isValid = _checkTZRepository.CheckTZ(student.ApotropusTz);
                    if (isValid == false) return new List<string>() { "תז אפוטרופוס לא תקינה", "1" };
                }

                student.UserCreatedId = UserCreatedId;
                student.DateCreated = DateTime.UtcNow.AddHours(2);
                //AppStudent newStudent;
                var Student = _context.AppStudents.FirstOrDefault(f => f.Tz == student.Tz && f.SchoolId == SchoolId);
                if (Student != null)
                    return new List<string>() { "הזנת תז של תלמיד קיים במוסד זה", "2" };
                else
                {
                    _context.AppStudents.Add(student);
                    _context.SaveChanges();
                    _context.AppStudentPerYearbooks.Add(new AppStudentPerYearbook() { StudentId = student.Idstudent, YearbookId = YearbookId, UserCreatedId = UserCreatedId, DateCreated = DateTime.Today });
                    _context.SaveChanges();
                    return new List<string>() { "התלמיד נוסף בהצלחה", "4" };

                }
                //return student;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public AppStudent AddStudent1(AppStudent student, int UserCreatedId, int SchoolId, int idyearbookPerSchool)
        {

            bool isValid = false;
            //if (student.TypeIdentityId == 1)
            //    isValid = _checkTZRepository.CheckTZ(student.Tz);
            //if (isValid == false) return new List<string>() { "תז לא תקינה", "1" };


            student.UserCreatedId = UserCreatedId;
            student.DateCreated = DateTime.UtcNow.AddHours(2);
            //AppStudent newStudent;
            //var Student = _context.AppStudents.FirstOrDefault(f => f.Tz == student.Tz && f.AppStudentPerSchools.FirstOrDefault(t=>t.SchoolId == SchoolId)!=null);
            var Student = _context.AppStudents.FirstOrDefault(f => f.Tz == student.Tz && f.SchoolId == student.SchoolId);
            if (Student != null)
                if (_context.AppStudents.FirstOrDefault(f => f.Idstudent == Student.Idstudent && f.SchoolId == SchoolId) != null)
                {
                    if (idyearbookPerSchool != null && idyearbookPerSchool > 0 && _context.AppStudentPerYearbooks.FirstOrDefault(f => f.StudentId == Student.Idstudent && f.YearbookId == idyearbookPerSchool) == null)
                    {
                        _context.AppStudentPerYearbooks.Add(new AppStudentPerYearbook()
                        {
                            DateCreated = DateTime.Today,
                            UserCreatedId = UserCreatedId,
                            StudentId = Student.Idstudent,
                            YearbookId = idyearbookPerSchool
                        });
                        _context.SaveChanges();
                    }
                    return null;
                }//new List<string>() { "שים לב הזנת תז של תלמיד קיים במוסד זה", "2" };
                 //    else
                 //    {
                 //        _context.AppStudentPerSchools.Add(new AppStudentPerSchool() { SchoolId = SchoolId, StudentId = Student.Idstudent });
                 //        _context.SaveChanges();
                 //        return student;//new List<string>() { "התלמיד נוסף למוסד זה בהצלחה", "3" };
                 //        //  newStudent= _context.AppStudents.LastOrDefault(l => l.Tz == student.Tz);
                 //    }
                 //else
            {
                //if (student.Address.CityId == 0) student.Address.CityId = null;
                _context.AppStudents.Add(student);
                //   _context.SaveChanges();

                try
                {
                    _context.SaveChanges();

                    _context.AppStudentPerYearbooks.Add(new AppStudentPerYearbook()
                    {
                        DateCreated = DateTime.Today,
                        UserCreatedId = UserCreatedId,
                        StudentId = student.Idstudent,
                        YearbookId = idyearbookPerSchool
                    });
                    _context.SaveChanges();

                }
                catch (Exception e)
                {
                    _context.AppStudents.Local.Remove(student);
                    throw e;
                }
                //newStudent=_context.AppStudents.LastOrDefault(l => l.Tz == student.Tz);
                //_context.AppStudentPerSchools.Add(new AppStudentPerSchool() { SchoolId = SchoolId, StudentId = student.Idstudent });
                //_context.SaveChanges();
                return student;// new List<string>() { "התלמיד נוסף בהצלחה", "4" };

            }
            //return student;

        }

        public async Task<AppStudent> IsStudentExsist(AppStudent stud, int schoolId)
        {
            try
            {

                var s = _context.AppStudents.Include(i => i.Birth).Include(i => i.Address).Include(i => i.ContactInformation).FirstOrDefault(f => (f.Tz == stud.Tz && f.SchoolId == schoolId));
                return s;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public void UpdateStudent1(AppStudent s, int SchoolId, int userId)
        {
            var student = _context.AppStudents.Include(i => i.AppDocumentPerStudents).Include(i => i.School.TabRequiredDocumentPerStudents).Include(a => a.Address).Include(c => c.ContactInformation).Include(b => b.Birth).FirstOrDefault(f => (f.Tz == s.Tz && f.SchoolId == SchoolId));
            //if (student.Address==null) student.Address = new AppAddress();
            //if ( student.Address.ApartmentNumber!=s.Address.ApartmentNumber||student.Address.CityId!=s.Address.CityId||
            //    student.Address.HouseNumber!=s.Address.HouseNumber||student.Address.NeighborhoodId!=s.Address.NeighborhoodId||
            //    student.Address.PoBox!=s.Address.PoBox||student.Address.StreetId!=s.Address.StreetId||student.Address.ZipCode!=s.Address.ZipCode)
            //    { student.Address.UserUpdated = userId; student.Address.DateUpdated = DateTime.UtcNow.AddHours(2); }
            //if (student.ContactInformation==null) student.ContactInformation = new AppContactInformation();
            //if(student.ContactInformation.Email!=s.ContactInformation.Email||student.ContactInformation.FaxNumber!=s.ContactInformation.FaxNumber||
            //    student.ContactInformation.PhoneNumber1!=s.ContactInformation.PhoneNumber1||student.ContactInformation.PhoneNumber2!=s.ContactInformation.PhoneNumber2||
            //    student.ContactInformation.PhoneNumber3!=s.ContactInformation.PhoneNumber3||student.ContactInformation.TelephoneNumber1!=s.ContactInformation.TelephoneNumber1||
            //    student.ContactInformation.TelephoneNumber2!=s.ContactInformation.TelephoneNumber2)
            //  {student.ContactInformation.UserUpdated = userId; student.ContactInformation.DateUpdated = DateTime.UtcNow.AddHours(2); }

            //var a = student.Idstudent;

            student.ForeignFirstName = s.ForeignFirstName;
            _context.SaveChanges();
            //if (student != null)
            //{
            //    student.DateUpdated = DateTime.UtcNow.AddHours(2);
            //    student.UserUpdated = userId;
            //    student.IsActive = s.IsActive != null ? s.IsActive : true;
            //    student.TypeIdentityId = s.TypeIdentityId;
            //    student.FirstName = s.FirstName;
            //    student.LastName = s.LastName;
            //    student.Code = s.Code;
            //    student.GenderId = s.GenderId;
            //    student.ForeignLastName = s.ForeignLastName;
            //    student.ForeignFirstName = s.ForeignFirstName;
            //    student.PreviusName = s.PreviusName;
            //    student.FatherTz = s.FatherTz;erTz = s.MotherTz;
            //    student.FatherTypeIdentity = s.FatherTypeIdentity;
            //    student.MotherTypeIdentity = s.MotherTypeIdentity;
            //    student.Note = s.Note;
            //    student.AnatherDetails = s.AnatherDetails;
            //    student.StatusId = s.StatusId;
            //    student.StatusStudentId = s.StatusStudentId;
            //    student.ReasonForLeaving = s.ReasonForLeaving;
            //    student.IsActive = s.IsActive;
            //    student.ApotropusTz = s.ApotropusTz;
            //    student.ApotropusTypeIdentity = s.ApotropusTypeIdentity;
            //    if (student.Address == null)
            //    {
            //        student.Address = new AppAddress();
            //    }
            //    if (s.Address != null)
            //    student.Moth
            //    {
            //        student.Address.UserUpdated = userId;
            //        student.Address.DateUpdated = DateTime.Today;
            //        student.Address.CityId = s.Address.CityId;
            //        student.Address.HouseNumber = s.Address.HouseNumber;
            //        student.Address.ApartmentNumber = s.Address.ApartmentNumber;
            //        student.Address.NeighborhoodId = s.Address.NeighborhoodId;
            //        student.Address.PoBox = s.Address.PoBox;
            //        student.Address.StreetId = s.Address.StreetId;
            //        student.Address.ZipCode = s.Address.ZipCode;
            //    }
            //    if (student.Birth == null)
            //    {
            //        student.Birth = new AppBirth();
            //    }
            //    if (s.Birth != null)
            //    {
            //        student.Birth.UserUpdated = userId;
            //        student.Birth.DateUpdated = DateTime.Today;
            //        student.Birth.BirthCountryId = s.Birth.BirthCountryId;
            //        student.Birth.CountryIdofImmigration = s.Birth.CountryIdofImmigration;
            //        student.Birth.BirthHebrewDate = s.Birth.BirthHebrewDate;
            //        student.Birth.CitizenshipId = s.Birth.CitizenshipId;
            //        student.Birth.BirthDate = s.Birth.BirthDate;
            //        student.Birth.DateOfImmigration = s.Birth.DateOfImmigration;
            //    }
            //    if (student.ContactInformation == null)
            //    {
            //        student.ContactInformation = new AppContactInformation();
            //    }
            //    if (s.ContactInformation != null)
            //    {
            //        student.ContactInformation.Email = s.ContactInformation.Email;
            //        student.ContactInformation.PhoneNumber1 = s.ContactInformation.PhoneNumber1;
            //        student.ContactInformation.PhoneNumber2 = s.ContactInformation.PhoneNumber2;
            //        student.ContactInformation.PhoneNumber3 = s.ContactInformation.PhoneNumber3;
            //        student.ContactInformation.TelephoneNumber1 = s.ContactInformation.TelephoneNumber1;
            //        student.ContactInformation.TelephoneNumber2 = s.ContactInformation.TelephoneNumber2;
            //        student.ContactInformation.FaxNumber = s.ContactInformation.FaxNumber;
            //        student.ContactInformation.UserUpdated = userId;
            //        student.ContactInformation.DateUpdated = DateTime.Today;
            //    }


            //    //if (_context.AppStudentPerSchools.FirstOrDefault(f => f.StudentId == student.Idstudent && f.SchoolId == SchoolId) == null)
            //    //    _context.AppStudentPerSchools.Add(new AppStudentPerSchool() { SchoolId = SchoolId, StudentId = student.Idstudent });
            //    _context.SaveChanges();
            //}

        }

        public AppStudent updateStudent(AppStudent s, int SchoolId, int userId, int idyearbookPerSchool = 0)
        {
            //var student1 = _context.AppStudents.FirstOrDefault(f => (f.Tz == s.Tz && f.SchoolId == SchoolId));
            var student = _context.AppStudents.Include(a => a.Address).Include(c => c.ContactInformation).Include(b => b.Birth).Include(i => i.AppStudentPerYearbooks).FirstOrDefault(f => (f.Tz == s.Tz && f.SchoolId == SchoolId));

            //var a = student.Idstudent;
            //student = s;
            //_context.SaveChanges();
            if (student != null)
            {
                student.TypeIdentityId = s.TypeIdentityId != null ? s.TypeIdentityId : student.TypeIdentityId;
                student.FirstName = s.FirstName != null ? s.FirstName : student.FirstName;
                student.LastName = s.LastName != null ? s.LastName : student.LastName;
                student.Code = s.Code != null ? s.Code : student.Code;
                student.GenderId = s.GenderId != null ? s.GenderId : student.GenderId;
                //student.PassportPicture = s.PassportPicture;
                student.ForeignLastName = s.ForeignLastName != null ? s.ForeignLastName : student.ForeignLastName;
                student.ForeignFirstName = s.ForeignFirstName != null ? s.ForeignFirstName : student.ForeignFirstName;
                student.PreviusName = s.PreviusName != null ? s.PreviusName : student.PreviusName;
                student.FatherTz = s.FatherTz != null ? s.FatherTz : student.FatherTz;
                student.MotherTz = s.MotherTz != null ? s.MotherTz : student.MotherTz;
                student.FatherTypeIdentity = s.FatherTypeIdentity != null ? s.FatherTypeIdentity : student.FatherTypeIdentity;
                student.MotherTypeIdentity = s.MotherTypeIdentity != null ? s.MotherTypeIdentity : student.MotherTypeIdentity;
                student.Note = s.Note != null ? s.Note : student.Note;
                student.AnatherDetails = s.AnatherDetails != null ? s.AnatherDetails : student.AnatherDetails;
                student.StatusId = s.StatusId != null ? s.StatusId : student.StatusId;
                student.StatusStudentId = s.StatusStudentId != null ? s.StatusStudentId : student.StatusStudentId;
                student.ReasonForLeaving = s.ReasonForLeaving != null ? s.ReasonForLeaving : student.ReasonForLeaving;
                student.IsActive = s.IsActive != null ? s.IsActive : student.IsActive;
                student.Field1 = s.Field1 != null ? s.Field1 : student.Field1;
                student.Field2 = s.Field2 != null ? s.Field2 : student.Field2;
                student.Field3 = s.Field3 != null ? s.Field3 : student.Field3;
                student.Field4 = s.Field4 != null ? s.Field4 : student.Field4;
                student.Field5 = s.Field5 != null ? s.Field5 : student.Field5;

                student.DateUpdated = DateTime.UtcNow.AddHours(2);
                student.UserUpdatedId = userId;

                student.ApotropusTz = s.ApotropusTz != null ? s.ApotropusTz : student.ApotropusTz;
                student.ApotropusTypeIdentity = s.ApotropusTypeIdentity != null ? s.ApotropusTypeIdentity : student.ApotropusTypeIdentity;
                student.PreviousSchoolId = s.PreviousSchoolId != null ? s.PreviousSchoolId : student.PreviousSchoolId;
                if (student.Address == null)
                {
                    student.Address = new AppAddress();
                }
                if (s.Address != null)
                {
                    student.Address.UserUpdatedId = userId;
                    student.Address.DateUpdated = DateTime.Today;
                    student.Address.CityId = s.Address.CityId != null ? s.Address.CityId : student.Address.CityId;
                    student.Address.HouseNumber = s.Address.HouseNumber != null ? s.Address.HouseNumber : student.Address.HouseNumber;
                    student.Address.ApartmentNumber = s.Address.ApartmentNumber != null ? s.Address.ApartmentNumber : student.Address.ApartmentNumber;
                    student.Address.NeighborhoodId = s.Address.NeighborhoodId != null ? s.Address.NeighborhoodId : student.Address.NeighborhoodId;
                    student.Address.PoBox = s.Address.PoBox != null ? s.Address.PoBox : student.Address.PoBox;
                    student.Address.StreetId = s.Address.StreetId != null ? s.Address.StreetId : student.Address.StreetId;
                    student.Address.ZipCode = s.Address.ZipCode != null ? s.Address.ZipCode : student.Address.ZipCode;
                    student.Address.Comment = s.Address.Comment != null ? s.Address.Comment : student.Address.Comment;
                }
                if (student.Birth == null)
                {
                    student.Birth = new AppBirth();
                }
                if (s.Birth != null)
                {
                    student.Birth.UserUpdatedId = userId;
                    student.Birth.DateUpdated = DateTime.Today;
                    student.Birth.BirthCountryId = s.Birth.BirthCountryId != null ? s.Birth.BirthCountryId : student.Birth.BirthCountryId;
                    student.Birth.CountryIdofImmigration = s.Birth.CountryIdofImmigration != null ? s.Birth.CountryIdofImmigration : student.Birth.CountryIdofImmigration;
                    student.Birth.BirthHebrewDate = s.Birth.BirthHebrewDate != null ? s.Birth.BirthHebrewDate : student.Birth.BirthHebrewDate;
                    student.Birth.CitizenshipId = s.Birth.CitizenshipId != null ? s.Birth.CitizenshipId : student.Birth.CitizenshipId;
                    student.Birth.BirthDate = s.Birth.BirthDate != null ? DateTime.Parse(s.Birth.BirthDate.ToString()) : student.Birth.BirthDate;
                    student.Birth.DateOfImmigration = s.Birth.DateOfImmigration != null ? DateTime.Parse(s.Birth.DateOfImmigration.ToString()) : student.Birth.DateOfImmigration;
             
                }
                if (student.ContactInformation == null)
                {
                    student.ContactInformation = new AppContactInformation();
                }
                if (s.ContactInformation != null)
                {
                    student.ContactInformation.Email = s.ContactInformation.Email != null ? s.ContactInformation.Email : student.ContactInformation.Email;
                    student.ContactInformation.PhoneNumber1 = s.ContactInformation.PhoneNumber1 != null ? s.ContactInformation.PhoneNumber1 : student.ContactInformation.PhoneNumber1;
                    student.ContactInformation.PhoneNumber2 = s.ContactInformation.PhoneNumber2 != null ? s.ContactInformation.PhoneNumber2 : student.ContactInformation.PhoneNumber2;
                    student.ContactInformation.PhoneNumber3 = s.ContactInformation.PhoneNumber3 != null ? s.ContactInformation.PhoneNumber3 : student.ContactInformation.PhoneNumber3;
                    student.ContactInformation.TelephoneNumber1 = s.ContactInformation.TelephoneNumber1 != null ? s.ContactInformation.TelephoneNumber1 : student.ContactInformation.TelephoneNumber1;
                    student.ContactInformation.TelephoneNumber2 = s.ContactInformation.TelephoneNumber2 != null ? s.ContactInformation.TelephoneNumber2 : student.ContactInformation.TelephoneNumber2;
                    student.ContactInformation.FaxNumber = s.ContactInformation.FaxNumber != null ? s.ContactInformation.FaxNumber : student.ContactInformation.FaxNumber;
                    student.ContactInformation.UserUpdatedId = userId;
                    student.ContactInformation.DateUpdated = DateTime.Today;
                    student.ContactInformation.Comment = s.ContactInformation.Comment != null ? s.ContactInformation.Comment : student.ContactInformation.Comment;
                }

                //אם התלמידה קיימת במוסד לשנתון אחר
                if (idyearbookPerSchool > 0)
                    if (student.AppStudentPerYearbooks.FirstOrDefault(f => f.YearbookId == idyearbookPerSchool) == null)
                    {
                        _context.AppStudentPerYearbooks.Add(new AppStudentPerYearbook()
                        {
                            DateCreated = DateTime.Today,
                            UserCreatedId = userId,
                            StudentId = student.Idstudent,
                            YearbookId = idyearbookPerSchool
                        });

                    }

                //if (_context.AppStudentPerSchools.FirstOrDefault(f => f.StudentId == student.Idstudent && f.SchoolId == SchoolId) == null)
                //    _context.AppStudentPerSchools.Add(new AppStudentPerSchool() { SchoolId = SchoolId, StudentId = student.Idstudent });
                _context.SaveChanges();

            }
            return student;

        }

        public AppStudent Clone(AppStudent student)
        {
            //return (AppStudent)this.Clone();
            AppStudent s = new AppStudent()
            {
                TypeIdentityId = student.TypeIdentityId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Code = student.Code,
                GenderId = student.GenderId,
                ForeignLastName = student.ForeignLastName,
                ForeignFirstName = student.ForeignFirstName,
                PreviusName = student.PreviusName,
                FatherTz = student.FatherTz,
                MotherTz = student.MotherTz,
                FatherTypeIdentity = student.FatherTypeIdentity,
                MotherTypeIdentity = student.MotherTypeIdentity,
                Note = student.Note,
                AnatherDetails = student.AnatherDetails,
                StatusId = student.StatusId,
                StatusStudentId = student.StatusStudentId,
                ReasonForLeaving = student.ReasonForLeaving,
                IsActive = student.IsActive,
                ApotropusTz = student.ApotropusTz,
                ApotropusTypeIdentity = student.ApotropusTypeIdentity,
                Address = new AppAddress()
                {
                    CityId = student.Address.CityId,
                    HouseNumber = student.Address.HouseNumber,
                    ApartmentNumber = student.Address.ApartmentNumber,
                    NeighborhoodId = student.Address.NeighborhoodId,
                    PoBox = student.Address.PoBox,
                    StreetId = student.Address.StreetId,
                    ZipCode = student.Address.ZipCode
                },
                Birth = new AppBirth()
                {
                    BirthCountryId = student.Birth.BirthCountryId,
                    CountryIdofImmigration = student.Birth.CountryIdofImmigration,
                    BirthHebrewDate = student.Birth.BirthHebrewDate,
                    CitizenshipId = student.Birth.CitizenshipId,
                    BirthDate = student.Birth.BirthDate,
                    DateOfImmigration = student.Birth.DateOfImmigration
                }
            };
            return s;
        }

        public bool UpdateProfilePathToStudent(int idStudent, string path, int SchoolId, int Userid)
        {
            if (path != null)
            {
                var s = _context.AppStudents.FirstOrDefault(f => f.Idstudent == idStudent);
                if (s != null)
                {
                    if (path == "null")
                        s.PassportPicture = null;
                    else
                        s.PassportPicture = path;
                    s.UserUpdatedId = Userid;
                    s.DateUpdated = DateTime.Today;
                    //if (s.AppDocumentPerStudents.FirstOrDefault(f => f.Name == "passport") == null)
                    //{
                    //    var re = _context.TabRequiredDocumentPerStudents.FirstOrDefault(f => f.SchoolId == SchoolId && f.Name == "passport");
                    //    if(re==null)
                    //         s.AppDocumentPerStudents.Add(new AppDocumentPerStudent() { DateCreated = DateTime.UtcNow.AddHours(2),Name="passport",Path=path,SchoolId=SchoolId,StudentId=idStudent,UserCreated=Userid });
                    //}

                    _context.SaveChanges();
                }
            }
            return true;
        }
        //שליפת הקבוצות לפי תלמידה ושנתון
        public List<AppStudentPerGroup> GetGroupsToStudent(int StudentId, int YearbookId)
        {
            return _context.AppStudentPerGroups.Include(g => g.Group.Group).Include(j => j.Group.AppGroupSemesterPerCourses).ThenInclude(c => c.Course).Where(w => w.StudentId == StudentId && w.Group.YearbookId == YearbookId).ToList();
        }
        //מחיקת שיוך תלמיד לקבוצה
        public AppStudentPerGroup DeleteGroupToStudent(int StudentPerGroupId)
        {
            var StudentPerGroups = _context.AppStudentPerGroups.FirstOrDefault(f => f.IdstudentPerGroup == StudentPerGroupId);
            var TasksToStudents = _context.AppTaskToStudents.Include(t => t.TaskExsist.Course).Where(f => f.TaskExsist != null && f.TaskExsist.Course != null && f.TaskExsist.Course.GroupId == StudentPerGroups.GroupId && f.StudentId == StudentPerGroups.StudentId);
            if (TasksToStudents.FirstOrDefault(f => f.Grade != null || f.FinalScore != null) != null) return null;

            if (StudentPerGroups != null)
            {
                _context.AppTaskToStudents.RemoveRange(TasksToStudents);
                _context.AppStudentPerGroups.Remove(StudentPerGroups);
                _context.SaveChanges();
            }
            else
                StudentPerGroups = new AppStudentPerGroup();
            return StudentPerGroups;
        }
        //הוספת שיוך קבוצה לתלמיד
        public Tuple<bool, string, AppStudentPerGroup> AddGroupPerStudent(AppStudentPerGroup StudentPerGroup)
        {
            //בדיקות תקינות שהתלמיד לא משוייך כבר בתאריכים אלו
            var ListSPG = _context.AppStudentPerGroups.Where(f => f.GroupId == StudentPerGroup.GroupId && f.StudentId == StudentPerGroup.StudentId).ToList();
            if (ListSPG.FirstOrDefault(f => (f.FromDate <= StudentPerGroup.FromDate && f.ToDate >= StudentPerGroup.ToDate) || (f.FromDate >= StudentPerGroup.FromDate && f.ToDate <= StudentPerGroup.ToDate) || (f.FromDate >= StudentPerGroup.FromDate && f.ToDate >= StudentPerGroup.ToDate && f.FromDate <= StudentPerGroup.ToDate) || (f.FromDate <= StudentPerGroup.FromDate && f.ToDate <= StudentPerGroup.ToDate && f.ToDate >= StudentPerGroup.FromDate)) != null)
                return Tuple.Create(false, "תלמיד זה משוייך לקבוצה שהזנת בתאריכים נפגשים", StudentPerGroup);
            var group = _context.AppGroupPerYearbooks.Include(g => g.Group).ThenInclude(t => t.TypeGroup).FirstOrDefault(f => f.IdgroupPerYearbook == StudentPerGroup.GroupId);
            if (group != null && group.Group != null && group.Group.TypeGroup != null && group.Group.TypeGroup.IsMultiple == true)
                _context.AppStudentPerGroups.Add(StudentPerGroup);
            else
            {
                var listSPGinCompatibleTypeGroup = _context.AppStudentPerGroups.Include(g => g.Group).ThenInclude(g => g.Group).ThenInclude(t => t.TypeGroup).Where(w => w.StudentId == StudentPerGroup.StudentId && w.Group != null && w.Group.Group != null && w.Group.Group.TypeGroup != null && group != null && group.Group != null && w.Group.Group.TypeGroup.IdtypeGroup == group.Group.TypeGroupId);
                if (listSPGinCompatibleTypeGroup.FirstOrDefault(f => (f.FromDate <= StudentPerGroup.FromDate && f.ToDate >= StudentPerGroup.ToDate) || (f.FromDate >= StudentPerGroup.FromDate && f.ToDate <= StudentPerGroup.ToDate) || (f.FromDate >= StudentPerGroup.FromDate && f.ToDate >= StudentPerGroup.ToDate && f.FromDate <= StudentPerGroup.ToDate) || (f.FromDate <= StudentPerGroup.FromDate && f.ToDate <= StudentPerGroup.ToDate && f.ToDate >= StudentPerGroup.FromDate)) != null)
                    return Tuple.Create(false, "תלמיד זה משוייך לקבוצה אחרת בתאריכים נפגשים", StudentPerGroup);
                else
                    _context.AppStudentPerGroups.Add(StudentPerGroup);
            }
            _context.SaveChanges();
            var r = _context.AppStudentPerGroups.Include(g => g.Group.Group).Include(j => j.Group.AppGroupSemesterPerCourses).ThenInclude(c => c.Course).FirstOrDefault(f => f.IdstudentPerGroup == StudentPerGroup.IdstudentPerGroup);
            return Tuple.Create(true, "התלמיד נוסף בהצלחה", r);
        }

        public bool AddTasksToStudent(List<AppTaskToStudent> listTaskToStudent)
        {
            _context.AppTaskToStudents.AddRange(listTaskToStudent);
            _context.SaveChanges();
            return true;
        }

        public int? getNumRequiredPerStudent(int schoolId)
        {
            AppSchool appSchool = _context.AppSchools.Include(i => i.TabRequiredDocumentPerStudents).FirstOrDefault(f => f.Idschool == schoolId);
            if (appSchool != null && appSchool.TabRequiredDocumentPerStudents != null)
                return appSchool.TabRequiredDocumentPerStudents.Count;
            return 0;
        }

        public  AppStudent IsStudentExsist(string tz, int schoolId)
        {
            try
            {

                var s = _context.AppStudents.FirstOrDefault(f => (f.Tz == tz && f.SchoolId == schoolId));
                return s;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        //שליפת אפשרויות סיבת עזיבה למוסד
        public List<TReasonForLeaving> GetReasonForLeavingPerSchool(int SchoolId)
        {
            var RFL= _context.TReasonForLeavings.Where(w => w.SchoolId == SchoolId).ToList();
            return RFL;
        }
    }
}
