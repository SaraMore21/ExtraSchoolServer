using AutoMapper;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using DB.Repository.Interfaces;
using DTO.ExcelClasses;
using DTO.Classes;
using System.Data;
using DB.Model;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.RegularExpressions;
using DB.Repository.Classes;
using ClosedXML.Excel;
using GemBox.Spreadsheet;

namespace Services.Classes
{
    public class ExcelService : IExcelService
    {
        private readonly IMapper _mapper;
        private readonly ISchoolRepository _SchoolRepository;
        private readonly IStudentRepository _StudentRepository;
        private readonly ICheckTZRepository _checkTZRepository;
        private readonly IContactRepository _ContactRepository;
        private readonly IGroupRepository _GroupRepository;
        private readonly IStudentPerGroupRepository _StudentPerGroupRepository;
        private readonly IGroupPerYearbookRepository _GroupPerYearbookRepository;
        private readonly IYearbookPerSchoolRepository _YearbookPerSchool;
        private readonly IAgeGroupRepository _AgeGroupRepository;
        private readonly ITypeGroupRepository _TypeGroupRepository;
        private readonly IUserRepository _UserRepository;
        private readonly IScheduleRegularRepository _ScheduleRegularRepository;
        private readonly IDailyScheduleRepository _DailyScheduleRepository;
        private readonly ILessonPerGroupRepository _LessonPerGroupRepository;
        private readonly IProfessionRepository _ProfessionRepository;
        private readonly IProfessinCategoryRepository _ProfessinCategoryRepository;
        


        //private readonly ICacheService _CacheService;


        private AppSchoolDTO _AppSchoolDTO;
        private Dictionary<string, int> _DictStudents;
        private List<AppGroupDTO> _lstGroups;
        private List<AppGroupPerYearbookDTO> _lstGroupPerYearbook;
        private List<AppYearbookPerSchoolDTO> _lstYearbookPerSchool;
        private List<TabAgeGroupDTO> _lstAgeGroup;
        private List<TabTypeGroupDTO> _lstTypeGroup;
        private List<AppGroupPerYearbookDTO> OldListGroupPerYearbook = new List<AppGroupPerYearbookDTO>();
        private Dictionary<string, int> _DictUser = new Dictionary<string, int>();
        private List<AppStudentPerGroupDTO> _lstStudentPerGroup = new List<AppStudentPerGroupDTO>();
        private List<AppLessonPerGroupDTO> _lstLessonPerGroup = new List<AppLessonPerGroupDTO>(); 


        public ExcelService(IMapper mapper, ISchoolRepository SchoolRepository, IStudentRepository StudentRepository,
            IContactRepository ContactRepository, ICheckTZRepository checkTZRepository, IGroupRepository GroupRepository,
            IStudentPerGroupRepository StudentPerGroupRepository, IGroupPerYearbookRepository GroupPerYearbookRepository,
            IYearbookPerSchoolRepository YearbookPerSchool, IAgeGroupRepository AgeGroupRepository,
            ITypeGroupRepository TypeGroupRepository, IUserRepository UserRepository, IScheduleRegularRepository ScheduleRegularRepository
            , IDailyScheduleRepository DailyScheduleRepository, ILessonPerGroupRepository LessonPerGroupRepository,
            IProfessionRepository ProfessionRepository, IProfessinCategoryRepository ProfessinCategoryRepository
          
            )
        {
            _mapper = mapper;
            _SchoolRepository = SchoolRepository;
            _StudentRepository = StudentRepository;
            _checkTZRepository = checkTZRepository;
            _ContactRepository = ContactRepository;
            _GroupRepository = GroupRepository;
            _StudentPerGroupRepository = StudentPerGroupRepository;
            _GroupPerYearbookRepository = GroupPerYearbookRepository;
            _YearbookPerSchool = YearbookPerSchool;
            _AgeGroupRepository = AgeGroupRepository;
            _TypeGroupRepository = TypeGroupRepository;
            _UserRepository = UserRepository;
            _ScheduleRegularRepository = ScheduleRegularRepository;
            _DailyScheduleRepository = DailyScheduleRepository;
            _LessonPerGroupRepository = LessonPerGroupRepository;
            _ProfessionRepository = ProfessionRepository;
            _ProfessinCategoryRepository = ProfessinCategoryRepository;
        }

        //שליחה לפונקציות קריאת אקסלים עפ"י שמות הטבלאות שנבחרו באנגולר.
        public bool ReadFewSheetsFromExcel(string path, int schoolId, int userId, List<string> tablesToRead, DateTime StartDate, DateTime EndDate, int idyearbookPerSchool, bool isNew, bool IsOverride)
        {
            try
            {
                if (File.Exists(path))
                {
                    //Task t = Task.Run(() =>
                    //{   //Lets open the existing excel file and read through its content . Open the excel using openxml sdk
                    //  using (SpreadsheetDocument doc = SpreadsheetDocument.Open(path, false))
                    {
                        DateTime start = DateTime.UtcNow.AddHours(2);


                        Dictionary<string, bool> tasks = new Dictionary<string, bool>();

                        _AppSchoolDTO = _mapper.Map<AppSchoolDTO>(_SchoolRepository.GetSchoolBySchoolId(schoolId));


                        //  Task t = Task.Run(async () =>
                        {
                            foreach (var table in tablesToRead)
                            {
                                switch (table)
                                {
                                    case "תלמידים":
                                        tasks.Add("תלמידים", ReadStudents(schoolId, userId, path, table, idyearbookPerSchool));
                                        break;
                                    case "משתמשים":
                                        tasks.Add("משתמשים", ReadUsers(schoolId, userId, path, table, idyearbookPerSchool));
                                        break;
                                    case "קבוצות לימוד":
                                        tasks.Add("קבוצות לימוד", ReadGroups(schoolId, userId, path, table, idyearbookPerSchool));
                                        break;
                                    case "שיוך תלמיד קבוצה":
                                        {
                                            tasks.Add("שיוך תלמיד קבוצה", ReadStudentPerGroup(schoolId, userId, path, table, idyearbookPerSchool));
                                            break;
                                        }
                                    case "מערכת קבועה":
                                        {
                                            tasks.Add("מערכת קבועה", ReadScheduleRegular(schoolId, userId, path, table, StartDate, EndDate, isNew, IsOverride));
                                            break;
                                        }
                                    case "אנשי קשר":
                                        {
                                            tasks.Add("אנשי קשר", ReadContactPerStudent(schoolId, userId, path, table));
                                            break;
                                        }    
                                    case "מקצועות":
                                        {
                                            tasks.Add("מקצועות", ReadProfession(schoolId, userId, path, table));
                                            break;
                                        }
                                    case "שעות שיעורים לקבוצה":
                                    {
                                            tasks.Add("שעות שיעורים לקבוצה", ReadLessonPerGroup(schoolId, userId, path, table));
                                            break;
                                        }

                                    default:
                                        break;
                                }
                            }
                            DateTime end = DateTime.UtcNow.AddHours(2);

                            string str = "";

                            str += "שלום להנהלה " + (_AppSchoolDTO != null && _AppSchoolDTO.Name != null ? _AppSchoolDTO.Name : ' ');
                            str += "<br>";
                            str += "העלאת הטבלאות הסתיימה" + "<br/>";
                            tasks.ToList().ForEach(t =>
                            {
                                str += "נתוני טבלת " + t.Key + " " + (t.Value ? "נשמרו בהצלחה" : "נכשלו בשמירה");
                                str += "<br/>" + "<br/>" + "<br/>";
                            });

                            TimeSpan time = end - start;
                            str += "משך זמן השמירה היה " + time.ToString(@"hh\:mm\:ss");
                            str += "<br/> בברכה, מערכת More21";
                            //string mailBody = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "InternalResources", "MailBody.html"));
                            // string mailBody = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "MailBody.html"));
                            // str = mailBody.Replace("$replace", str);
                            string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                            string contact_email1 = _AppSchoolDTO != null && _AppSchoolDTO.UserContact != null ? _AppSchoolDTO.UserContact.ContactInformation.Email : null;

                            if (contact_email == null)
                                contact_email = "more21service@gmail.com";
                            new MailService().SendEmail(contact_email, "העלאת הטבלאות הסתיימה", str.ToString());

                        }
                        //   );
                        return true;
                    }

                }
                return false;

            }
            catch (Exception e)
            {
                string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                if (contact_email == null)
                    contact_email = "ravcevel@gmail.com";
                new MailService().SendEmail(contact_email, "היתה בעיה בהעלאת הטבלאות", e.Message);
                return false;
            }
        }

