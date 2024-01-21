using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly ExtraSchoolContext _context;
        private readonly ICheckTZRepository _checkTZRepository;
        private readonly IUniqeCodeRepository _uniqeCodeRepository;

        public UserRepository(ExtraSchoolContext context, ICheckTZRepository checkTZRepository, IUniqeCodeRepository uniqeCodeRepository)
        {
            _context = context;
            _checkTZRepository = checkTZRepository;
            _uniqeCodeRepository = uniqeCodeRepository;
        }

        //שליפת משתמשים לפי מוסד
        public List<AppUserPerSchool> GetAllUserBySchoolId(int SchoolId)
        {
            return _context.AppUserPerSchools.Include(u => u.User).Where(w => w.SchoolId == SchoolId && w.UserId != null).ToList();
        }

        //שליפת משתמשים לפי מוסד ושנה
        public List<AppUserPerSchool> GetUsersBySchoolIDAndYearbookId(string SchoolsId, int yearbookId)
        {
            SchoolsId = SchoolsId.Remove(SchoolsId.Length - 1);

            var Array = SchoolsId.Split(",").ToList();
            var u = _context.AppUserPerYearbooks.Include(y => y.Yearbook).Include(u => u.User).ThenInclude(u => u.User).Include(u => u.User.School)
                .Where(w =>
            w.Yearbook != null && w.Yearbook.YearbookId == yearbookId && Array.Contains(w.Yearbook.SchoolId.ToString()) == true && w.UserId != null).Select(u => u.User).ToList();
            return u;
        }

        // ID שליפת פרטי משתמש לפי 
        public AppUserPerSchool GetUserDetailsByIDUser(int UserID, int SchoolId)
        {
            var user = _context.AppUserPerSchools.Include(u => u.User).Include(b => b.Birth).Include(u => u.Address).Include(c => c.ContactInformation).FirstOrDefault(f => f.User.Iduser == UserID && f.SchoolId == SchoolId);
            return user;
        }

        //הוספת משתמש
        public Tuple<AppUserPerSchool, string, string> AddUser(AppUserPerSchool UserPerSchool, int UserCreatedId, int SchoolId, int yearbookId)
        {
            try
            {
                //new MailRepository().SendEmail("sariw1292@gmail.com", "תחילה הוספה", "");

                Tuple<AppUserPerSchool, string, string> tuple;


                bool isValid = true;
                if (UserPerSchool.User.TypeIdentityId == 2)
                    isValid = _checkTZRepository.CheckTZ(UserPerSchool.User.Tz);
                if (isValid == false)
                {
                    tuple = Tuple.Create(UserPerSchool, "תז לא תקינה", "1");
                    return tuple;
                }

                UserPerSchool.UserCreatedId = UserCreatedId;
                UserPerSchool.DateCreated = DateTime.Today;
                UserPerSchool.User.UserCreatedId = UserCreatedId;
                UserPerSchool.User.DateCreated = DateTime.Today;
                UserPerSchool.Birth.BirthDate = UserPerSchool.Birth.BirthDate!= null ? DateTime.Parse(UserPerSchool.Birth.BirthDate.ToString()): null;
                UserPerSchool.Birth.DateOfImmigration = UserPerSchool.Birth.DateOfImmigration != null ? DateTime.Parse(UserPerSchool.Birth.DateOfImmigration.ToString()) : null;
                UserPerSchool.Address.UserCreatedId = UserCreatedId;
                UserPerSchool.Address.DateCreated = DateTime.Today;
                UserPerSchool.ContactInformation.UserCreatedId = UserCreatedId;
                UserPerSchool.ContactInformation.DateCreated = DateTime.Today;
                UserPerSchool.Birth.UserCreatedId = UserCreatedId;
                UserPerSchool.Birth.DateCreated = DateTime.Today;


                var user = _context.AppUserPerSchools.Include(u => u.User).Include(i => i.AppUserPerYearbookUsers).FirstOrDefault(
                       f => f.User.Tz == UserPerSchool.User.Tz && f.SchoolId == SchoolId);
                if (user != null)
                {
                    if (user.AppUserPerYearbookUsers != null && user.AppUserPerYearbookUsers.FirstOrDefault(f => f.YearbookId == yearbookId) != null)
                    {
                        tuple = Tuple.Create(UserPerSchool, "הזנת תז של משתמש קיים במוסד זה", "2");
                        return tuple;
                    }

                    AppUserPerYearbook appUserPerYearbook = new AppUserPerYearbook()
                    {
                        YearbookId = yearbookId,
                        DateCreated = DateTime.Today,
                        UserId = user.IduserPerSchool,
                        UserCreatedId = UserCreatedId
                    };

                    _context.AppUserPerYearbooks.Add(appUserPerYearbook);
                    _context.SaveChanges();



                    //UserPerSchool = GenericFunctionsRepository.Clone(user);


                    tuple = Tuple.Create(user, "הזנת תז של משתמש קיים במוסד זה בשנתון אחר ולכן נוסף לשנתון עם הנתונים שהיו קיימים.", "3");
                    return tuple;

                    // user.AppUserPerYearbookUsers
                }
                else
                {

                    var user2 = _context.SecUsers.FirstOrDefault(u => u.Tz == UserPerSchool.User.Tz);
                    if (user2 != null)
                    {
                        UserPerSchool.User = user2;
                        UserPerSchool.UserId = user2.Iduser;
                        UserPerSchool.SchoolId = SchoolId;
                    }
                    else
                    {
                        Random rnd = new Random();
                        int num = rnd.Next(100000, 999999);
                        UserPerSchool.User.UserPassword = num.ToString();
                        UserPerSchool.User.UserCreatedId = UserCreatedId;
                        UserPerSchool.User.DateCreated = DateTime.Today;
                    }

                    _context.AppUserPerSchools.Add(UserPerSchool);
                    _context.SaveChanges();
                    _context.AppUserPerYearbooks.Add(new AppUserPerYearbook() { UserId = UserPerSchool.IduserPerSchool, YearbookId = yearbookId, UserCreatedId = UserCreatedId, DateCreated = DateTime.Today });
                    _context.SaveChanges();

                    tuple = Tuple.Create(UserPerSchool, "המשתמש נוסף בהצלחה", "4");
                    //new MailRepository().SendEmail("sariw1292@gmail.com", "הצלחת הוספה", "");

                    return tuple;
                }
            }
            catch (Exception e)
            {
                new MailRepository().SendEmail("sariw1292@gmail.com", "כישחון הוספה", "");

                return null;
            }
        }

        //עדכון משתמש
        public AppUserPerSchool UpdateUser(AppUserPerSchool u, int userId, int iduserPerSchool = 0, bool isExcel = false)
        {
            if (iduserPerSchool > 0)
                u.IduserPerSchool = iduserPerSchool;
            var user = _context.AppUserPerSchools.Include(b => b.User).Include(b => b.Birth).Include(a => a.Address).Include(c => c.ContactInformation).FirstOrDefault(f => f.IduserPerSchool == u.IduserPerSchool);
            if (user != null)
            {
                if (user.User == null)
                {
                    user.User = new SecUser();
                }

                user.FirstName = isExcel && u.FirstName != null ? u.FirstName : user.FirstName;
                user.LastName = isExcel && u.LastName != null ? u.LastName : user.LastName;
                user.FullName = isExcel && u.FullName != null ? u.FullName : user.FullName;
                user.GenderId = isExcel && u.GenderId != null ? u.GenderId : user.GenderId;
                user.AddressId = isExcel && u.AddressId != null ? u.AddressId : user.AddressId;
                user.ContactInformationId = isExcel && u.ContactInformationId != null ? u.ContactInformationId : user.ContactInformationId;
                user.IsActive = isExcel && u.IsActive != null ? u.IsActive : user.IsActive;
                user.Note = isExcel && u.Note != null ? u.Note : user.Note;
                user.UserUpdetedId = userId;
                user.DateUpdated = DateTime.Today;

                if (user.User == null)
                {
                    user.User = new SecUser();
                }
                user.User.DateUpdated = DateTime.Today;
                user.User.UserUpdatedId = userId;
                user.User.TypeIdentityId = isExcel && u.User.TypeIdentityId != null ? u.User.TypeIdentityId : user.User.TypeIdentityId;
                user.User.UserPassword = isExcel && u.User.UserPassword != null ? u.User.UserPassword : user.User.UserPassword;
                user.User.UserCode = isExcel && u.User.UserCode != null ? u.User.UserCode : user.User.UserCode;

                if (user.Address == null)
                {
                    user.Address = new AppAddress();
                }
                if (u.Address != null)
                {
                    user.Address.UserUpdatedId = userId;
                    user.Address.DateUpdated = DateTime.Today;
                    user.Address.CityId = isExcel && u.Address.CityId != null ? u.Address.CityId : user.Address.CityId;
                    user.Address.HouseNumber = isExcel && u.Address.HouseNumber != null ? u.Address.HouseNumber : user.Address.HouseNumber;
                    user.Address.ApartmentNumber = isExcel && u.Address.ApartmentNumber != null ? u.Address.ApartmentNumber : user.Address.ApartmentNumber;
                    user.Address.NeighborhoodId = isExcel && u.Address.NeighborhoodId != null ? u.Address.NeighborhoodId : user.Address.NeighborhoodId;
                    user.Address.PoBox = isExcel && u.Address.PoBox != null ? u.Address.PoBox : user.Address.PoBox;
                    user.Address.StreetId = isExcel && u.Address.StreetId != null ? u.Address.StreetId : user.Address.StreetId;
                    user.Address.ZipCode = isExcel && u.Address.ZipCode != null ? u.Address.ZipCode : user.Address.ZipCode;
                }
                if (user.Birth == null)
                {
                    user.Birth = new AppBirth();
                }
                if (u.Birth != null)
                {
                    user.Birth.UserUpdatedId = userId;
                    user.Birth.DateUpdated = DateTime.Today;
                    user.Birth.BirthCountryId = isExcel && u.Birth.BirthCountryId != null ? u.Birth.BirthCountryId : user.Birth.BirthCountryId;
                    user.Birth.CountryIdofImmigration = isExcel && u.Birth.CountryIdofImmigration != null ? u.Birth.CountryIdofImmigration : user.Birth.CountryIdofImmigration;
                    user.Birth.BirthHebrewDate = isExcel && u.Birth.BirthHebrewDate != null ? u.Birth.BirthHebrewDate : user.Birth.BirthHebrewDate;
                    user.Birth.CitizenshipId = isExcel && u.Birth.CitizenshipId != null ? u.Birth.CitizenshipId : user.Birth.CitizenshipId;
                    user.Birth.BirthDate = isExcel && u.Birth.BirthDate != null ? DateTime.Parse(u.Birth.BirthDate.ToString()) : user.Birth.BirthDate;
                    user.Birth.DateOfImmigration = isExcel && u.Birth.DateOfImmigration != null ? DateTime.Parse(u.Birth.DateOfImmigration.ToString()) : user.Birth.DateOfImmigration;

                }
                if (user.ContactInformation == null)
                {
                    user.ContactInformation = new AppContactInformation();
                }
                if (u.ContactInformation != null)
                {
                    user.ContactInformation.Email = isExcel && u.ContactInformation.Email != null ? u.ContactInformation.Email : user.ContactInformation.Email;
                    user.ContactInformation.PhoneNumber1 = isExcel && u.ContactInformation.PhoneNumber1 != null ? u.ContactInformation.PhoneNumber1 : user.ContactInformation.PhoneNumber1;
                    user.ContactInformation.PhoneNumber2 = isExcel && u.ContactInformation.PhoneNumber2 != null ? u.ContactInformation.PhoneNumber2 : user.ContactInformation.PhoneNumber2;
                    user.ContactInformation.PhoneNumber3 = isExcel && u.ContactInformation.PhoneNumber3 != null ? u.ContactInformation.PhoneNumber3 : user.ContactInformation.PhoneNumber3;
                    user.ContactInformation.TelephoneNumber1 = isExcel && u.ContactInformation.TelephoneNumber1 != null ? u.ContactInformation.TelephoneNumber1 : user.ContactInformation.TelephoneNumber1;
                    user.ContactInformation.TelephoneNumber2 = isExcel && u.ContactInformation.TelephoneNumber2 != null ? u.ContactInformation.TelephoneNumber2 : user.ContactInformation.TelephoneNumber2;
                    user.ContactInformation.FaxNumber = isExcel && u.ContactInformation.FaxNumber != null ? u.ContactInformation.FaxNumber : user.ContactInformation.FaxNumber;
                    user.ContactInformation.Comment = isExcel && u.ContactInformation.Comment != null ? u.ContactInformation.Comment : user.ContactInformation.Comment;
                    user.ContactInformation.UserUpdatedId = userId;
                    user.ContactInformation.DateUpdated = DateTime.Today;
                }
                _context.SaveChanges();
            }

            return user;
        }

        //מחיקת משתמש
        public int DeleteUser(int UserId, int SchoolId)
        {
            // מה לגבי משתמש שאחראי על מטלה או על קורס או על מקצוע??
            //לא ניתן למחוק אותו
            var User = _context.AppUserPerSchools.Include(u => u.User.AppUserPerSchools).Include(c => c.ContactInformation).Include(i => i.AppUserPerYearbookUsers)
                .Include(i => i.Address).Include(i => i.Birth)
                .FirstOrDefault(f => f.SchoolId == SchoolId && f.UserId == UserId);
            if (User != null)
            {
                var contactInformation = User.ContactInformation;
                var yearbook = User.AppUserPerYearbookUsers;
                if (User.User == null)
                    User.User = new SecUser();
                var AppUserPerSchools = User.User.AppUserPerSchools;
                var address = User.Address;
                var birth = User.Birth;

                try
                {
                    _context.AppUserPerSchools.Remove(User);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {

                    return 3;
                }


                if (contactInformation != null)
                {
                    _context.AppContactInformations.Remove(contactInformation);
                    _context.SaveChanges();
                }
                //if (yearbook != null && yearbook.Count > 0)
                //{
                //    _context.AppUserPerYearbooks.RemoveRange(yearbook);
                //    _context.SaveChanges();
                //}

                if (address != null)
                {
                    _context.AppAddresses.Remove(address);
                    _context.SaveChanges();
                }

                if (birth != null)
                {
                    _context.AppBirths.Remove(birth);
                    _context.SaveChanges();
                }

                if (AppUserPerSchools == null || AppUserPerSchools.Count == 0)
                {
                    _context.SecUsers.Remove(User.User);
                    _context.SaveChanges();
                }
                return 1;
            }
            else
                return 0;

        }


        //הוספת משתמש ברמת לקוח למוסדות שאין להם את המשתמש הבחור... לאחראי מטלה... ומי שכן יש להפוך אותו לרמת לקוח
        public Tuple<Dictionary<int, int>, List<AppUserPerSchool>, int> AddUserByCustomer(int UserId, List<SchoolWithYearBookAndUserPerSchool> schools, int customerId)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            SecUser users = _context.SecUsers.Include(i => i.AppUserPerSchools).ThenInclude(i => i.ContactInformation).Include(i => i.AppUserPerSchools).ThenInclude(i => i.AppUserPerYearbookUsers).FirstOrDefault(w => w.Iduser == UserId);
            AppUserPerSchool appUserPerSchool = users.AppUserPerSchools.FirstOrDefault(f => f.UniqueCodeId != null && f.UniqueCodeId != 0);
            int? code;
            AppUserPerYearbook AppUserPerYearbook;
            AppUserPerSchool app;
            AppUserPerSchool u;
            List<AppUserPerSchool> listUser = new List<AppUserPerSchool>();
            int uniqeCodeToUpdate = 0;

            if (appUserPerSchool == null)
            {
                appUserPerSchool = users.AppUserPerSchools.FirstOrDefault();
                AppUniqueCode AppUniqueCode = new AppUniqueCode() { CustomerId = customerId, DateCreated = DateTime.Today };
                _context.AppUniqueCodes.Add(AppUniqueCode);
                _context.SaveChanges();
                code = AppUniqueCode.IduniqueCode;
            }
            else
                code = appUserPerSchool.UniqueCodeId;


            //List<AppUserPerSchool> lst = new List<AppUserPerSchool>();
            schools.ForEach(fo =>
                     {
                         u = users.AppUserPerSchools.FirstOrDefault(f => f.SchoolId == fo.SchoolId);
                         if (u == null)
                         {

                             app = new AppUserPerSchool()
                             {
                                 UserId = UserId,
                                 SchoolId = fo.SchoolId,
                                 UserCreatedId = fo.UserPerSchoolId,
                                 DateCreated = DateTime.Today,
                                 ContactInformation = new AppContactInformation()
                                 {
                                     TelephoneNumber1 = appUserPerSchool != null && appUserPerSchool.ContactInformation != null ? appUserPerSchool.ContactInformation.TelephoneNumber1 : null,
                                     TelephoneNumber2 = appUserPerSchool != null && appUserPerSchool.ContactInformation != null ? appUserPerSchool.ContactInformation.TelephoneNumber2 : null,
                                     PhoneNumber1 = appUserPerSchool != null && appUserPerSchool.ContactInformation != null ? appUserPerSchool.ContactInformation.PhoneNumber1 : null,
                                     PhoneNumber2 = appUserPerSchool != null && appUserPerSchool.ContactInformation != null ? appUserPerSchool.ContactInformation.PhoneNumber2 : null,
                                     PhoneNumber3 = appUserPerSchool != null && appUserPerSchool.ContactInformation != null ? appUserPerSchool.ContactInformation.PhoneNumber3 : null,
                                     FaxNumber = appUserPerSchool != null && appUserPerSchool.ContactInformation != null ? appUserPerSchool.ContactInformation.FaxNumber : null,
                                     Email = appUserPerSchool != null && appUserPerSchool.ContactInformation != null ? appUserPerSchool.ContactInformation.Email : null,
                                     Comment = appUserPerSchool != null && appUserPerSchool.ContactInformation != null ? appUserPerSchool.ContactInformation.Comment : null,
                                     UserCreatedId = fo.UserPerSchoolId,
                                     DateCreated = DateTime.Today,
                                     IsMobile = appUserPerSchool != null && appUserPerSchool.ContactInformation != null ? appUserPerSchool.ContactInformation.IsMobile : null,
                                     Job = appUserPerSchool != null && appUserPerSchool.ContactInformation != null ? appUserPerSchool.ContactInformation.Job : null,
                                 },
                                 IsActive = true,
                                 UniqueCodeId = code,
                             };

                             AppUserPerYearbook = new AppUserPerYearbook()
                             {
                                 User = app,
                                 YearbookId = fo.YearBookId,
                                 UserCreatedId = fo.UserPerSchoolId,
                                 DateCreated = DateTime.Today
                             };
                             _context.AppUserPerYearbooks.Add(AppUserPerYearbook);
                             _context.SaveChanges();
                             listUser.Add(app);
                         }
                         else
                         {
                             if (u.AppUserPerYearbookUsers.FirstOrDefault(f => f.YearbookId == fo.YearBookId) == null)
                             {
                                 AppUserPerYearbook = new AppUserPerYearbook()
                                 {
                                     User = u,
                                     YearbookId = fo.YearBookId,
                                     UserCreatedId = fo.UserPerSchoolId,
                                     DateCreated = DateTime.Today
                                 };
                                 _context.AppUserPerYearbooks.Add(AppUserPerYearbook);
                                 _context.SaveChanges();
                                 listUser.Add(u);

                             }
                             if (u.UniqueCodeId != code)
                             {
                                 u.UniqueCodeId = code;
                                 _context.SaveChanges();
                                 uniqeCodeToUpdate = (int)code;
                             }
                             app = u;
                         }
                         dict.Add(fo.SchoolId, app.IduserPerSchool);

                     }
                );

            Tuple<Dictionary<int, int>, List<AppUserPerSchool>, int> tup;
            tup = Tuple.Create(dict, listUser, uniqeCodeToUpdate);


            return tup;

        }

        //הוספת שיוך משתמש למוסד-העתקת נתוני משתמש ממוסד למוסד
        public Tuple<AppUserPerSchool, int, bool> AddCopyUserPerSchool(AppUserPerSchool userPerSchool, AppSchool School, int CoustomerId, int? UserCreatedId, int YearbookId)
        {
            SecUser users = _context.SecUsers.Include(i => i.AppUserPerSchools).ThenInclude(i => i.ContactInformation).Include(i => i.AppUserPerSchools).ThenInclude(i => i.AppUserPerYearbookUsers).Include(s => s.AppUserPerSchools).ThenInclude(s => s.School).FirstOrDefault(w => userPerSchool.User != null && w.Iduser == userPerSchool.User.Iduser);
            AppUserPerSchool appUserPerSchool = users.AppUserPerSchools.FirstOrDefault(f => f.UniqueCodeId != null && f.UniqueCodeId != 0 && f.School != null && f.School.CoordinationCode == School.CoordinationCode);
            //קוד ייחודי למשתמש במוסד
            int UniqeCodeToUserPerSchoolId;
            if (appUserPerSchool == null)
                UniqeCodeToUserPerSchoolId = _uniqeCodeRepository.AddUniqeCode(CoustomerId);
            else
            {
                UniqeCodeToUserPerSchoolId = (int)appUserPerSchool.UniqueCodeId;
                userPerSchool = users.AppUserPerSchools.FirstOrDefault();
            }

            var newUserPerSchool = users.AppUserPerSchools.FirstOrDefault(f => f.SchoolId == School.Idschool);
            if (newUserPerSchool == null)
            {
                //פתיחת משתמש למוסד
                newUserPerSchool = new AppUserPerSchool()
                {
                    UserId = userPerSchool.UserId,
                    SchoolId = School.Idschool,
                    UserCreatedId = UserCreatedId,
                    DateCreated = DateTime.Today,
                    FirstName = userPerSchool.FirstName,
                    LastName = userPerSchool.LastName,
                    FullName = userPerSchool.FullName,
                    GenderId = userPerSchool.GenderId,
                    StatusId = userPerSchool.StatusId,
                    ForeignLastName = userPerSchool.ForeignLastName,
                    ForeignFirstName = userPerSchool.ForeignFirstName,
                    PreviusName = userPerSchool.PreviusName,
                    Note = userPerSchool.Note,
                    DateOfStartWork = userPerSchool.DateOfStartWork,
                    YearsOfEducation = userPerSchool.YearsOfEducation,
                    YearsOfSeniority = userPerSchool.YearsOfSeniority,
                    DegreeId = userPerSchool.DegreeId,

                    Address = new AppAddress()
                    {
                        CityId = userPerSchool != null && userPerSchool.Address != null ? userPerSchool.Address.CityId : null,
                        StreetId = userPerSchool != null && userPerSchool.Address != null ? userPerSchool.Address.StreetId : null,
                        HouseNumber = userPerSchool != null && userPerSchool.Address != null ? userPerSchool.Address.HouseNumber : null,
                        ApartmentNumber = userPerSchool != null && userPerSchool.Address != null ? userPerSchool.Address.ApartmentNumber : null,
                        PoBox = userPerSchool != null && userPerSchool.Address != null ? userPerSchool.Address.PoBox : null,
                        ZipCode = userPerSchool != null && userPerSchool.Address != null ? userPerSchool.Address.ZipCode : null,
                        NeighborhoodId = userPerSchool != null && userPerSchool.Address != null ? userPerSchool.Address.NeighborhoodId : null,
                        UserCreatedId = UserCreatedId,
                        DateCreated = DateTime.Today,
                        Comment = userPerSchool != null && userPerSchool.Address != null ? userPerSchool.Address.Comment : null
                    },
                    Birth = new AppBirth()
                    {
                        BirthCountryId = userPerSchool != null && userPerSchool.Birth != null ? userPerSchool.Birth.BirthCountryId : null,
                        BirthDate = userPerSchool != null && userPerSchool.Birth != null ? userPerSchool.Birth.BirthDate : null,
                        BirthHebrewDate = userPerSchool != null && userPerSchool.Birth != null ? userPerSchool.Birth.BirthHebrewDate : null,
                        CitizenshipId = userPerSchool != null && userPerSchool.Birth != null ? userPerSchool.Birth.CitizenshipId : null,
                        DateOfImmigration = userPerSchool != null && userPerSchool.Birth != null ? userPerSchool.Birth.DateOfImmigration : null,
                        CountryIdofImmigration = userPerSchool != null && userPerSchool.Birth != null ? userPerSchool.Birth.CountryIdofImmigration : null,
                        UserCreatedId = UserCreatedId,
                        DateCreated = DateTime.Today
                    },
                    ContactInformation = new AppContactInformation()
                    {
                        TelephoneNumber1 = userPerSchool.ContactInformation != null ? userPerSchool.ContactInformation.TelephoneNumber1 : "",
                        TelephoneNumber2 = userPerSchool.ContactInformation != null ? userPerSchool.ContactInformation.TelephoneNumber2 : "",
                        PhoneNumber1 = userPerSchool.ContactInformation != null ? userPerSchool.ContactInformation.PhoneNumber1 : "",
                        PhoneNumber2 = userPerSchool.ContactInformation != null ? userPerSchool.ContactInformation.PhoneNumber2 : "",
                        PhoneNumber3 = userPerSchool.ContactInformation != null ? userPerSchool.ContactInformation.PhoneNumber3 : "",
                        FaxNumber = userPerSchool.ContactInformation != null ? userPerSchool.ContactInformation.FaxNumber : "",
                        Email = userPerSchool.ContactInformation != null ? userPerSchool.ContactInformation.Email : "",
                        Comment = userPerSchool.ContactInformation != null ? userPerSchool.ContactInformation.Comment : "",
                        UserCreatedId = UserCreatedId,
                        DateCreated = DateTime.Today,
                        IsMobile = userPerSchool.ContactInformation != null ? userPerSchool.ContactInformation.IsMobile : "",
                        Job = userPerSchool.ContactInformation != null ? userPerSchool.ContactInformation.Job : ""
                    },
                    IsActive = true,
                    TypeUserId = userPerSchool.TypeUserId,
                    UniqueCodeId = UniqeCodeToUserPerSchoolId
                };
            }
            else
            {
                //אם אין קוד-תיאום למשתמש במוסד-הוספת קוד תיאום
                if (newUserPerSchool.UniqueCodeId == null || newUserPerSchool.UniqueCodeId == 0)
                    newUserPerSchool.UniqueCodeId = UniqeCodeToUserPerSchoolId;
                var UserPerYearbook = newUserPerSchool.AppUserPerYearbookUsers.FirstOrDefault(f => f.YearbookId == YearbookId);
                //אם לא הייתה הוספה כלל
                if (UserPerYearbook != null)
                    return Tuple.Create(newUserPerSchool, UniqeCodeToUserPerSchoolId, false);
            }
            //פתיחת משתמש לשנתון
            return Tuple.Create(AddUserPerYearbook(newUserPerSchool, School.Idschool, YearbookId, UserCreatedId), UniqeCodeToUserPerSchoolId, true);
        }
        //(פונקציית הוספת משתמש לשנתון+(יתכן גם משתמש למוסד
        private AppUserPerSchool AddUserPerYearbook(AppUserPerSchool newUserPerSchool, int schoolId, int YearbookId, int? UserCreatedId)
        {
            var newUserPerYerbook = new AppUserPerYearbook()
            {
                User = newUserPerSchool,
                YearbookId = YearbookId,
                UserCreatedId = UserCreatedId,
                DateCreated = DateTime.Today
            };
            _context.AppUserPerYearbooks.Add(newUserPerYerbook);
            _context.SaveChanges();
            return _context.AppUserPerSchools.Include(u => u.User).Include(s => s.School).FirstOrDefault(f => f.IduserPerSchool == newUserPerYerbook.User.IduserPerSchool);
        }

        //בדיקה אם המשתמש קיים
        public SecUser IsUserExsist(string tz, int schoolId)
        {
            // var s = _context.AppUserPerSchools.Include(i => i.User).Include(i => i.Address).Include(i => i.Birth).Include(i => i.ContactInformation).FirstOrDefault(f => (f != null && f.SchoolId == schoolId && f.User!= null && f.User.Tz== tz));

            SecUser su = _context.SecUsers.Include(i => i.AppUserPerSchools/*.FirstOrDefault(f=> f.SchoolId == schoolId)*/).ThenInclude(i => i.Address)
                .Include(i => i.AppUserPerSchools).ThenInclude(i => i.Birth)
                .Include(i => i.AppUserPerSchools).ThenInclude(i => i.ContactInformation)
                .FirstOrDefault(f => f.Tz == tz);
            if (su != null)
                su.AppUserPerSchools = su.AppUserPerSchools.Where(f => f.SchoolId == schoolId).ToList();

            return su;
        }
        // בדיקה אם המשתמש קיים במוסד
        public int IsUserExsistinSchool(string tz, int schoolId)
        {
            var s = _context.AppUserPerSchools.Include(i => i.User).FirstOrDefault(f => (f != null && f.SchoolId == schoolId && f.User != null && f.User.Tz == tz));

            if (s != null && s.IduserPerSchool != null && s.IduserPerSchool != 0 && tz != null && schoolId != null && schoolId != 0)
                return s.IduserPerSchool;
            return 0;
        }
    }
}
