using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Repository.Interfaces;
using DB.Repository.Classes;
using AutoMapper;
using Services.Interfaces;


namespace Services.Classes
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _SchoolRepository;
        private readonly IMapper _mapper;
        private readonly IMailService _MailService;


        public SchoolService(ISchoolRepository SchoolRepository, IMapper mapper, IMailService MailService)
        {
            _SchoolRepository = SchoolRepository;
            _mapper = mapper;
            _MailService = MailService;
        }

        //שליפת סיסמא ע"פ שם משתמש
        public List<string> GetPasswordToEmailByUserCode(string UserCode, string Email)
        {
            var User = _SchoolRepository.GetPasswordByUserCode(UserCode);
            if (User == null || User.Count() == 0)
                return null;
            var listEmail = new List<string>();
            if (Email != null && Email != "" && Email != "null")
            {
                Task t = Task.Run(() =>
                {
                    _MailService.SendEmail(Email, "שחזור סיסמא", User[0].User.UserPassword);
                });
                return listEmail;
            }
            User.ForEach(f =>
            {
                if (f.ContactInformation != null && f.ContactInformation.Email != null)
                    listEmail.Add(f.ContactInformation.Email);
            });
            listEmail = listEmail.Distinct().ToList();
            if (listEmail.Count() == 1)
            {
                Task t = Task.Run(() =>
                {
                    _MailService.SendEmail(listEmail[0], "שחזור סיסמא", User[0].User.UserPassword);
                });
                return listEmail;
            }
            return listEmail;
        }

        public ReturnObjectSchoolAndYearbookDTO GetSchoolByUserCodeAndPassword(string UserCode, string UserPassword)
        {
             var user = _SchoolRepository.GetUserToCustomerByUserCodeAndUserPassword(UserCode, UserPassword);
            if (user == null)
                return new ReturnObjectSchoolAndYearbookDTO() { UserId = 0, Status = 2, NameStatus = "שם המשתמש או הסיסמא שגוי", ListSchool = null, ListYearbook = null };//לא קיים משתמש עם הנתונים שהזנת.
            
            var schools = _SchoolRepository.GetAllSchoolAndYearbookPerUser(user);
            var s = _mapper.Map<List<AppSchoolWhithYearbookDTO>>(schools);
            return new ReturnObjectSchoolAndYearbookDTO() { UserId = user.Iduser, NameStatus = "", Status = 1, ListSchool = s, ListYearbook = _mapper.Map<List<AppYearbookDTO>>(_SchoolRepository.GetAllYearbook()) };

            //var user=_mapper.Map<AppUserPerSchoolDTO>(_SchoolRepository.GetUserIDByUserCodeAndPassword(UserCode, UserPassword));
            //var userSchool = new UserSchoolDTO()
            //{
            //    UserId =user.IduserPerSchool,
            //    ListSchool = _mapper.Map<List<AppSchoolDTO>>(_SchoolRepository.GetSchoolByUserId((int)user.UserId))
            //};
            //return userSchool;
        }


        public AppSchoolDTO GetSchoolById(int schoolId)
        {
            try
            {
                var school = _SchoolRepository.GetSchoolBySchoolId(schoolId);
                return _mapper.Map<AppSchoolDTO>(school);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
        public List<ListCodeTable> GetAllTable()
        {
            var list = new List<ListCodeTable>(); ListCodeTable code;
            var tables = _SchoolRepository.GetAllTable();
            var Tables = _mapper.Map<List<CodeTableDTO>>(tables).GroupBy(g => g.Table).ToList();
            foreach (var item in Tables)
            {
                code = new ListCodeTable()
                {
                    NameTable = item.Key,
                    ListCodetable = item.ToList()
                };
                list.Add(code);
            }
            return list;
            //return _mapper.Map<List<CodeTableDTO>>(tables);


        }
        public List<AppYearbookPerSchoolDTO> GetAllYearbook(int SchoolId)
        {
            return _mapper.Map<List<AppYearbookPerSchoolDTO>>(_SchoolRepository.GetAllYearbook(SchoolId));
        }

        public AppYearbookPerSchoolDTO AddYearbook(DateTime FromDate, DateTime ToDate, string Name, int UserCreatedId, int SchoolId)
        {
            return _mapper.Map<AppYearbookPerSchoolDTO>(_SchoolRepository.AddYearbook(FromDate, ToDate, Name, UserCreatedId, SchoolId));
        }

        public ReturnObjectSchoolAndYearbookDTO GetAllSchoolAndYearbookPerCustomer(string UserCode, string UserPassword)
        {
            var user = _SchoolRepository.GetUserToCustomerByUserCodeAndUserPassword(UserCode, UserPassword);
            if (user == null)
                return new ReturnObjectSchoolAndYearbookDTO() { UserId = 0, Status = 2, NameStatus = "שם המשתמש או הסיסמא שגוי", ListSchool = null, ListYearbook = null };//לא קיים משתמש עם הנתונים שהזנת.
            if (user.AppUserPerCustomer==null)
                return new ReturnObjectSchoolAndYearbookDTO() { UserId = 0, Status = 3, NameStatus = "משתמש זה אינו מוגדר כלקוח", ListSchool = null, ListYearbook = null };//משתמש זה אינו מוגדר כלקוח.
            var schools = _SchoolRepository.GetAllSchoolAndYearbookPerCustomer(user);
            var s = _mapper.Map<List<AppSchoolWhithYearbookDTO>>(schools);
            return new ReturnObjectSchoolAndYearbookDTO() { UserId = user.Iduser,UserPerCustomerId=(int) user.AppUserPerCustomer.IduserPerCustomer, NameStatus = "", Status = 1, ListSchool = s, ListYearbook = _mapper.Map<List<AppYearbookDTO>>(_SchoolRepository.GetAllYearbook()) };
        }

    }
}
