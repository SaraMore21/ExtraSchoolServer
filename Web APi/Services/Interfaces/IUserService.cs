using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        List<AppUserPerSchoolDTO> GetAllUserBySchoolId(int SchoolId);
        List<SecUserDTO> GetUsersBySchoolIDAndYearbookId(string SchoolsId, int yearbookId);
        AppUserPerSchoolWithDetailsDTO GetUserDetailsByIDUser(int UserId, int SchoolId);
        public List<AppUserPerSchoolWithDetailsDTO> GetListUserDetailsByIDUser(int[][] listuser);
        public ReturnObjectOfAddUserDTO AddUser(AppUserPerSchoolWithDetailsDTO User, int UserCreatedId, int SchoolId, int yearbookId);
        public SecUserDTO UpdateUser(AppUserPerSchoolWithDetailsDTO u, int userId);
        public int DeleteUser(int UserID, int SchoolId);
        public bool SendEmailWithPassword(string emailAddress, string message, string body);

      }
    }
