using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IGroupRepository
    {
        bool AddListGroups(List<AppGroup> groups);
        //List<AppGroup> GetGroupsByIdSchool(int SchoolId, int YearbookId);
        List<AppGroupPerYearbook> GetGroupsByIdSchool(string Schools, int YearbookId);
        List<AppStudentPerGroup> GetStudentPerGroup(int GroupId,int YearbookId);
        int DeleteGroup(int GroupId, int YearbookId);
        bool EditGroup(int IdgroupPerYearbook, int UserUpdateId,List<AppUserPerGroup> ListUsersPerGroup);
        AppGroupPerYearbook AddGroup(AppGroup Group, int UserCreatedId, int SchoolId, int YearbookId, int userId);
        List<string> AddStudentInGroup(int GroupId, int StudentId, int YearbookId, string FromDate, string ToDate, int UserCreatedId);
        List<AppGroup> GetAllNameGroup(int SchoolId);
        AppGroupPerYearbook AddGroupInYearbook(int UserId, int GroupId, int YearbookId, int UserCreatedId);
        List<AppUserPerGroup> GetUsersPerGroupByGroupId(int GroupId);
        string GetNameGroupByGroupid(int groupId);
        AppStudentPerGroup DeleteStudentInGroup(int StudentId, int GroupId);
        List<string> EditStudentInGroup(AppStudentPerGroup StudentPerGroup,DateTime FromDate,DateTime ToDate, int UserUpdateId);
        AppGroupPerYearbook IsGroupHasTasks(int groupId);
        AppGroupPerYearbook GetGroupByCourseID(int courseId);
        AppGroup EditGroup2(AppGroup group, int userUpdatedId);
        List<AppGroupPerYearbook> GetGroupsByCoordinationCode(string coordinationCode);
    }
}
