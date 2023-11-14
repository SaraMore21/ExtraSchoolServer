using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DTO.Classes;

namespace Services.Interfaces
{
    public interface IStudentService
    {
        List<AppStudentDTO> GetListStudentsBySchoolId(int schoolId);
        bool DeleteStudent(int SchoolID);
        AppStudentWhithDetailsDTO GetStudentDetailsByIDStudent(int StudetID);
        ReturnObjectOfAddStudentDTO AddStudent(AppStudentWhithDetailsDTO student,int UserCreatedId,int SchoolId,int YearbookId);
        AppStudentDTO UpdateStudent(AppStudentWhithDetailsDTO student ,int UserCreatedId, int SchoolId);
        bool UpdateProfilePathToStudent(int idStudent, string path, int SchoolId, int Userid);
        List<AppStudentDTO> GetListStudentsBySchoolIdAndYearbookId(string SchoolsId, int YearbookId);
        List<GroupWithCourseDTO> GetGroupsToStudent(int StudentId, int YearbookId);
        AppStudentPerGroupDTO DeleteGroupToStudent(int StudentPerGroupId);
        Tuple<bool, string, GroupWithCourseDTO, List<AppTaskExsistDTO>> AddGroupPerStudent(AppStudentPerGroupDTO StudentPerGroup);
        bool AddTasksToStudent(List<AppTaskExsistDTO> ListTaskExsist, int StudentId, int UserCreatedId);
        AppStudentPerGroupDTO GetStudentPerGroupById(int StudentPerGroupId);
        List<TReasonForLeavingDTO> GetReasonForLeavingPerSchool(int SchoolId);
        List<AppStudentDTO> GetPartlyListStudent(int page, int pageSize, int YearbookId, string SchoolsId);
        List<AppStudentDTO> SearchInStudentList(string str, int YearbookId, string SchoolsId);
    }
}
