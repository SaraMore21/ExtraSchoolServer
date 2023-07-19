using DTO;
using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IGroupService
    {
        List<AppGroupPerYearbookDTO> GetGroupsByIdSchool(string Schools, int YearbookId);
        List<AppStudentPerGroupDTO> GetStudentPerGroup(int GroupId,int YearbookId);
        int DeleteGroup(int GroupId, int YearbookId);
        bool EditGroup(int IdgroupPerYearbook, int UserUpdateId, List<AppUserPerGroupDTO> ListUsersPerGroup);
        AppGroupPerYearbookDTO AddGroup(AppGroupDTO Group,int UserCreatedId, int SchoolId, int YearbookId, int userId);
        List<AppGroupPerYearbookDTO> AddCoordinatedGroup(AppGroupDTO Group, int UserCreatedId, int YearbookId, int userId);
        ReturnObjectOfAddStudentDTO AddStudentInGroup(int GroupId, int StudentId, int YearbookId, string FromDate, string ToDate, int UserCreatedId);
        List<AppGroupDTO> GetAllNameGroup(int SchoolId);
        AppGroupPerYearbookDTO AddGroupInYearbook(int UserId, int GroupId, int YearbookId, int UserCreatedId);
        List<AppUserPerGroupDTO> GetUsersPerGroupByGroupId(int GroupId);
        AppStudentPerGroupDTO DeleteStudentInGroup(int StudentId, int GroupId);
        ReturnObjectOfStudentPerGroupDTO EditStudentInGroup(AppStudentPerGroupDTO StudentPerGroup,DateTime FromDate,DateTime ToDate, int UserUpdateId);
        AppGroupDTO EditGroup2(AppGroupDTO group, int userUpdatedId);
        List<AppGroupPerYearbookDTO> GetGroupsByCoordinationCode(string coordinationCode);
    }
}
