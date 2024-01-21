using DTO.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DB.Repository.Interfaces;
using DB.Model;

namespace Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IMailService _MailService;


        public UserService(IMapper mapper, IUserRepository userRepository, IMailService MailService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _MailService = MailService;

        }

        public List<AppUserPerSchoolDTO> GetAllUserBySchoolId(int SchoolId)
        {
            return _mapper.Map<List<AppUserPerSchoolDTO>>(_userRepository.GetAllUserBySchoolId(SchoolId));
        }

        public List<SecUserDTO> GetUsersBySchoolIDAndYearbookId(string SchoolsId, int yearbookId)
        {
            var ListUser = _mapper.Map<List<SecUserDTO>>(_userRepository.GetUsersBySchoolIDAndYearbookId(SchoolsId, yearbookId));
            //if (ListUser.Count() > 0) ListUser[0].YearbookId = yearbookId;
            return ListUser;
        }

        public AppUserPerSchoolWithDetailsDTO GetUserDetailsByIDUser(int UserId, int SchoolId)
        {
            var a = _userRepository.GetUserDetailsByIDUser(UserId, SchoolId);
            var x = _mapper.Map<AppUserPerSchoolWithDetailsDTO>(a);
            return x;
        }

        //הוספת משתמש
        public ReturnObjectOfAddUserDTO AddUser(AppUserPerSchoolWithDetailsDTO User, int UserCreatedId, int SchoolId, int yearbookId)
        {
            try
            {
                var user = _mapper.Map<AppUserPerSchool>(User);
                User.Birth.BirthHebrewDate = HebrewDate.GetHebrewJewishDateString(DateTime.Parse(User.Birth.BirthDate.ToString()));
                Tuple<AppUserPerSchool, string, string> tuple = _userRepository.AddUser( user, UserCreatedId, SchoolId, yearbookId);
                return new ReturnObjectOfAddUserDTO() { User = _mapper.Map<SecUserDTO>(tuple.Item1), ID = tuple.Item3, Name = tuple.Item2 };
            }
            catch (Exception )
            {
                return null;
            }


        }

        //עדכון משתמש
        public SecUserDTO UpdateUser(AppUserPerSchoolWithDetailsDTO user, int userId)
        {
            var u = _mapper.Map<AppUserPerSchool>(user);
            u.Birth.BirthHebrewDate = HebrewDate.GetHebrewJewishDateString(DateTime.Parse(user.Birth.BirthDate.ToString()));
            var x = _userRepository.UpdateUser(u, userId);
            var y = _mapper.Map<SecUserDTO>(x);
            y.SchoolId = (int)user.SchoolId;
            return y;
        }

        //מחיקת משתמש
        public int DeleteUser(int UserlID, int SchoolId)
        {
            return _userRepository.DeleteUser(UserlID, SchoolId);
        }

        //שליחת הסיסמא למייל
        public bool SendEmailWithPassword(string emailAddress, string message, string body)
        {
            try
            {
                _MailService.SendEmail(emailAddress, message, body);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