        //העלאת תלמידים מאקסל
        // private async Task<bool> ReadStudents(int schoolId, int userId, string path, string nameTab, int idyearbookPerSchool)
        private bool ReadStudents(int schoolId, int userId, string path, string nameTab, int idyearbookPerSchool)
        {
            try
            {

                bool isValid = true;
                bool flag = false;
                string body1 = "<h3>" + "הרשומות הבאות הן רשומות שכבר היו קיימות במסד נתונים והועלו שוב עם נתונים לא תואמים." + "<br>" +
                        "שימו לב כי הנתונים עודכנו." + "<br>" +
                        "</h3>"
                        + "<h4>בכל זוג שורות השורה הלבנה הם הנתונים הישנים והכחול הם הנתונים החדשים והמעודכנים</h4>";
                body1 += "<table  border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 600 + ">";
                body1 += "<tr bgcolor='#4da6ff'>";
                body1 += "<th>" + "מספר זיהוי" + "</th>";
                body1 += "<th>" + "סוג זיהוי" + "</th>";
                body1 += "<th>" + "קוד" + "</th>";
                body1 += "<th>" + "פרטי" + "</th>";
                body1 += "<th>" + "משפחה" + "</th>";
                body1 += "<th>" + "תאריך לידה לועזי" + "</th>";
                body1 += "<th>" + "תאריך עברי" + "</th>";
                body1 += "<th>" + "ארץ לידה" + "</th>";
                body1 += "<th>" + "אזרחות" + "</th>";
                body1 += "<th>" + "תאריך עליה" + "</th>";
                body1 += "<th>" + "ארץ עליה" + "</th>";
                body1 += "<th>" + "מין" + "</th>";
                body1 += "<th>" + "מצב משפחתי" + "</th>";
                body1 += "<th>" + "פרטי בלועזית" + "</th>";
                body1 += "<th>" + "משפחה בלועזית" + "</th>";
                body1 += "<th>" + "שם משפחה קודם" + "</th>";
                body1 += "<th>" + "מספר זיהוי אב" + "</th>";
                body1 += "<th>" + "סוג זיהוי אב" + "</th>";
                body1 += "<th>" + "מספר זיהוי אם" + "</th>";
                body1 += "<th>" + "סוג זיהוי אם" + "</th>";
                body1 += "<th>" + "מספר זיהוי אפוטרופוס" + "</th>";
                body1 += "<th>" + "סוג זיהוי אפוטרופוס" + "</th>";
                body1 += "<th>" + "פעיל" + "</th>";
                body1 += "<th>" + "סטטוס תלמידה" + "</th>";
                body1 += "<th>" + "סיבה" + "</th>";
                body1 += "<th>" + "עיר" + "</th>";
                body1 += "<th>" + "רחוב" + "</th>";
                body1 += "<th>" + "בנין" + "</th>";
                body1 += "<th>" + "דירה" + "</th>";
                body1 += "<th>" + "ת.ד." + "</th>";
                body1 += "<th>" + "מיקוד" + "</th>";
                body1 += "<th>" + "מייל" + "</th>";
                body1 += "<th>" + "פקס" + "</th>";
                body1 += "<th>" + "נייד 1" + "</th>";
                body1 += "<th>" + "נייד 2" + "</th>";
                body1 += "<th>" + "נייד 3" + "</th>";
                body1 += "<th>" + "טלפון 1" + "</th>";
                body1 += "<th>" + "טלפון 2" + "</th>";
                body1 += "<th>" + "פרטים נוספים" + "</th>";
                body1 += "<th>" + "הערה" + "</th>";
                body1 += "</tr>";

                List<AppStudentWhithDetailsDTO> TzInvalid = new List<AppStudentWhithDetailsDTO>();
                List<AppStudentWhithDetailsDTO> TzExists = new List<AppStudentWhithDetailsDTO>();
                List<AppStudentWhithDetailsDTO> ListStudents = new List<AppStudentWhithDetailsDTO>();

                AppStudentWhithDetailsDTO student = new AppStudentWhithDetailsDTO();
                string str = ReadExcel(path, nameTab);

                List<AppStudentXL> students = JsonConvert.DeserializeObject<List<AppStudentXL>>(str);
                students = students.Where(w => w.Tz != "" && w.Tz != null).ToList();




                int result;
                short result2;
                double result3;
                bool result5;

                AppStudentWhithDetailsDTO newStudent;
                students.ForEach(s =>
                {
                    try
                    {
                        #region
                        newStudent = new AppStudentWhithDetailsDTO();
                        newStudent.Tz = s.Tz;
                        newStudent.TypeIdentityId = int.TryParse(s.TypeIdentity, out result) ? result : (int?)null;
                        newStudent.FirstName = s.FirstName;
                        newStudent.LastName = s.LastName;
                        newStudent.Code = s.Code;
                        newStudent.GenderId = short.TryParse(s.Gender, out result2) ? result2 : (short?)null;
                        newStudent.ForeignLastName = s.ForeignLastName;
                        newStudent.ForeignFirstName = s.ForeignFirstName;
                        newStudent.PreviusName = s.PreviusName;
                        newStudent.FatherTz = s.FatherTz;
                        newStudent.MotherTz = s.MotherTz;
                        newStudent.FatherTypeIdentityId = int.TryParse(s.FatherTypeIdentity, out result) ? result : (int?)null;
                        newStudent.MotherTypeIdentityId = int.TryParse(s.MotherTypeIdentity, out result) ? result : (int?)null;
                        newStudent.Note = s.Note;
                        newStudent.AnatherDetails = s.AnatherDetails;
                        newStudent.StatusId = int.TryParse(s.Status, out result) ? result : (int?)null;
                        newStudent.StatusStudentId = int.TryParse(s.StatusStudentId, out result) ? result : (int?)null;
                        newStudent.ReasonForLeavingId = int.TryParse(s.ReasonForLeaving, out result) ? result : (int?)null;
                        newStudent.IsActive = bool.TryParse(s.IsActive, out result5) ? result5 : true;
                        newStudent.Field1 = s.Field1;
                        newStudent.Field2 = s.Field2;
                        newStudent.Field3 = s.Field3;
                        newStudent.Field4 = s.Field4;
                        newStudent.Field5 = s.Field5;
                        newStudent.UserCreatedId = userId;
                        newStudent.DateCreated = DateTime.Today;
                        newStudent.ApotropusTz = s.ApotropusTz;
                        newStudent.ApotropusTypeIdentityId = int.TryParse(s.ApotropusTypeIdentity, out result) ? result : (int?)null;
                        newStudent.SchoolId = schoolId;

                        newStudent.Address = new AppAddressDTO();
                        newStudent.Address.ApartmentNumber = s.HouseNum;
                        newStudent.Address.CityId = int.TryParse(s.City, out result) ? result : (int?)null;
                        newStudent.Address.DateCreated = DateTime.Today;
                        newStudent.Address.HouseNumber = s.BuildingNum;
                        newStudent.Address.PoBox = int.TryParse(s.MailBox, out result) ? result : (int?)null;
                        newStudent.Address.StreetId = int.TryParse(s.Street, out result) ? result : (int?)null;
                        newStudent.Address.UserCreatedId = userId;
                        newStudent.Address.ZipCode = int.TryParse(s.Zip, out result) ? result : (int?)null;

                        newStudent.Birth = new AppBirthDTO();
                        newStudent.Birth.BirthCountryId = int.TryParse(s.BirthCountryId, out result) ? result : (int?)null;
                        newStudent.Birth.BirthDate = s.BirthDate != null ? (double.TryParse(s.BirthDate, out result3) ? DateTime.FromOADate(result3) : (DateTime?)null) : (DateTime?)null;
                        newStudent.Birth.BirthHebrewDate = s.BirthHebrewDate;
                        newStudent.Birth.CitizenshipId = int.TryParse(s.Citizenship, out result) ? result : (int?)null;
                        newStudent.Birth.CountryIdofImmigration = int.TryParse(s.CountryIdofImmigration, out result) ? result : (int?)null;
                        newStudent.Birth.DateCreated = DateTime.Today;
                        newStudent.Birth.DateOfImmigration = s.DateOfImmigration != null ? (double.TryParse(s.DateOfImmigration, out result3) ? DateTime.FromOADate(result3) : (DateTime?)null) : (DateTime?)null;
                        newStudent.Birth.UserCreatedId = userId;

                        newStudent.ContactInformation = new AppContactInformationDTO();
                        newStudent.ContactInformation.DateCreated = DateTime.Today;
                        newStudent.ContactInformation.Email = s.Mail;
                        newStudent.ContactInformation.FaxNumber = s.Fax;
                        newStudent.ContactInformation.PhoneNumber1 = s.Mobile1;
                        newStudent.ContactInformation.PhoneNumber2 = s.Mobile2;
                        newStudent.ContactInformation.PhoneNumber3 = s.Mobile3;
                        newStudent.ContactInformation.TelephoneNumber1 = s.Telehone1;
                        newStudent.ContactInformation.TelephoneNumber2 = s.Telehone2;
                        newStudent.ContactInformation.UserCreatedId = userId;

                        #endregion עדכון נתוני תלמיד

                        if (newStudent.TypeIdentityId == 2)
                            isValid = _checkTZRepository.CheckTZ(s.Tz);
                        if (!isValid)
                        {
                            TzInvalid.Add(newStudent);
                            isValid = true;
                        }
                        else
                        {
                            {
                                try
                                {
                                    var stu = _StudentRepository.IsStudentExsist(_mapper.Map<AppStudent>(newStudent), schoolId);
                                    if (stu != null)
                                        student = _mapper.Map<AppStudentWhithDetailsDTO>(stu.Result);

                                }
                                catch (Exception ex)
                                {

                                    throw;
                                }

                                if (student != null)
                                {
                                    //Type stud = typeof(AppStudent);
                                    //var fields = stud.GetProperties();
                                    //for (int i = 0; i < fields.Length; i++)
                                    //{
                                    //}
                                    // if(student.AppStudentPerSchools!=null && student.AppStudentPerSchools.FirstOrDefault(f=> f.SchoolId==schoolId)!=null)
                                    if (
                                             student.TypeIdentityId != newStudent.TypeIdentityId ||
                                             student.FirstName != newStudent.FirstName ||
                                             student.LastName != newStudent.LastName ||
                                             student.Code != newStudent.Code ||
                                             student.GenderId != newStudent.GenderId ||
                                             student.ForeignLastName != newStudent.ForeignLastName ||
                                             student.ForeignFirstName != newStudent.ForeignFirstName ||
                                             student.PreviusName != newStudent.PreviusName ||
                                             student.FatherTz != newStudent.FatherTz ||
                                             student.MotherTz != newStudent.MotherTz ||
                                             student.FatherTypeIdentityId != newStudent.FatherTypeIdentityId ||
                                             student.MotherTypeIdentityId != newStudent.MotherTypeIdentityId ||
                                             student.Note != newStudent.Note ||
                                             student.AnatherDetails != newStudent.AnatherDetails ||
                                             student.StatusId != newStudent.StatusId ||
                                             student.StatusStudentId != newStudent.StatusStudentId ||
                                             student.ReasonForLeavingId != newStudent.ReasonForLeavingId ||
                                             student.IsActive != newStudent.IsActive ||
                                             student.ApotropusTz != newStudent.ApotropusTz ||
                                             student.ApotropusTypeIdentityId != newStudent.ApotropusTypeIdentityId ||
                                             student.Address.CityId != newStudent.Address.CityId ||
                                             student.Address.HouseNumber != newStudent.Address.HouseNumber ||
                                             student.Address.ApartmentNumber != newStudent.Address.ApartmentNumber ||
                                             // student.Address.NeighborhoodId != newStudent.Address.NeighborhoodId ||
                                             student.Address.PoBox != newStudent.Address.PoBox ||
                                             student.Address.StreetId != newStudent.Address.StreetId ||
                                             student.Address.ZipCode != newStudent.Address.ZipCode ||
                                             student.Birth.BirthCountryId != newStudent.Birth.BirthCountryId ||
                                             student.Birth.CountryIdofImmigration != newStudent.Birth.CountryIdofImmigration ||
                                             student.Birth.BirthHebrewDate != newStudent.Birth.BirthHebrewDate ||
                                             student.Birth.CitizenshipId != newStudent.Birth.CitizenshipId ||
                                             student.Birth.BirthDate != newStudent.Birth.BirthDate ||
                                             student.Birth.DateOfImmigration != newStudent.Birth.DateOfImmigration ||
                                             student.ContactInformation.Email != newStudent.ContactInformation.Email ||
                                             student.ContactInformation.FaxNumber != newStudent.ContactInformation.FaxNumber ||
                                             student.ContactInformation.PhoneNumber1 != newStudent.ContactInformation.PhoneNumber1 ||
                                             student.ContactInformation.PhoneNumber2 != newStudent.ContactInformation.PhoneNumber2 ||
                                             student.ContactInformation.PhoneNumber3 != newStudent.ContactInformation.PhoneNumber3 ||
                                             student.ContactInformation.TelephoneNumber1 != newStudent.ContactInformation.TelephoneNumber1 ||
                                             student.ContactInformation.TelephoneNumber2 != newStudent.ContactInformation.TelephoneNumber2

                                          )
                                    {

                                        TzExists.Add(student);
                                        TzExists.Add(newStudent);

                                        flag = true;
                                        if (TzExists != null && TzExists.Count() > 0)
                                        {
                                            var i = 0;

                                            foreach (var item in TzExists)
                                            {

                                                if (i % 2 == 0)
                                                    body1 += "<tr>";
                                                else
                                                    body1 += "<tr bgcolor='#4da6ff'>";

                                                body1 += "<td>" + item.Tz + "</td>";
                                                body1 += "<td>" + item.TypeIdentityId + "</td>";
                                                body1 += "<td>" + item.Code + "</td>";
                                                body1 += "<td>" + item.FirstName + "</td>";
                                                body1 += "<td>" + item.LastName + "</td>";
                                                body1 += "<td>" + item.Birth.BirthDate + "</td>"  /*+ "/" + conv.Month + "/" + conv.Year + "</td>"*/;
                                                body1 += "<td>" + item.Birth.BirthHebrewDate + "</td>";
                                                body1 += "<td>" + item.Birth.BirthCountryId + "</td>";
                                                body1 += "<td>" + item.Birth.CitizenshipId + "</td>";
                                                body1 += "<td>" + item.Birth.DateOfImmigration + "</td>";
                                                body1 += "<td>" + item.Birth.CountryIdofImmigration + "</td>";
                                                body1 += "<td>" + item.GenderId + "</td>";
                                                body1 += "<td>" + item.StatusId + "</td>";
                                                body1 += "<td>" + item.ForeignFirstName + "</td>";
                                                body1 += "<td>" + item.ForeignLastName + "</td>";
                                                body1 += "<td>" + item.PreviusName + "</td>";
                                                body1 += "<td>" + item.FatherTz + "</td>";
                                                body1 += "<td>" + item.FatherTypeIdentityId + "</td>";
                                                body1 += "<td>" + item.MotherTz + "</td>";
                                                body1 += "<td>" + item.MotherTypeIdentityId + "</td>";
                                                body1 += "<td>" + item.ApotropusTz + "</td>";
                                                body1 += "<td>" + item.ApotropusTypeIdentityId + "</td>";
                                                body1 += "<td>" + item.IsActive + "</td>";
                                                body1 += "<td>" + item.StatusStudentId + "</td>";
                                                body1 += "<td>" + item.ReasonForLeavingId + "</td>";
                                                body1 += "<td>" + item.Address.CityId + "</td>";
                                                body1 += "<td>" + item.Address.StreetId + "</td>";
                                                body1 += "<td>" + item.Address.HouseNumber + "</td>";
                                                body1 += "<td>" + item.Address.ApartmentNumber + "</td>";
                                                body1 += "<td>" + item.Address.PoBox + "</td>";
                                                body1 += "<td>" + item.Address.ZipCode + "</td>";
                                                body1 += "<td>" + item.ContactInformation.Email + "</td>";
                                                body1 += "<td>" + item.ContactInformation.FaxNumber + "</td>";
                                                body1 += "<td>" + item.ContactInformation.PhoneNumber1 + "</td>";
                                                body1 += "<td>" + item.ContactInformation.PhoneNumber2 + "</td>";
                                                body1 += "<td>" + item.ContactInformation.PhoneNumber3 + "</td>";
                                                body1 += "<td>" + item.ContactInformation.TelephoneNumber1 + "</td>";
                                                body1 += "<td>" + item.ContactInformation.TelephoneNumber2 + "</td>";
                                                body1 += "<td>" + item.AnatherDetails + "</td>";
                                                body1 += "<td>" + item.Note + "</td>";
                                                body1 += "</tr>";

                                                i++;
                                            }

                                            TzExists = new List<AppStudentWhithDetailsDTO>();
                                        }

                                        _StudentRepository.updateStudent(_mapper.Map<AppStudent>(newStudent), schoolId, userId, idyearbookPerSchool);
                                    }
                                }

                            }



                            _StudentRepository.AddStudent1(_mapper.Map<AppStudent>(newStudent), userId, schoolId, idyearbookPerSchool);


                        }
                    }
                    catch (Exception e)
                    {
                        string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                        if (contact_email == null)
                            contact_email = "ravcevel@gmail.com";
                        //new MailService().SendEmail(contact_email, "שגיאה בהעלאת תלמיד מאקסל",s.Tz+"<br>" + "<br>" + ( e.InnerException != null ? e.InnerException.Message : e.Message));
                        new MailService().SendEmail("more21service@gmail.com", "שגיאה בהעלאת תלמיד מאקסל במוסד " + (_AppSchoolDTO != null && _AppSchoolDTO.Name != null ? _AppSchoolDTO.Name : ' '), s.Tz + "<br>" + "<br>" + (e.InnerException != null ? e.InnerException.Message : e.Message));

                    }

                });

                //List<AppStudent> AppStudents = _mapper.Map<List<AppStudent>>(students);


                if (flag)
                {

                    body1 += "</table>";

                    string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                    if (contact_email == null)
                        contact_email = "ravcevel@gmail.com";

                    new MailService().SendEmail(contact_email, "תעודות זהות כפולות", body1);

                }

                if (TzInvalid != null && TzInvalid.Count() > 0)
                {
                    var body2 = "שלום להנהלה " + _AppSchoolDTO != null && _AppSchoolDTO.Name != null ? _AppSchoolDTO.Name : " ";

                    body2 += "<h3>" + "הרשומות הבאות הן רשומות שלא נשמרו כיוון שהועלו תעודות זהות לא תקינות." + "<br>" +
                       "</h3>" + "<br>";
                    body2 += "<table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 200 + ">";
                    body2 += "<tr bgcolor='#4da6ff'>";
                    body2 += "<th>" + "מספר זיהוי" + "</th>";
                    body2 += "</tr>";

                    var i = 0;


                    foreach (var item in TzInvalid)
                    {

                        if (i % 2 == 0)
                            body2 += "<tr>";
                        else
                            body2 += "<tr bgcolor='#4da6ff'>";

                        body2 += "<td>" + item.Tz + "</td>";
                        body2 += "</tr>";

                        i++;
                    }
                    body2 += "</table>";
                    string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                    if (contact_email == null)
                        contact_email = "ravcevel@gmail.com";

                    new MailService().SendEmail(contact_email, "תעודות זהות לא תקינות", body2);

                }

                return true;
                //return _StudentRepository.AddListStudents(AppStudents, schoolId);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        //העלאת קבוצות מאקסל
        private bool ReadGroups(int schoolId, int userId, string path, string nameTab, int idyearbookPerSchool)
        {
            try
            {

                List<AppGroupXL> Error = new List<AppGroupXL>();
                List<AppGroupPerYearbookDTO> ListGroupPerYearbook = new List<AppGroupPerYearbookDTO>();
                AppYearbookPerSchool yearBook = new AppYearbookPerSchool();

                if (idyearbookPerSchool == null || idyearbookPerSchool == 0)
                    return false;
                if (idyearbookPerSchool != 0)
                {
                    yearBook = _YearbookPerSchool.GetYearBookById(idyearbookPerSchool);
                    if (yearBook == null)
                        return false;
                }

                string str = ReadExcel(path, nameTab);
                List<AppGroupXL> Groups = JsonConvert.DeserializeObject<List<AppGroupXL>>(str);

                int resInt;
                int UserPerGroupId;
                AppGroupDTO NewGroup;

                if (_lstGroups == null || _lstGroups.Count == 0)
                    _lstGroups = _mapper.Map<List<AppGroupDTO>>(_GroupRepository.GetAllNameGroup(schoolId));

                //if (_lstYearbookPerSchool == null || _lstYearbookPerSchool.Count == 0)
                //    _lstYearbookPerSchool = _mapper.Map<List<AppYearbookPerSchoolDTO>>(_YearbookPerSchool.GetYearbookPerSchool(schoolId));

                if (_lstAgeGroup == null || _lstAgeGroup.Count == 0)
                    _lstAgeGroup = _mapper.Map<List<TabAgeGroupDTO>>(_AgeGroupRepository.GetLstAgeGroupBySchoolId(schoolId));

                if (_lstTypeGroup == null || _lstTypeGroup.Count == 0)
                    _lstTypeGroup = _mapper.Map<List<TabTypeGroupDTO>>(_TypeGroupRepository.GetLstTypeGroupByIdSchool(schoolId));

                if (OldListGroupPerYearbook == null || OldListGroupPerYearbook.Count == 0)
                    OldListGroupPerYearbook = _mapper.Map<List<AppGroupPerYearbookDTO>>(_GroupPerYearbookRepository.GetLstGroupPerYearBookBySchoolId(schoolId));

                if (_DictUser == null || _DictUser.Count == 0)
                {
                    _DictUser = new Dictionary<string, int>();
                    List<SecUserDTO> LstUser = _mapper.Map<List<SecUserDTO>>(_UserRepository.GetAllUserBySchoolId(schoolId));
                    LstUser.ForEach(f =>
                    {
                        if (f.Tz != null)
                            _DictUser.TryAdd(f.Tz, f.UserPerSchoolID);
                    });
                }



                Groups.ForEach(f =>
                {
                    try
                    {
                        if (f.UserId != null && _DictUser.TryGetValue(f.UserId, out resInt))
                            UserPerGroupId = resInt;
                        else UserPerGroupId = 0;

                        if (f.nameGroup != null && f.nameGroup != "")
                        {
                            // אם לא בחרו ראש קבוצה
                            if (UserPerGroupId == null || UserPerGroupId == 0)
                            {
                                Error.Add(f);
                            }
                            else
                            {
                                //בדיקה אם קיימת קבוצה עם שם זהה למוסד זה ב- DB
                                AppGroupDTO a = _lstGroups.FirstOrDefault(x => x.NameGroup == f.nameGroup && x.SchoolId == schoolId);

                                //כבר קיימת קבוצה בDB עם שם זהה
                                if (a != null)
                                {

                                    //בדיקה אם עדיין לא קיים שיוך לקבוצה ושנתון זה ,וגם שלא ניסו להכניס עכשיו קבוצה זו כלומר פעם שניה באותו אקסל אם כן יש לא עושה כלום.
                                    if (ListGroupPerYearbook.FirstOrDefault(x => x.GroupId == a.Idgroup) == null && OldListGroupPerYearbook.FirstOrDefault(x => x.GroupId == a.Idgroup && x.YearbookId == idyearbookPerSchool) == null)
                                    {
                                        ListGroupPerYearbook.Add(new AppGroupPerYearbookDTO()
                                        {
                                            GroupId = a.Idgroup,
                                            UserCreatedId = userId,
                                            DateCreated = DateTime.Today,//.AddHours(2),
                                            YearbookId = idyearbookPerSchool,// year,
                                            AppUserPerGroups = new List<AppUserPerGroupDTO>()
                                            {
                                                new AppUserPerGroupDTO() {
                                                UserId = UserPerGroupId, FromDate = yearBook.FromDate, ToDate = yearBook.ToDate ,
                                                UserCreatedId = userId,
                                                DateCreated = DateTime.Today//UtcNow.AddHours(2) }
                                                }
                                            }
                                        });
                                    }
                                }
                                //אם לא קיימת קבוצה עם שם כזה בדאטא פותח גם קבוצת אב וגם קבוצה פר שנתון
                                else
                                {
                                    //בדיקה אם לא מנסים להכניס את אותה קבוצה באותו אקסל פעמיים
                                    if (ListGroupPerYearbook.FirstOrDefault(x => x.Group != null && x.Group.NameGroup == f.nameGroup) == null)
                                    {

                                        ListGroupPerYearbook.Add(new AppGroupPerYearbookDTO()
                                        {
                                            Group = new AppGroupDTO()
                                            {
                                                AgeGroupId = _lstAgeGroup.FirstOrDefault(x => x.IdageGroup == (int.TryParse(f.AgeGroup, out resInt) ? resInt : null))?.IdageGroup,
                                                DateCreated = DateTime.Today,//.UtcNow.AddHours(2),
                                                NameGroup = f.nameGroup,
                                                SchoolId = schoolId,
                                                TypeGroupId = _lstTypeGroup.FirstOrDefault(x => x.IdtypeGroup == (int.TryParse(f.TypeGroup, out resInt) ? resInt : null))?.IdtypeGroup,
                                                UserCreatedId = userId,
                                            },
                                            UserCreatedId = userId,
                                            DateCreated = DateTime.Today,//.UtcNow.AddHours(2),
                                            YearbookId = idyearbookPerSchool,// year,
                                            AppUserPerGroups = new List<AppUserPerGroupDTO>() {
                                                new AppUserPerGroupDTO() {
                                                    UserId = UserPerGroupId,
                                                    FromDate = yearBook.FromDate,
                                                    ToDate = yearBook.ToDate ,
                                                    UserCreatedId = userId,
                                                    DateCreated = DateTime.Today//.UtcNow.AddHours(2)
                                                }
                                            }
                                        });
                                    }

                                }

                            }
                        }

                    }
                    catch (Exception)
                    {
                        Error.Add(f);
                    }

                });
                if (Error.Count > 0)
                {
                    String body =
                        "<h3>" + "קבוצות הלימוד הבאות לא הועלו כיוון שהיתה בהם תקלה." + "<br>" +
                        "</h3>"
                               + "<table  border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 600 + ">" +
                                 "<tr bgcolor='#4da6ff'>"
                               + "<th>" + "שם קבוצה" + "</th>"
                               + "<th>" + "שכבת גיל" + "</th>"
                               + "<th>" + "סוג קבוצה" + "</th>"
                               + "<th>" + "שנתון" + "</th>"
                               + "</tr>";
                    var i = 0;
                    Error.ForEach(e =>
                                    {
                                        if (i % 2 == 0)
                                            body += "<tr>";
                                        else
                                            body += "<tr bgcolor='#4da6ff'>";
                                        body += "<td>" + e.nameGroup + "</td>";
                                        body += "<td>" + e.AgeGroup + "</td>";
                                        body += "<td>" + e.TypeGroup + "</td>";
                                        body += "<td>" + e.YearBook + "</td>";
                                        body += "</tr>";
                                        i++;
                                    }
                    );


                    body += "</table>";
                    string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                    if (contact_email == null)
                        contact_email = "ravcevel@gmail.com";
                    new MailService().SendEmail(contact_email, "שגיאה בהעלאת קבוצת לימוד מאקסל במוסד " + (_AppSchoolDTO != null && _AppSchoolDTO.Name != null ? _AppSchoolDTO.Name : ' '), body);
                    new MailService().SendEmail("more21service@gmail.com", "שגיאה בהעלאת קבוצת לימוד מאקסל במוסד " + (_AppSchoolDTO != null && _AppSchoolDTO.Name != null ? _AppSchoolDTO.Name : ' '), body);

                }
                bool groupPerYearbook = true;
                //if (ListGroup.Count > 0)
                //{
                //    var lst = _mapper.Map<List<AppGroup>>(ListGroup);
                //    group = _GroupRepository.AddListGroups(lst);
                //}
                if (ListGroupPerYearbook != null && ListGroupPerYearbook.Count > 0)
                {
                    var lst1 = _mapper.Map<List<AppGroupPerYearbook>>(ListGroupPerYearbook);
                    groupPerYearbook = _GroupPerYearbookRepository.AddListGroupsPerYearbook(lst1);
                }
                return groupPerYearbook;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        //העלאת שיוך תלמיד לקבוצה מאקסל
        private bool ReadStudentPerGroup(int schoolId, int userId, string path, string nameTab, int idyearbookPerSchool)
        {
            try
            {
                AppYearbookPerSchool yearBook = new AppYearbookPerSchool();
                if (idyearbookPerSchool == null || idyearbookPerSchool == 0)
                    return false;
                if (idyearbookPerSchool != 0)
                {
                    yearBook = _YearbookPerSchool.GetYearBookById(idyearbookPerSchool);
                    if (yearBook == null)
                        return false;
                }

                Dictionary<int, bool?> DictGroupMultiple = _GroupPerYearbookRepository.GetDictGroupPerYearBookIsMultipleBySchoolId(schoolId);
                if (_lstGroupPerYearbook == null || _lstGroupPerYearbook.Count == 0)
                    _lstGroupPerYearbook = _mapper.Map<List<AppGroupPerYearbookDTO>>(_GroupPerYearbookRepository.GetLstGroupPerYearBookBySchoolId(schoolId));

                if (_lstStudentPerGroup == null || _lstStudentPerGroup.Count == 0)
                    _lstStudentPerGroup = _mapper.Map<List<AppStudentPerGroupDTO>>(_StudentPerGroupRepository.GetLstUserPerGroupBySchoolId(schoolId));

                if (_DictStudents == null || _DictStudents.Count == 0)
                {
                    _DictStudents = new Dictionary<string, int>();
                    List<AppStudentDTO> lstStudents = _mapper.Map<List<AppStudentDTO>>(_StudentRepository.GetListStudentsBySchoolId(schoolId));
                    lstStudents.ForEach(f =>
                    {
                        _DictStudents.Add(f.Tz, f.Idstudent);
                    });
                }

                List<AppStudentPerGroupXL> Error = new List<AppStudentPerGroupXL>();
                List<AppStudentPerGroupDTO> ListStudentPerGroup = new List<AppStudentPerGroupDTO>();

                string str = ReadExcel(path, nameTab);
                List<AppStudentPerGroupXL> StudentPerGroupLst = JsonConvert.DeserializeObject<List<AppStudentPerGroupXL>>(str);

                int resInt;
                double resdouble;

                AppStudentPerGroupDTO NewStudentPerGroup;
                int groupId1, group;
                StudentPerGroupLst.ForEach(f =>
                {
                    try
                    {
                        if (f.Tz != null)
                        {
                            groupId1 = int.TryParse(f.IdGroup, out resInt) ? resInt : 0;
                            group = (int)_lstGroupPerYearbook.FirstOrDefault(s => s.IdgroupPerYearbook == groupId1)?.IdgroupPerYearbook;

                            //אם לא שייכו לקבוצה טובה
                            if (group < 1)
                                Error.Add(f);

                            else
                            {
                                DateTime? fromDate = double.TryParse(f.StartDate, out resdouble) ? DateTime.FromOADate(resdouble) : (DateTime?)null;
                                DateTime? toDate = double.TryParse(f.EndDate, out resdouble) ? DateTime.FromOADate(resdouble) : (DateTime?)null;
                                if (fromDate == null || toDate == null || fromDate >= toDate)
                                {
                                    fromDate = null;
                                    toDate = null;
                                }

                                bool? multiple;
                                NewStudentPerGroup = new AppStudentPerGroupDTO()
                                {
                                    GroupId = group > 0 ? group : null,
                                    DateCreated = DateTime.Today,
                                    StudentId = _DictStudents.TryGetValue(f.Tz, out resInt) ? resInt : null,
                                    UserCreatedId = userId,
                                    FromDate = fromDate != null ? fromDate : (yearBook != null ? yearBook.FromDate : (DateTime?)null),
                                    ToDate = toDate != null ? toDate : (yearBook != null ? yearBook.ToDate : (DateTime?)null)
                                };

                                multiple = DictGroupMultiple.TryGetValue((int)NewStudentPerGroup.GroupId, out multiple) ? multiple : (bool?)null;
                                if (multiple != null)
                                {
                                    bool notMultiple = false;
                                    if (!(bool)multiple)
                                        notMultiple = _StudentPerGroupRepository.CheckIfCanAddUserPerGroup(NewStudentPerGroup.StudentId, NewStudentPerGroup.GroupId, (DateTime)NewStudentPerGroup.FromDate, (DateTime)NewStudentPerGroup.ToDate);
                                    //אם לא קיים שיוך לתלמידה לקבוצה זו
                                    if (_lstStudentPerGroup.FirstOrDefault(x => x.GroupId == NewStudentPerGroup.GroupId && x.StudentId == NewStudentPerGroup.StudentId
                           /* &&  x.ToDate*/) == null
                            //אם לא הכניסו בהכנסה הנוכחית שיוך זה לתלמידה
                            && ListStudentPerGroup.FirstOrDefault(x => x.GroupId == NewStudentPerGroup.GroupId && x.StudentId == NewStudentPerGroup.StudentId) == null
                            //וגם זה  קבוצה מסוג שניתן להיות משוייכים אליה מספר פעמים 
                            && ((bool)multiple
                            //או שזה כן קבוצה שניתן להיות משוייכים פעם אחת ועדיין אין לה שיוך לסוג קבוצה זו
                            || notMultiple))

                                        if (NewStudentPerGroup.StudentId != null && NewStudentPerGroup.GroupId != null && NewStudentPerGroup.FromDate != null && NewStudentPerGroup.ToDate != null)
                                            ListStudentPerGroup.Add(NewStudentPerGroup);
                                        else
                                            Error.Add(f);
                                }
                                else
                                    Error.Add(f);
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        Error.Add(f);
                    }

                });
                if (Error.Count > 0)
                {
                    String body =
                        "<h3>" + "השיוכים הבאים לא הועלו כיוון שהיתה בהם תקלה." + "<br>" +
                        "</h3>"
                            + "<table  border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 600 + ">" +
                     "<tr bgcolor='#4da6ff'>"
                     + "<th>" + "מספר זיהוי" + "</th>"
                     + "<th>" + "קבוצה" + "</th>"
                     + "<th>" + "תאריך התחלה" + "</th>"
                     + "<th>" + "תאריך סיום" + "</th>"

                    + "</tr>";
                    var i = 0;
                    Error.ForEach(e =>
                    {
                        if (i % 2 == 0)
                            body += "<tr>";
                        else
                            body += "<tr bgcolor='#4da6ff'>";
                        body += "<td>" + e.Tz + "</td>";
                        body += "<td>" + _GroupRepository.GetNameGroupByGroupid(int.TryParse(e.IdGroup, out resInt) ? resInt : 0) + "</td>";
                        body += "<td>" + (double.TryParse(e.StartDate, out resdouble) ? DateTime.FromOADate(resdouble) : "") + "</td>";
                        body += "<td>" + (double.TryParse(e.EndDate, out resdouble) ? DateTime.FromOADate(resdouble) : "") + "</td>";
                        body += "</tr>";
                        i++;
                    }
                        );


                    body += "</table>";
                    string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                    if (contact_email == null)
                        contact_email = "ravcevel@gmail.com";
                    new MailService().SendEmail(contact_email, "שגיאה בהעלאת שיוך תלמיד קבוצה מאקסל במוסד " + (_AppSchoolDTO != null && _AppSchoolDTO.Name != null ? _AppSchoolDTO.Name : ' '), body);
                    new MailService().SendEmail("more21service@gmail.com", "שגיאה בהעלאת שיוך תלמיד קבוצה מאקסל במוסד " + (_AppSchoolDTO != null && _AppSchoolDTO.Name != null ? _AppSchoolDTO.Name : ' '), body);

                }
                if (ListStudentPerGroup != null && ListStudentPerGroup.Count > 0)
                {
                    var lst = _mapper.Map<List<AppStudentPerGroup>>(ListStudentPerGroup);
                    return _StudentPerGroupRepository.AddLstStudentPerGRoup(lst);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        //העלאת מערכת קבועה מאקסל
        private bool ReadScheduleRegular(int schoolId, int userId, string path, string nameTab, DateTime StartDate, DateTime EndDate, bool IsNew = false, bool IsOverride = false)
        {
            try
            {

                string body1 = "<h3>" + "המערכות הבאות לא הועלו כיוון שהיתה בהם תקלה." + "<br>" +
                            "</h3>" + "<br>" + "<br>";
                body1 += "<table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 600 + ">";
                body1 += "<tr bgcolor='#4da6ff'>";
                body1 += "<th>" + "קוד קורס" + "</th>";
                body1 += "<th>" + "יום בשבוע" + "</th>";
                body1 += "<th>" + "מספר שיעור" + "</th>";
                body1 += "</tr>";


                string str = ReadExcel(path, nameTab);
                List<AppScheduleRegularXL> ScheduleRegular = JsonConvert.DeserializeObject<List<AppScheduleRegularXL>>(str);
                ScheduleRegular = ScheduleRegular.Where(w => w.IDCourse != "" && w.IDCourse != null).ToList();

                int resInt;
                //double resdouble;
                short resShort;
                bool IsSuccedd;
                AppScheduleRegular AppScheduleRegular;
                AppGroupPerYearbook appGroup;
                AppGroupPerYearbook appGroupToTry;

                List<AppScheduleRegular> NewSchedules = new List<AppScheduleRegular>();
                List<AppScheduleRegular> SchedulesToDelete = new List<AppScheduleRegular>();
                List<AppScheduleRegular> SchedulesMultiple = new List<AppScheduleRegular>();
                List<AppScheduleRegularXL> InvalidSchedules = new List<AppScheduleRegularXL>();
                List<AppScheduleRegular> SchedulesRegularExsist = new List<AppScheduleRegular>();
                //  List<AppDailySchedule> DailyScheduleExsist = new List<AppDailySchedule>();
                List<AppDailySchedule> DailyScheduleOld = new List<AppDailySchedule>();
                List<AppDailySchedule> DailyScheduleOldOfGroup = new List<AppDailySchedule>();
                List<AppScheduleRegular> ListScheduleRegularWithPresence = new List<AppScheduleRegular>();
                //דיקט לשמירה לכל קבוצה פר שנתון את המערכות הקבועות הקיימות
                Dictionary<int, List<AppScheduleRegular>> DictLstScheduleRegularByGroup = new Dictionary<int, List<AppScheduleRegular>>();
                //דיקט לשמירה לכל קורס את הקבוצה פר שנתון אליה הוא שייך
                Dictionary<int?, AppGroupPerYearbook> DictGroupByCourseId = new Dictionary<int?, AppGroupPerYearbook>();

                if (StartDate == null || EndDate == null || StartDate >= EndDate)
                {
                    //אמורה להיות בדיקה גם באנגולר
                    return false;
                }

                if (IsNew)
                {
                    //עצירת המערכת הקבועה של כלל המוסד
                    DailyScheduleOld = _ScheduleRegularRepository.StopTheScheduleRegularForTheWholeSchool(schoolId, StartDate, EndDate, userId);
                    if (DailyScheduleOld == null)
                        DailyScheduleOld = new List<AppDailySchedule>();
                }

                foreach (var s in ScheduleRegular)
                {
                    try
                    {
                        AppScheduleRegular = new AppScheduleRegular()
                        {
                            CourseId = int.TryParse(s.IDCourse, out resInt) ? resInt : (int?)null,
                            SchoolId = schoolId,
                            StartDate = StartDate,//double.TryParse(s.StartDate, out resdouble) ? DateTime.FromOADate(resdouble) : (DateTime?)null,
                            EndDate = EndDate,//double.TryParse(s.EndDate, out resdouble) ? DateTime.FromOADate(resdouble) : (DateTime?)null,
                            DateCreated = DateTime.Today,
                            UserCreatedId = userId,
                            //קורה בהמשך כיוון שעדיין אין לנו פה את הקבוצה...
                            // LessonPerGroupId = _LessonPerGroupRepository.LessonPerGroupByGroupIdAndDayOfWeekAndNumLesson();
                            //LessonPerGroup = new AppLessonPerGroup()
                            //{
                            //    DayOfWeek = short.TryParse(s.DayOfWeek, out resShort) ? resShort : (short?)null,
                            //    NumLesson = short.TryParse(s.NumLesson, out resShort) ? resShort : (short?)null
                            //}
                        };

                        appGroup = null;
                        //שליפת הקבוצה לפי הקורס ממילון של קורס פר קבוצה - שאם יש כמה מערכות לקורס הזה שלא יצטרך לשלוף כל פעם מחדש
                        DictGroupByCourseId.TryGetValue(AppScheduleRegular.CourseId, out appGroup);
                        if (appGroup == null)
                        {
                            //שליפת הקבוצה לפי הקורס
                            appGroup = _GroupRepository.GetGroupByCourseID((int)AppScheduleRegular.CourseId);
                            //לא קיים לקורס קבוצה 
                            if (appGroup == null)
                            {
                                InvalidSchedules.Add(s);
                                continue;
                            }
                            DictGroupByCourseId.Add(AppScheduleRegular.CourseId, appGroup);
                        }

                        //שליפת של השיעור פר קבוצה התואם
                        short? DayOfWeek = short.TryParse(s.DayOfWeek, out resShort) ? resShort : (short?)null;
                        short? NumLesson = short.TryParse(s.NumLesson, out resShort) ? resShort : (short?)null;
                        if (DayOfWeek == 0 || DayOfWeek == null || NumLesson == null || NumLesson == 0)
                        {
                            InvalidSchedules.Add(s);
                            continue;
                        }

                        AppLessonPerGroup LessonPerGroup = _LessonPerGroupRepository.LessonPerGroupByGroupIdAndDayOfWeekAndNumLesson(DayOfWeek, NumLesson, appGroup.IdgroupPerYearbook);
                        if (LessonPerGroup == null || LessonPerGroup.IdlessonPerGroup == 0)
                        {
                            InvalidSchedules.Add(s);
                            continue;
                        }

                        AppScheduleRegular.LessonPerGroupId = LessonPerGroup.IdlessonPerGroup;
                        AppScheduleRegular.LessonPerGroup = LessonPerGroup;

                        // בדיקה אם באקסל הנוכחי שמועלה כעת יש מערכות חופפות
                        SchedulesRegularExsist = NewSchedules.Where(w =>
                        //באותה קבוצה
                        (w.CourseId == AppScheduleRegular.CourseId ||
                        (DictGroupByCourseId.TryGetValue(w.CourseId, out appGroupToTry) == true && appGroup.IdgroupPerYearbook == appGroupToTry.IdgroupPerYearbook))
                        //באותם תאריכים
                        && w.StartDate <= AppScheduleRegular.EndDate && w.EndDate >= AppScheduleRegular.StartDate
                        && w.LessonPerGroup.DayOfWeek == AppScheduleRegular.LessonPerGroup.DayOfWeek &&
                        //בשעות חופפות
                        w.LessonPerGroup.StartTime < AppScheduleRegular.LessonPerGroup.EndTime &&
                        w.LessonPerGroup.EndTime > AppScheduleRegular.LessonPerGroup.StartTime).ToList();

                        //יש חופף בחדש שניסו להוסיף עכשיו
                        if (SchedulesRegularExsist != null && SchedulesRegularExsist.Count > 0)
                        {
                            InvalidSchedules.Add(s);
                            continue;
                        }


                        // מערכת חדשה  
                        if (IsNew == true)
                        {

                            {
                                //!!!!!!!!!!!!!!!!!!! כרגע לא נעשה
                                //בדיקה אם המורה לא משובצת לקבוצה כלשהיא
                                //bool ValidTeacher= _ScheduleRegularRepository.isValidTeacher(AppScheduleRegular.CourseId, AppScheduleRegular.StartDate, 
                                //AppScheduleRegular.EndDate, AppScheduleRegular.LessonPerGroupId);

                                //שליפה של הליסט של המערכות היומיות  החופפות של הקבוצה
                                DailyScheduleOldOfGroup = DailyScheduleOld.Where(w => (Convert.ToInt32(w.ScheduleDate.Value.DayOfWeek) + 1) == LessonPerGroup.DayOfWeek &&
                                 w.StartTime < LessonPerGroup.EndTime &&
                                 w.EndTime > LessonPerGroup.StartTime &&
                                w.Course != null && w.Course.GroupId == appGroup.IdgroupPerYearbook).ToList();

                                DailyScheduleOld = DailyScheduleOld.Except(DailyScheduleOldOfGroup).ToList();
                                IsSuccedd = _ScheduleRegularRepository.AddScheduleRegular(AppScheduleRegular, DailyScheduleOldOfGroup);
                                
                                if (IsSuccedd)
                                {
                                    NewSchedules.Add(AppScheduleRegular);
                                    //מחיקת הליסט שענה על התנאי מהליסט הראשון
                                }
                                else
                                    InvalidSchedules.Add(s);

                            }

                            #region
                            ////שליפת המערכות הקבועות הקיימות לקבוצה ממילון של מערכות לקבוצה - שאם יש כמה מערכות לקורס הזה שלא יצטרך לשלוף כל פעם מחדש
                            //DictLstScheduleRegularByGroup.TryGetValue(appGroup.IdgroupPerYearbook, out SchedulesRegularExsist);
                            ////אם טרם נשלפו המערכות המקבילות לקבוצה זו 
                            //if (SchedulesRegularExsist == null)
                            //{
                            //    //שליפת המערכת הקבועה לקבוצה פר שנתון בתאריכים חופפים 
                            //    SchedulesRegularExsist = _ScheduleRegularRepository.GetScheduleRegularBetwwnDatesOfGroup(appGroup.IdgroupPerYearbook, StartDate, EndDate);
                            //    DictLstScheduleRegularByGroup.Add(appGroup.IdgroupPerYearbook, SchedulesRegularExsist);
                            //}
                            ////אין מערכות ישנות לקבוצה בתאריכים המבוקשים
                            //if (SchedulesRegularExsist == null)
                            //{
                            //    //בדיקה אם באקסל הנוכחי שמועלה כעת יש מערכות חופפות
                            //    SchedulesRegularExsist = NewSchedules.Where(w =>
                            //    //באותה קבוצה
                            //    (w.CourseId == AppScheduleRegular.CourseId ||
                            //    (DictGroupByCourseId.TryGetValue(w.CourseId, out appGroupToTry) == true && appGroup.IdgroupPerYearbook == appGroupToTry.IdgroupPerYearbook))
                            //    //באותם תאריכים
                            //    && w.StartDate <= AppScheduleRegular.EndDate && w.EndDate >= AppScheduleRegular.StartDate
                            //    && w.LessonPerGroup.DayOfWeek == AppScheduleRegular.LessonPerGroup.DayOfWeek &&
                            //    //בשעות חופפות
                            //    w.LessonPerGroup.StartTime <= AppScheduleRegular.LessonPerGroup.EndTime &&
                            //    w.LessonPerGroup.EndTime >= AppScheduleRegular.LessonPerGroup.StartTime).ToList();

                            //    //אין חופף לא בישן ולא בחדש שניסו להוסיף עכשיו
                            //    if (SchedulesRegularExsist == null)
                            //    {
                            //        //!!!!!!!!!!!!!!!!!!! כרעג לא נעשה
                            //        //בדיקה אם המורה לא משובצת לקבוצה כלשהיא
                            //        //bool ValidTeacher= _ScheduleRegularRepository.isValidTeacher(AppScheduleRegular.CourseId, AppScheduleRegular.StartDate, 
                            //        //    AppScheduleRegular.EndDate, AppScheduleRegular.LessonPerGroupId);

                            //        NewSchedules.Add(AppScheduleRegular);
                            //        _ScheduleRegularRepository.openDailyScheduleToNewRegularSchedule(AppScheduleRegular);


                            //    }
                            //    //יש חופף בחדשים שניסו להכניס בהכנסה הנוכחית
                            //    else
                            //    {
                            //        InvalidSchedules.Add(AppScheduleRegular);
                            //    }
                            //}
                            ////קיימות מערכות ישנות חופפות
                            //else
                            //{
                            //    SchedulesRegularExsist.ForEach(sched =>
                            //    {


                            //    });

                            //    //בדיקה אם באקסל הנוכחי יש מערכות חופפות
                            //    SchedulesRegularExsist = NewSchedules.Where(w =>
                            //    //באותה קבוצה
                            //    (w.CourseId == AppScheduleRegular.CourseId ||
                            //    (DictGroupByCourseId.TryGetValue(w.CourseId, out appGroupToTry) == true && appGroup.IdgroupPerYearbook != appGroupToTry.IdgroupPerYearbook))
                            //    //באותם תאריכים
                            //    && w.StartDate <= AppScheduleRegular.EndDate && w.EndDate >= AppScheduleRegular.StartDate
                            //    && w.LessonPerGroup.DayOfWeek == AppScheduleRegular.LessonPerGroup.DayOfWeek &&
                            //    //בשעות חופפות
                            //    w.LessonPerGroup.StartTime <= AppScheduleRegular.LessonPerGroup.EndTime &&
                            //    w.LessonPerGroup.EndTime >= AppScheduleRegular.LessonPerGroup.StartTime).ToList();
                            //}
                            #endregion
                        }
                        //עידכון מערכת
                        else
                        {

                            {
                                //!!!!!!!!!!!!!!!!!!! כרגע לא נעשה
                                //בדיקה אם המורה לא משובצת לקבוצה כלשהיא
                                //bool ValidTeacher= _ScheduleRegularRepository.isValidTeacher(AppScheduleRegular.CourseId, AppScheduleRegular.StartDate, 
                                //AppScheduleRegular.EndDate, AppScheduleRegular.LessonPerGroupId);


                                //עידכון מערכת קבועה
                                IsSuccedd = _ScheduleRegularRepository.UpdateScheduleRegular(AppScheduleRegular, appGroup.IdgroupPerYearbook, userId, IsOverride);
                                if (IsSuccedd)
                                {
                                    NewSchedules.Add(AppScheduleRegular);
                                }
                                else
                                    InvalidSchedules.Add(s);

                            }

                            #region
                            //appGroup = _GroupRepository.GetGroupByCourseID((int)AppScheduleRegular.CourseId);
                            //DictGroupByCourseId.Add(AppScheduleRegular.CourseId, appGroup);
                            //if (appGroup != null && appGroup.IdgroupPerYearbook != null && appGroup.IdgroupPerYearbook > 0)
                            //{
                            //    //שליפה של כל המערכות הקבועות הקיימות לקבוצה זה בתאריכים חופפים
                            //    //  SchedulesRegularExsist = _ScheduleRegularRepository.GetScheduleRegularBetwwnDatesOfGroup(appGroup.IdgroupPerYearbook, AppScheduleRegular.StartDate, AppScheduleRegular.EndDate, AppScheduleRegular.DayInWeek, AppScheduleRegular.NumLesson);
                            //    // קיים חופפים
                            //    if (SchedulesRegularExsist != null && SchedulesRegularExsist.Count > 0)
                            //    {
                            //        //אם ביקשו לדרוס את הישנים
                            //        if (IsOverride == true)
                            //        {
                            //            //אם טרם נשלפו המערכות המקבילות לקבוצה זו 
                            //            if (SchedulesRegularExsist == null)
                            //            {
                            //                //שליפת המערכת הקבועה לקבוצה פר שנתון בתאריכים מקבילים 
                            //                SchedulesRegularExsist = _ScheduleRegularRepository.GetScheduleRegularBetwwnDatesOfGroup(appGroup.IdgroupPerYearbook, StartDate, EndDate);
                            //                DictLstScheduleRegularByGroup.Add(appGroup.IdgroupPerYearbook, SchedulesRegularExsist);
                            //            }
                            //            //אין מערכות ישנות חופפות
                            //            if (SchedulesRegularExsist == null)
                            //            {
                            //                //בדיקה אם באקסל הנוכחי יש מערכות חופפות
                            //                SchedulesRegularExsist = NewSchedules.Where(w =>
                            //                   ((w.Course != null && w.Course.GroupId == appGroup.IdgroupPerYearbook) || w.CourseId == AppScheduleRegular.CourseId) &&
                            //                  (w.StartDate <= AppScheduleRegular.StartDate && w.EndDate >= AppScheduleRegular.EndDate)).ToList();
                            //                //אין חופפות
                            //                if (SchedulesRegularExsist == null)
                            //                {
                            //                    NewSchedules.Add(AppScheduleRegular);
                            //                    //פתיחת מערכת יומית
                            //                    // openDailyScheduleToNewRegularSchedule(AppScheduleRegular);
                            //                }
                            //                //יש חופפות
                            //                else
                            //                {
                            //                    SchedulesMultiple.Add(AppScheduleRegular);
                            //                }
                            //            }
                            //            //קיימות מערכות ישנות חופפות
                            //            else
                            //            {

                            //            }

                            //            SchedulesRegularExsist.ForEach(fo =>
                            //            {
                            //                MaxDailyScheduleWithPresence = null;
                            //                MinDailyScheduleWithPresence = null;
                            //                //אם קיים מערכת יומית
                            //                if (fo.AppDailySchedules != null)
                            //                {
                            //                    var x = fo.AppDailySchedules.OrderByDescending(o => o.ScheduleDate);
                            //                    //התאריך האחרון בו יש נוכחות
                            //                    MaxDailyScheduleWithPresence = x.FirstOrDefault(fir => fir.AppPresences != null && fir.AppPresences.Count > 0);
                            //                    //התאריך הראשון בו יש נוכחות
                            //                    MinDailyScheduleWithPresence = x.LastOrDefault(fir => fir.AppPresences != null && fir.AppPresences.Count > 0);
                            //                }

                            //                // לא קיימת למערכת נוכחות => מחיקת המערכת הקבועה והיומית
                            //                if (MaxDailyScheduleWithPresence == null)
                            //                {
                            //                    SchedulesToDelete.Add(fo);
                            //                    //delete it
                            //                    NewSchedules.Add(AppScheduleRegular);
                            //                }
                            //                else
                            //                {
                            //                    //fo - old
                            //                    //AppScheduleRegular - new

                            //                    // if (fo.StartDate >= AppScheduleRegular.StartDate && fo.EndDate >= AppScheduleRegular.EndDate) //exm': fo-14-22, AppScheduleRegular-10-19


                            //                }
                            //            });
                            //        }
                            //        //אם אמרו לא לדרוס
                            //        else
                            //        {

                            //        }

                            //        SchedulesRegularExsist.ForEach(sched =>
                            //        {

                            //            // sched.EndDate = AppScheduleRegular.StartDate.Value.AddDays(-1);



                            //        });

                            //    }
                            //    //הוספה
                            //    else
                            //    {
                            //        NewSchedules.Add(AppScheduleRegular);

                            //    }
                            //    //DailyScheduleExsist =  _DailyScheduleRepository.GetDailyScheduleBetwwnDatesOfCourse(AppScheduleRegular.CourseId, AppScheduleRegular.StartDate, AppScheduleRegular.EndDate);
                            //}
                            #endregion
                        }
                    }
                    catch (Exception e)
                    {
                        InvalidSchedules.Add(s);
                    }

                }
                //אם העלו מערכת חדשה ולא לכל היומי שהתקיים העלו מערכת חדשה -> ניתוק מהמערכת הקבועה
                if (DailyScheduleOld != null && DailyScheduleOld.Count > 0)
                {
                    _DailyScheduleRepository.SetScheduleRegularIdNull(DailyScheduleOld);
                }
                //Task t = Task.Run(async () =>
                //{
                if (InvalidSchedules != null && InvalidSchedules.Count > 0)
                {
                    int i = 0;
                    InvalidSchedules.ForEach(e =>
                    {
                        if (i % 2 == 0)
                            body1 += "<tr>";
                        else
                            body1 += "<tr bgcolor='#4da6ff'>";
                        body1 += "<td>" + e.IDCourse + "</td>";
                        body1 += "<td>" + e.DayOfWeek + "</td>";
                        body1 += "<td>" + e.NumLesson + "</td>";
                        body1 += "</tr>";
                        i++;
                    }
                    );


                    body1 += "</table>";
                    string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                    if (contact_email == null)
                        contact_email = "ravcevel@gmail.com";
                    new MailService().SendEmail(contact_email, "שגיאה בהעלאת מערכת קבועה מאקסל", body1);
                    new MailService().SendEmail("more21service@gmail.com", "שגיאה בהעלאת מערכת קבועה מאקסל", body1);

                }

                // });

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        //העלאת משתמשים מאקסל
        private bool ReadUsers(int schoolId, int userId, string path, string nameTab, int idyearbookPerSchool)
        {
            try
            {

                bool isValid = true;
                bool flag = false;
                string body1 = "<h3>" + "הרשומות הבאות הן רשומות שכבר היו קיימות במסד נתונים והועלו שוב עם נתונים לא תואמים." + "<br>" +
                        "שימו לב כי הנתונים עודכנו." + "<br>" +
                        "</h3>"
                #region
                        + "<h4>בכל זוג שורות השורה הלבנה הם הנתונים הישנים והכחול הם הנתונים החדשים והמעודכנים</h4>";
                body1 += "<table  border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 600 + ">";
                body1 += "<tr bgcolor='#4da6ff'>";
                body1 += "<th>" + "מספר זיהוי" + "</th>";
                body1 += "<th>" + "סוג זיהוי" + "</th>";
                body1 += "<th>" + "פרטי" + "</th>";
                body1 += "<th>" + "משפחה" + "</th>";
                body1 += "<th>" + "תאריך לידה לועזי" + "</th>";
                body1 += "<th>" + "תאריך עברי" + "</th>";
                body1 += "<th>" + "ארץ לידה" + "</th>";
                body1 += "<th>" + "אזרחות" + "</th>";
                body1 += "<th>" + "תאריך עליה" + "</th>";
                body1 += "<th>" + "ארץ עליה" + "</th>";
                body1 += "<th>" + "מין" + "</th>";
                body1 += "<th>" + "פרטי בלועזית" + "</th>";
                body1 += "<th>" + "משפחה בלועזית" + "</th>";
                body1 += "<th>" + "שם משפחה קודם" + "</th>";
                body1 += "<th>" + "פעיל" + "</th>";
                body1 += "<th>" + "עיר" + "</th>";
                body1 += "<th>" + "רחוב" + "</th>";
                body1 += "<th>" + "בנין" + "</th>";
                body1 += "<th>" + "דירה" + "</th>";
                body1 += "<th>" + "ת.ד." + "</th>";
                body1 += "<th>" + "מיקוד" + "</th>";
                body1 += "<th>" + "מייל" + "</th>";
                body1 += "<th>" + "פקס" + "</th>";
                body1 += "<th>" + "נייד 1" + "</th>";
                body1 += "<th>" + "נייד 2" + "</th>";
                body1 += "<th>" + "נייד 3" + "</th>";
                body1 += "<th>" + "טלפון 1" + "</th>";
                body1 += "<th>" + "טלפון 2" + "</th>";
                body1 += "<th>" + "הערה" + "</th>";
                body1 += "</tr>";
                #endregion

                List<AppUserPerSchoolWithDetailsDTO> TzInvalid = new List<AppUserPerSchoolWithDetailsDTO>();
                List<AppUserPerSchoolWithDetailsDTO> TzExists = new List<AppUserPerSchoolWithDetailsDTO>();
                List<AppUserPerSchoolWithDetailsDTO> LisUsers = new List<AppUserPerSchoolWithDetailsDTO>();
                List<AppUserPerSchoolWithDetailsDTO> Error = new List<AppUserPerSchoolWithDetailsDTO>();

                AppUserPerSchoolWithDetailsDTO user = new AppUserPerSchoolWithDetailsDTO();
                string str = ReadExcel(path, nameTab);

                List<AppUserXL> Users = JsonConvert.DeserializeObject<List<AppUserXL>>(str);
                Users = Users.Where(w => w.Tz != "" && w.Tz != null).ToList();

                int result;
                short result2;
                double result3;
                bool result5;
                //new MailService().SendEmail("sariw1292@gmail.com", "תחילת הפונקציה", "");

                AppUserPerSchoolWithDetailsDTO newUser;
                Users.ForEach(s =>
                {
                    try
                    {
                        #region עדכון נתוני משתמש
                        //!!!!!!!!!!!??????????????????????????!!!!!!!!!!AppUniqueCode
                        newUser = new AppUserPerSchoolWithDetailsDTO();
                        newUser.FirstName = s.FirstName;
                        newUser.LastName = s.LastName;
                        newUser.GenderId = short.TryParse(s.Gender, out result2) ? result2 : (short?)null;
                        newUser.ForeignLastName = s.ForeignLastName;
                        newUser.ForeignFirstName = s.ForeignFirstName;
                        newUser.PreviusName = s.PreviusName;
                        newUser.Note = s.Note;
                        newUser.IsActive = bool.TryParse(s.IsActive, out result5) ? result5 : true;
                        newUser.UserCreatedId = userId;
                        newUser.DateCreated = DateTime.Today;
                        newUser.SchoolId = schoolId;

                        newUser.User = new SecUserDTO();
                        newUser.User.Tz = s.Tz;
                        newUser.User.TypeIdentityId = int.TryParse(s.TypeIdentity, out result) ? result : (int?)null;

                        newUser.Address = new AppAddressDTO();
                        newUser.Address.ApartmentNumber = s.HouseNum;
                        newUser.Address.CityId = int.TryParse(s.City, out result) ? result : (int?)null;
                        newUser.Address.DateCreated = DateTime.Today;
                        newUser.Address.HouseNumber = s.BuildingNum;
                        newUser.Address.PoBox = int.TryParse(s.MailBox, out result) ? result : (int?)null;
                        newUser.Address.StreetId = int.TryParse(s.Street, out result) ? result : (int?)null;
                        newUser.Address.UserCreatedId = userId;
                        newUser.Address.ZipCode = int.TryParse(s.Zip, out result) ? result : (int?)null;

                        newUser.Birth = new AppBirthDTO();
                        newUser.Birth.BirthCountryId = int.TryParse(s.BirthCountryId, out result) ? result : (int?)null;
                        newUser.Birth.BirthDate = s.BirthDate != null ? (double.TryParse(s.BirthDate, out result3) ? DateTime.FromOADate(result3) : (DateTime?)null) : (DateTime?)null;
                        newUser.Birth.BirthHebrewDate = s.BirthHebrewDate;
                        newUser.Birth.CitizenshipId = int.TryParse(s.Citizenship, out result) ? result : (int?)null;
                        newUser.Birth.CountryIdofImmigration = int.TryParse(s.CountryIdofImmigration, out result) ? result : (int?)null;
                        newUser.Birth.DateCreated = DateTime.Today;
                        newUser.Birth.DateOfImmigration = s.DateOfImmigration != null ? (double.TryParse(s.DateOfImmigration, out result3) ? DateTime.FromOADate(result3) : (DateTime?)null) : (DateTime?)null;
                        newUser.Birth.UserCreatedId = userId;

                        newUser.ContactInformation = new AppContactInformationDTO();
                        newUser.ContactInformation.DateCreated = DateTime.Today;
                        newUser.ContactInformation.Email = s.Mail;
                        newUser.ContactInformation.FaxNumber = s.Fax;
                        newUser.ContactInformation.PhoneNumber1 = s.Mobile1;
                        newUser.ContactInformation.PhoneNumber2 = s.Mobile2;
                        newUser.ContactInformation.PhoneNumber3 = s.Mobile3;
                        newUser.ContactInformation.TelephoneNumber1 = s.Telehone1;
                        newUser.ContactInformation.TelephoneNumber2 = s.Telehone2;
                        newUser.ContactInformation.UserCreatedId = userId;

                        #endregion 

                        if (newUser.User.TypeIdentityId == 2)
                            isValid = _checkTZRepository.CheckTZ(s.Tz);
                        if (!isValid)
                        {
                            TzInvalid.Add(newUser);
                            isValid = true;
                        }
                        else
                        {
                            {
                                SecUser userexsist = new SecUser();
                                try
                                {
                                    //בדיקה אם המשתמש קיים בDB
                                    userexsist = _UserRepository.IsUserExsist(newUser.User.Tz, schoolId);
                                    if (userexsist != null)
                                        user = _mapper.Map<AppUserPerSchoolWithDetailsDTO>(userexsist);
                                    else
                                        user = null;

                                }
                                catch (Exception ex)
                                {
                                    new MailService().SendEmail("sariw1292@gmail.com", "שגיאה 1", "");


                                    throw;
                                }
                                //המשתמש נמצא בטבלת משתמשים
                                if (user != null && user.UserId != null && user.UserId > 0)
                                {
                                    //new MailService().SendEmail("sariw1292@gmail.com", "קיים", "");

                                    //אם המשתמש קיים כבר במוסד
                                    if (user.SchoolId == schoolId)
                                    {
                                        //AppUserPerSchool userPerSchool  = userexsist.AppUserPerSchools.FirstOrDefault(fi => fi.SchoolId == schoolId);

                                        //אם הכניסו נתונים שונים ממה שנמצא כבר בDB
                                        if (
                                                 user.User.TypeIdentityId != newUser.User.TypeIdentityId ||
                                                 user.FirstName != newUser.FirstName ||
                                                 user.LastName != newUser.LastName ||
                                                 user.GenderId != newUser.GenderId ||
                                                 user.ForeignLastName != newUser.ForeignLastName ||
                                                 user.ForeignFirstName != newUser.ForeignFirstName ||
                                                 user.PreviusName != newUser.PreviusName ||
                                                 user.Note != newUser.Note ||
                                                 user.IsActive != newUser.IsActive ||
                                                 user.Address.CityId != newUser.Address.CityId ||
                                                 user.Address.HouseNumber != newUser.Address.HouseNumber ||
                                                 user.Address.ApartmentNumber != newUser.Address.ApartmentNumber ||
                                                 user.Address.PoBox != newUser.Address.PoBox ||
                                                 user.Address.StreetId != newUser.Address.StreetId ||
                                                 user.Address.ZipCode != newUser.Address.ZipCode ||
                                                 user.Birth.BirthCountryId != newUser.Birth.BirthCountryId ||
                                                 user.Birth.CountryIdofImmigration != newUser.Birth.CountryIdofImmigration ||
                                                 user.Birth.BirthHebrewDate != newUser.Birth.BirthHebrewDate ||
                                                 user.Birth.CitizenshipId != newUser.Birth.CitizenshipId ||
                                                 user.Birth.BirthDate != newUser.Birth.BirthDate ||
                                                 user.Birth.DateOfImmigration != newUser.Birth.DateOfImmigration ||
                                                 user.Birth.DateOfImmigration != newUser.Birth.DateOfImmigration ||
                                                 user.ContactInformation.Email != newUser.ContactInformation.Email ||
                                                 user.ContactInformation.FaxNumber != newUser.ContactInformation.FaxNumber ||
                                                 user.ContactInformation.PhoneNumber1 != newUser.ContactInformation.PhoneNumber1 ||
                                                 user.ContactInformation.PhoneNumber2 != newUser.ContactInformation.PhoneNumber2 ||
                                                 user.ContactInformation.PhoneNumber3 != newUser.ContactInformation.PhoneNumber3 ||
                                                 user.ContactInformation.TelephoneNumber1 != newUser.ContactInformation.TelephoneNumber1 ||
                                                 user.ContactInformation.TelephoneNumber2 != newUser.ContactInformation.TelephoneNumber2

                                              )
                                        {

                                            TzExists.Add(user);
                                            TzExists.Add(newUser);

                                            flag = true;
                                            if (TzExists != null && TzExists.Count() > 0)
                                            {
                                                var i = 0;

                                                foreach (var item in TzExists)
                                                {

                                                    if (i % 2 == 0)
                                                        body1 += "<tr>";
                                                    else
                                                        body1 += "<tr bgcolor='#4da6ff'>";

                                                    body1 += "<td>" + item.User.Tz + "</td>";
                                                    body1 += "<td>" + item.User.TypeIdentityId + "</td>";
                                                    body1 += "<td>" + item.FirstName + "</td>";
                                                    body1 += "<td>" + item.LastName + "</td>";
                                                    body1 += "<td>" + item.Birth.BirthDate + "</td>" /*+ "/" + conv.Month + "/" + conv.Year */ ;
                                                    body1 += "<td>" + item.Birth.BirthHebrewDate + "</td>";
                                                    body1 += "<td>" + item.Birth.BirthCountryId + "</td>";
                                                    body1 += "<td>" + item.Birth.CitizenshipId + "</td>";
                                                    body1 += "<td>" + item.Birth.DateOfImmigration + "</td>";
                                                    body1 += "<td>" + item.Birth.CountryIdofImmigration + "</td>";
                                                    body1 += "<td>" + item.GenderId + "</td>";
                                                    body1 += "<td>" + item.ForeignFirstName + "</td>";
                                                    body1 += "<td>" + item.ForeignLastName + "</td>";
                                                    body1 += "<td>" + item.PreviusName + "</td>";
                                                    body1 += "<td>" + item.IsActive + "</td>";
                                                    body1 += "<td>" + item.Address.CityId + "</td>";
                                                    body1 += "<td>" + item.Address.StreetId + "</td>";
                                                    body1 += "<td>" + item.Address.HouseNumber + "</td>";
                                                    body1 += "<td>" + item.Address.ApartmentNumber + "</td>";
                                                    body1 += "<td>" + item.Address.PoBox + "</td>";
                                                    body1 += "<td>" + item.Address.ZipCode + "</td>";
                                                    body1 += "<td>" + item.ContactInformation.Email + "</td>";
                                                    body1 += "<td>" + item.ContactInformation.FaxNumber + "</td>";
                                                    body1 += "<td>" + item.ContactInformation.PhoneNumber1 + "</td>";
                                                    body1 += "<td>" + item.ContactInformation.PhoneNumber2 + "</td>";
                                                    body1 += "<td>" + item.ContactInformation.PhoneNumber3 + "</td>";
                                                    body1 += "<td>" + item.ContactInformation.TelephoneNumber1 + "</td>";
                                                    body1 += "<td>" + item.ContactInformation.TelephoneNumber2 + "</td>";
                                                    body1 += "<td>" + item.Note + "</td>";
                                                    body1 += "</tr>";

                                                    i++;
                                                }

                                                TzExists = new List<AppUserPerSchoolWithDetailsDTO>();
                                            }

                                            AppUserPerSchool appUser = _mapper.Map<AppUserPerSchool>(newUser);
                                            _UserRepository.UpdateUser(appUser, userId, user.IduserPerSchool, true);
                                            _UserRepository.AddUser(appUser, userId, schoolId, idyearbookPerSchool);

                                        }
                                    }
                                    //הוספה של היוזר למוסד הנוכחי
                                    else
                                    {
                                        AppUserPerSchool appUser = _mapper.Map<AppUserPerSchool>(newUser);
                                        _UserRepository.AddUser(appUser, userId, schoolId, idyearbookPerSchool);

                                    }
                                }
                                //אם משתמש עם תז זו לא קיים ב-DB
                                else
                                {
                                    //new MailService().SendEmail("sariw1292@gmail.com", "לא קיים", "");

                                    AppUserPerSchool appUser = _mapper.Map<AppUserPerSchool>(newUser);
                                    _UserRepository.AddUser(appUser, userId, schoolId, idyearbookPerSchool);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                        if (contact_email == null)
                            contact_email = "ravcevel@gmail.com";
                        //new MailService().SendEmail(contact_email, "שגיאה בהעלאת תלמיד מאקסל",s.Tz+"<br>" + "<br>" + ( e.InnerException != null ? e.InnerException.Message : e.Message));
                        new MailService().SendEmail("more21service@gmail.com", "שגיאה בהעלאת משתמש מאקסל במוסד " + (_AppSchoolDTO != null && _AppSchoolDTO.Name != null ? _AppSchoolDTO.Name : ' '), s.Tz + "<br>" + "<br>" + (e.InnerException != null ? e.InnerException.Message : e.Message));

                    }

                });

                //List<AppStudent> AppStudents = _mapper.Map<List<AppStudent>>(students);


                if (flag)
                {

                    body1 += "</table>";

                    string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                    if (contact_email == null)
                        contact_email = "ravcevel@gmail.com";

                    new MailService().SendEmail(contact_email, "תעודות זהות כפולות", body1);

                }

                if (TzInvalid != null && TzInvalid.Count() > 0)
                {
                    var body2 = "שלום להנהלה " + _AppSchoolDTO != null && _AppSchoolDTO.Name != null ? _AppSchoolDTO.Name : " ";

                    body2 += "<h3>" + "הרשומות הבאות הן רשומות שלא נשמרו כיוון שהועלו תעודות זהות לא תקינות." + "<br>" +
                       "</h3>" + "<br>";
                    body2 += "<table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 200 + ">";
                    body2 += "<tr bgcolor='#4da6ff'>";
                    body2 += "<th>" + "מספר זיהוי" + "</th>";
                    body2 += "</tr>";

                    var i = 0;


                    foreach (var item in TzInvalid)
                    {

                        if (i % 2 == 0)
                            body2 += "<tr>";
                        else
                            body2 += "<tr bgcolor='#4da6ff'>";

                        body2 += "<td>" + item.User.Tz + "</td>";
                        body2 += "</tr>";

                        i++;
                    }
                    body2 += "</table>";
                    string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                    if (contact_email == null)
                        contact_email = "ravcevel@gmail.com";

                    new MailService().SendEmail(contact_email, "תעודות זהות לא תקינות", body2);

                }

                return true;
                //return _StudentRepository.AddListStudents(AppStudents, schoolId);

            }
            catch (Exception e)
            {
                new MailService().SendEmail("sariw1292@gmail.com", "שגיאה", e.Message);

                Console.WriteLine(e);
                return false;
            }

        }

        //העלאת אנשי קשר מאקסל
        private bool ReadContactPerStudent(int schoolId, int userId, string path, string nameTab)
        {
            try
            {

                bool isValid = true;
                string body1 = "<h3>" + "הרשומות הבאות הן רשומות שלא הועלו כיוון שהיתה בהם תקלה." + "<br>" +
                        "</h3>";
                #region
                body1 += "<table  border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 600 + ">";
                body1 += "<tr bgcolor='#4da6ff'>";
                body1 += "<th>" + "מספר זיהוי תלמידה" + "</th>";
                body1 += "<th>" + "מספר זיהוי איש קשר" + "</th>";
                body1 += "<th>" + "פרטי איש קשר" + "</th>";
                body1 += "<th>" + "משפחה איש קשר" + "</th>";
                body1 += "</tr>";
                #endregion



                List<AppContactPerStudentXL> TzInvalid = new List<AppContactPerStudentXL>();


                string str = ReadExcel(path, nameTab);

                List<AppContactPerStudentXL> Contacts = JsonConvert.DeserializeObject<List<AppContactPerStudentXL>>(str);
                // Contacts = Contacts.Where(w => w.StudentTZ != "" && w.StudentTZ != null).ToList();

                int result;


                AppContactWithDetailsDTO newContact;
                Contacts.ForEach(con =>
                {
                    try
                    {
                        newContact = new AppContactWithDetailsDTO();

                        if (con.StudentTZ == null || con.StudentTZ == "" || con.ContactTZ == null || con.ContactTZ == "" || con.TypeContact == "" || con.TypeContact == null)
                        {
                            TzInvalid.Add(con);
                        }
                        else
                        {

                            AppStudent stu = _StudentRepository.IsStudentExsist(con.StudentTZ, schoolId);
                            //לא קיימת כזאת תלמידה במוסד
                            if (stu == null || stu.Idstudent == null || stu.Idstudent == 0)
                            {
                                TzInvalid.Add(con);
                            }


                            //זיהה את התלמידה
                            else
                            {
                                #region
                                newContact.StudentId = stu.Idstudent;
                                newContact.UserCreatedId = userId;
                                newContact.DateCreated = DateTime.Today;
                                newContact.TypeContactId = int.TryParse(con.TypeContact, out result) ? result : (int?)null;

                                newContact.Contact = new AppContactDTO();
                                newContact.Contact.FirstName = con.FirstName;
                                newContact.Contact.LastName = con.LastName;
                                newContact.Contact.UserCreatedId = userId;
                                newContact.Contact.DateCreated = DateTime.Today;
                                newContact.Contact.Tz = con.ContactTZ;
                                newContact.Contact.TypeIdentityId = int.TryParse(con.TypeIdentity, out result) ? result : (int?)null;
                                newContact.Contact.SchoolId = schoolId;

                                //בדיקת תקינות תז של האיש קשר
                                if (newContact.Contact.TypeIdentityId == 2)
                                    isValid = _checkTZRepository.CheckTZ(newContact.Contact.Tz);
                                if (!isValid)
                                {
                                    TzInvalid.Add(con);
                                }
                                //התז תקינה
                                else
                                {
                                    newContact.Contact.ContactInformation = new AppContactInformationDTO();
                                    newContact.Contact.ContactInformation.DateCreated = DateTime.Today;
                                    newContact.Contact.ContactInformation.Email = con.Mail;
                                    newContact.Contact.ContactInformation.FaxNumber = con.Fax;
                                    newContact.Contact.ContactInformation.PhoneNumber1 = con.Mobile1;
                                    newContact.Contact.ContactInformation.PhoneNumber2 = con.Mobile2;
                                    newContact.Contact.ContactInformation.PhoneNumber3 = con.Mobile3;
                                    newContact.Contact.ContactInformation.TelephoneNumber1 = con.Telehone1;
                                    newContact.Contact.ContactInformation.TelephoneNumber2 = con.Telehone2;
                                    newContact.Contact.ContactInformation.UserCreatedId = userId;
                                    newContact.Contact.ContactInformation.Job = con.Job;
                                    newContact.Contact.ContactInformation.Comment = con.Comment;

                                    newContact.Address = new AppAddressDTO();
                                    newContact.Address.ApartmentNumber = con.HouseNum;
                                    newContact.Address.CityId = int.TryParse(con.City, out result) ? result : (int?)null;
                                    newContact.Address.DateCreated = DateTime.Today;
                                    newContact.Address.HouseNumber = con.BuildingNum;
                                    newContact.Address.PoBox = int.TryParse(con.MailBox, out result) ? result : (int?)null;
                                    newContact.Address.StreetId = int.TryParse(con.Street, out result) ? result : (int?)null;
                                    newContact.Address.UserCreatedId = userId;
                                    newContact.Address.ZipCode = int.TryParse(con.Zip, out result) ? result : (int?)null;
                                    #endregion

                                    _ContactRepository.UpdateOrAddContactPerStudentFromXl(_mapper.Map<AppContactPerStudent>(newContact));
                                    //לכתוב באתר שאם יש איש קשר עם אותו מס זהות הנתונים ידרסו
                                }



                            }
                        }
                    }
                    catch (Exception e)
                    {
                        TzInvalid.Add(con);
                    }

                });

                if (TzInvalid != null && TzInvalid.Count() > 0)
                {


                    var i = 0;


                    foreach (var item in TzInvalid)
                    {

                        body1 += "<tr>";

                        body1 += "<td>" + item.StudentTZ + "</td>";
                        body1 += "<td>" + item.ContactTZ + "</td>";
                        body1 += "<td>" + item.FirstName + "</td>";
                        body1 += "<td>" + item.LastName + "</td>";
                        body1 += "</tr>";

                        i++;
                    }
                    body1 += "</table>";
                    string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                    if (contact_email == null)
                        contact_email = "ravcevel@gmail.com";

                    new MailService().SendEmail(contact_email, "רשומות אנשי קשר לא תקינות", body1);

                }
                return true;
            }


            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        //העלאת מקצועות מאקסל
        private bool ReadProfession(int schoolId, int userId, string path, string nameTab)
        {
            try
            {

                bool isValid = true;
                string body1 = "<h3>" + "הרשומות הבאות הן רשומות שלא הועלו כיוון שהיתה בהם תקלה." + "<br>" +
                        "</h3>";
                #region
                body1 += "<table  border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 600 + ">";
                body1 += "<tr bgcolor='#4da6ff'>";
                body1 += "<th>" + "שם מקצוע" + "</th>";
                body1 += "<th>" + "קטגוריה" + "</th>";
                body1 += "<th>" + "מ.ז. רכז מקצוע" + "</th>";
                body1 += "</tr>";
                #endregion


                List<AppProfessionXL> TzInvalid = new List<AppProfessionXL>();

                string str = ReadExcel(path, nameTab);

                List<AppProfessionXL> listProfessions = JsonConvert.DeserializeObject<List<AppProfessionXL>>(str);

                int result;
                AppProfessionDTO Profession;

                listProfessions.ForEach(con =>
                {
                    try
                    {
                        Profession = new AppProfessionDTO();

                        if (con.NameProfession == null || con.NameProfession == "" || con.Category == null || con.Category == "" || con.CoordinatorTZ == "" || con.CoordinatorTZ == null)
                        {
                            TzInvalid.Add(con);
                        }
                        else
                        {
                            int user = _UserRepository.IsUserExsistinSchool(con.CoordinatorTZ, schoolId);
                            //לא קיימת כזאת מורה במוסד
                            if (user == 0 || user == null)
                            {
                                TzInvalid.Add(con);
                            }


                            else
                            {
                                #region
                                Profession.CoordinatorId = user;
                                Profession.Name = con.NameProfession;
                                Profession.UserCreatedId = userId;
                                Profession.DateCreate = DateTime.Today;
                                Profession.SchoolId = schoolId;
                                Profession.ProfessionCategoryId = int.TryParse(con.Category, out result) ? result : (int?)null;
                                Profession.IsActive = true;
                                #endregion



                                _ProfessionRepository.AddProfession(_mapper.Map<AppProfession>(Profession), userId, schoolId);

                            }
                        }
                    }
                    catch (Exception e)
                    {
                        TzInvalid.Add(con);
                    }

                });

                if (TzInvalid != null && TzInvalid.Count() > 0)
                {


                    var i = 0;


                    foreach (var item in TzInvalid)
                    {
                        //TabProfessionCategory professionCategory = _ProfessinCategoryRepository.GetProfessionCategoriesById((int)item.ProfessionCategoryId);

                        body1 += "<tr>";

                        body1 += "<td>" + item.NameProfession + "</td>";
                        body1 += "<td>" + item.Category + "</td>";
                        body1 += "<td>" + item.CoordinatorTZ + "</td>";
                        body1 += "</tr>";

                        i++;
                    }
                    body1 += "</table>";
                    string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                    if (contact_email == null)
                        contact_email = "ravcevel@gmail.com";

                    new MailService().SendEmail(contact_email, "רשימת מקצועות לא תקינים", body1);

                }
                return true;
            }


            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        //העלאת שעות שיעורים לקבוצה
        private bool ReadLessonPerGroup(int schoolId, int userId, string path, string nameTab)
        {
            try
            {

                bool isValid = true;
                string body1 = "<h3>" + "הרשומות הבאות הן רשומות שלא הועלו כיוון שהיתה בהם תקלה." + "<br>" +
                        "</h3>";
                #region
                body1 += "<table  border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 600 + ">";
                body1 += "<tr bgcolor='#4da6ff'>";
                body1 += "<th>" + "מס קבוצה" + "</th>";
                body1 += "<th>" + "יום בשבוע" + "</th>";
                body1 += "<th>" + "מס שיעור" + "</th>";
                body1 += "<th>" + "שעת התחלה" + "</th>";
                body1 += "<th>" + "שעת סיום" + "</th>";
                body1 += "</tr>";
                #endregion


                List<AppLessonPerGroupXL> TzInvalid = new List<AppLessonPerGroupXL>();

                string str = ReadExcel(path, nameTab);

                List<AppLessonPerGroupXL> listLessonPerGroup = JsonConvert.DeserializeObject<List<AppLessonPerGroupXL>>(str);

                if (_lstGroupPerYearbook == null || _lstGroupPerYearbook.Count == 0)
                    _lstGroupPerYearbook = _mapper.Map<List<AppGroupPerYearbookDTO>>(_GroupPerYearbookRepository.GetLstGroupPerYearBookBySchoolId(schoolId));

                short shortResult1;
                short shortResult2;
                int intResult;
                double timeSpanRes1;
                //TimeSpan timeSpanRes2;
                AppLessonPerGroupDTO LessonPerGroup;
                int groupId1;
                AppGroupPerYearbookDTO group;
                listLessonPerGroup.ForEach(con =>
                {
                    try
                    {
                        LessonPerGroup = new AppLessonPerGroupDTO();

                        if (con.DayOfWeek == null || con.DayOfWeek == "" || con.NumLesson == null || con.NumLesson == "" || con.StartTime == "" || con.StartTime == null|| con.EndTime==""|| con.EndTime==null)
                        {
                            TzInvalid.Add(con);
                        }
                        else
                        {
                            

                            groupId1 = int.TryParse(con.GroupId, out intResult) ? intResult : 0;
                            group = _lstGroupPerYearbook.FirstOrDefault(s => s.IdgroupPerYearbook == groupId1);
                            short? numLesson = short.TryParse(con.NumLesson, out shortResult2) ? shortResult2 : (short?)null;
                            TimeSpan? startTime= double.TryParse(con.StartTime, out timeSpanRes1) ? DateTime.FromOADate(timeSpanRes1).TimeOfDay : (TimeSpan?)null;
                            TimeSpan? endTime= double.TryParse(con.EndTime, out timeSpanRes1) ? DateTime.FromOADate(timeSpanRes1).TimeOfDay : (TimeSpan?)null;

                            if (group==null || numLesson>24 || startTime>=endTime)
                             {
                                 TzInvalid.Add(con);
                             }
                             

                             else
                             {
                            #region

                                LessonPerGroup.DateCreated= DateTime.Today;
                                LessonPerGroup.DayOfWeek = short.TryParse(con.DayOfWeek, out shortResult1) ? shortResult1 : (short?)null;
                                LessonPerGroup.StartTime = startTime;
                                LessonPerGroup.EndTime = endTime;
                                LessonPerGroup.GroupId = int.TryParse(con.GroupId, out intResult) ? intResult : (int?)null;
                                LessonPerGroup.NumLesson = numLesson;
                                LessonPerGroup.UserCreatedId = userId;

 
                                #endregion



                                _LessonPerGroupRepository.addOrUpdateLessonPerGroup(userId,_mapper.Map<AppLessonPerGroup>(LessonPerGroup));

                             }
                        }
                    }
                    catch (Exception e)
                    {
                        TzInvalid.Add(con);
                    }

                });

                if (TzInvalid != null && TzInvalid.Count() > 0)
                {


                    var i = 0;


                    foreach (var item in TzInvalid)
                    {
                        //TabProfessionCategory professionCategory = _ProfessinCategoryRepository.GetProfessionCategoriesById((int)item.ProfessionCategoryId);

                        body1 += "<tr>";

                        body1 += "<td>" + item.GroupId + "</td>";
                        body1 += "<td>" + item.DayOfWeek + "</td>";
                        body1 += "<td>" + item.NumLesson + "</td>";
                        var StartTime = double.TryParse(item.StartTime, out timeSpanRes1) ? DateTime.FromOADate(timeSpanRes1).TimeOfDay : (TimeSpan?)null;
                        body1 += "<td>" + StartTime + "</td>";
                        var EndTime= double.TryParse(item.EndTime, out timeSpanRes1) ? DateTime.FromOADate(timeSpanRes1).TimeOfDay : (TimeSpan?)null;
                        body1 += "<td>" + EndTime + "</td>";
                        body1 += "</tr>";

                        i++;
                    }
                    body1 += "</table>";
                    string contact_email = _AppSchoolDTO != null && _AppSchoolDTO.ContactInformation != null ? _AppSchoolDTO.ContactInformation.Email : null;
                    if (contact_email == null)
                        contact_email = "ravcevel@gmail.com";

                    new MailService().SendEmail(contact_email, "רשימת שעות שיעורים לקבוצה לא תקינים", body1);

                }
                return true;
            }


            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }


        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        #region json-קריאת דף אקסל והחזרתו כסטרינג 

        public string ReadExcel(string path, string nameTab)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(path, false))
                {
                    WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                    IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                    string relationshipId = sheets.FirstOrDefault(f => f.Name == nameTab)?.Id.Value;
                    WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                    Worksheet workSheet = worksheetPart.Worksheet;
                    SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                    IEnumerable<Row> rows = sheetData.Descendants<Row>();
                    //var r= sheet.Descendants<Row>();

                    foreach (Cell cell in rows.ElementAt(0))
                    {
                        dt.Columns.Add(GetCellValue(spreadSheetDocument, cell));
                    }
                    foreach (Row row in rows) //this will also include your header row...
                    {
                        DataRow tempRow = dt.NewRow();
                        int columnIndex = 0;
                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            // Gets the column index of the cell with data
                            int cellColumnIndex = (int)GetColumnIndexFromName(GetColumnName(cell.CellReference));
                            cellColumnIndex--; //zero based index
                            if (columnIndex < cellColumnIndex && columnIndex < dt.Columns.Count)
                            {
                                do
                                {
                                    tempRow[columnIndex] = null; //Insert blank data here;
                                    columnIndex++;
                                }
                                while (columnIndex < cellColumnIndex);
                            }
                            tempRow[columnIndex] = GetCellValue(spreadSheetDocument, cell);

                            columnIndex++;
                        }
                        dt.Rows.Add(tempRow);
                    }
                }
                dt.Rows.RemoveAt(0); //...so i'm taking it out here.
                var str = JsonConvert.SerializeObject(dt);
                return str;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Given a cell name, parses the specified cell to get the column name.
        /// </summary>
        /// <param name="cellReference">Address of the cell (ie. B2)</param>
        /// <returns>Column Name (ie. B)</returns>
        public static string GetColumnName(string cellReference)
        {
            // Create a regular expression to match the column name portion of the cell name.
            Regex regex = new Regex("[A-Za-z]+");
            Match match = regex.Match(cellReference);
            return match.Value;
        }
        /// <summary>
        /// Given just the column name (no row index), it will return the zero based column index.
        /// Note: This method will only handle columns with a length of up to two (ie. A to Z and AA to ZZ). 
        /// A length of three can be implemented when needed.
        /// </summary>
        /// <param name="columnName">Column Name (ie. A or AB)</param>
        /// <returns>Zero based index if the conversion was successful; otherwise null</returns>
        public static int? GetColumnIndexFromName(string columnName)
        {

            //return columnIndex;
            string name = columnName;
            int number = 0;
            int pow = 1;
            for (int i = name.Length - 1; i >= 0; i--)
            {
                number += (name[i] - 'A' + 1) * pow;
                pow *= 26;
            }
            return number;
        }
        public static string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            if (cell.CellValue == null)
            {
                return "";
            }
            string value = cell.CellValue.InnerXml;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }



        #endregion


        public void ExportExcelFile(int schoolId)
        {
            try
            {
                //down();
                if (!Directory.Exists("Resources/Excel"))
                {
                    Directory.CreateDirectory("Resources/Excel");
                }
                string path = Path.Combine("Resources", "Excel", "ExcelToExport.xlsx");

                using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(path, false))
                {

                    List<AppScheduleRegularDTO> ListAppScheduleRegularDTO = new List<AppScheduleRegularDTO>() { new AppScheduleRegularDTO() { CourseId = 1, NumLesson = 2 }, new AppScheduleRegularDTO() { CourseId = 2, NumLesson = 5 } };
                    SpreadsheetDocument document = spreadSheetDocument;
                    WorkbookPart workbookPart = document.WorkbookPart;
                    IEnumerable<Sheet> sheets = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                    Sheet Currentsheet = sheets.FirstOrDefault(f => f.Name == "מערכת קבועה");

                    document.SaveAs("C:/Users/This_user/Downloads/DataTable to Sheet1.xlsx");
                    document.Close();
                }


            }
            catch (Exception e)
            {

                throw;
            }

        }
        static void down()
        {
            // If you are using the Professional version, enter your serial key below.
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var workbook = new ExcelFile();
            var worksheet = workbook.Worksheets.Add("DataTable to Sheet");

            var dataTable = new DataTable();

            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));

            dataTable.Rows.Add(new object[] { 100, "John", "Doe" });
            dataTable.Rows.Add(new object[] { 101, "Fred", "Nurk" });
            dataTable.Rows.Add(new object[] { 103, "Hans", "Meier" });
            dataTable.Rows.Add(new object[] { 104, "Ivan", "Horvat" });
            dataTable.Rows.Add(new object[] { 105, "Jean", "Dupont" });
            dataTable.Rows.Add(new object[] { 106, "Mario", "Rossi" });

            // worksheet.Cells[0, 0].Value = "DataTable insert example:";

            // Insert DataTable to an Excel worksheet.
            worksheet.InsertDataTable(dataTable,
                new InsertDataTableOptions()
                {
                    ColumnHeaders = true,
                    StartRow = 0
                });

            workbook.Save("C:/Users/This_user/Downloads/DataTable to Sheet.xlsx");
        }
        public void DownloadExcel()
        {

            //required using ClosedXML.Excel;
            string contentType = "application/vnd.openxmlformats-officedocument.ssedsheetml.sheet";
            string fileName = "authors.xlsx";
            List<AppScheduleRegularDTO> ListAppScheduleRegularDTO = new List<AppScheduleRegularDTO>() { new AppScheduleRegularDTO() { CourseId = 1, NumLesson = 2 }, new AppScheduleRegularDTO() { CourseId = 2, NumLesson = 5 } };
            string path = Path.Combine("Resources", "Excel", "ExcelToExport.xlsx");

            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet =
                    workbook.Worksheets.Add("Authors");
                    worksheet.Cell(1, 1).Value = "CourseId";
                    worksheet.Cell(1, 2).Value = "NumLesson";
                    worksheet.Cell(1, 3).Value = "LastName";
                    for (int index = 1; index <= ListAppScheduleRegularDTO.Count; index++)
                    {
                        worksheet.Cell(index + 1, 1).Value = ListAppScheduleRegularDTO[index - 1].CourseId;
                        worksheet.Cell(index + 1, 2).Value = ListAppScheduleRegularDTO[index - 1].NumLesson;

                    }
                    //required using System.IO;
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        //return File(content, contentType, fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                //return Error();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();//GetDataTableFromExcel();
            List<DataTable> dts = dt.AsEnumerable()
            .GroupBy(row => row.Field<string>("Ref_ID"))
            .Select(g => g.CopyToDataTable()).ToList();

            string path = "D:\\Excel\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                for (int i = 0; i < dts.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dts[i].Rows[0][0].ToString()))
                    {
                        wb.Worksheets.Add(dts[i], dts[i].Rows[0][0].ToString());
                    }
                }
                wb.SaveAs(path + "OrderDetails.xlsx");
            }
            // DownloadFile(path + "OrderDetails.xlsx");
        }
        //public void DownloadFile(string path)
        //{
        //    Response.Clear();
        //    Response.ContentType = "application/octet-stream";
        //    Response.AddHeader("content-disposition", "attachment;filename=" + Path.GetFileName(path));
        //    Response.WriteFile(path);
        //    Response.End();
        //}
    }
}
