using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;

namespace DB.Repository.Interfaces
{

    public interface IStudentRepository
    {
        List<AppStudent> GetListStudentsBySchoolId(int SchoolId);
        bool AddListStudents(List<AppStudent> students, int SchoolId);
        bool DeleteStudent(int StudentID);
        AppStudent GetStudentDetailsByIDStudent(int StudentID);
        List<string> AddStudent(AppStudent student, int UserCreatedId, int SchoolId, int YearbookId);
        AppStudent AddStudent1(AppStudent student, int UserCreatedId, int SchoolId, int idyearbookPerSchool);
        Task<AppStudent> IsStudentExsist(AppStudent stud, int schoolId);
        AppStudent updateStudent(AppStudent s, int SchoolId, int userId, int idyearbookPerSchool=0);
        void UpdateStudent1(AppStudent s, int SchoolId, int userId);
        AppStudent Clone(AppStudent student);
        bool UpdateProfilePathToStudent(int idStudent, string path, int SchoolId, int Userid);
        List<AppStudent> GetListStudentsBySchoolIdAndYearbookId(string SchoolsId, int YearbookId);
        List<AppStudentPerGroup> GetGroupsToStudent(int StudentId, int YearbookId);
        AppStudentPerGroup DeleteGroupToStudent(int StudentPerGroupId);
        Tuple<bool, string, AppStudentPerGroup> AddGroupPerStudent(AppStudentPerGroup StudentPerGroup);
        bool AddTasksToStudent(List<AppTaskToStudent> listTaskToStudent);
        int? getNumRequiredPerStudent(int schoolId);
        AppStudent IsStudentExsist(string tz, int schoolId);
        List<TReasonForLeaving> GetReasonForLeavingPerSchool(int SchoolId);
        public List<AppStudent> GetPartlyListStudent(int page, int pageSize, int YearbookId, string SchoolsId);
        public List<AppStudent> SearchInStudentList(string str, int YearbookId, string SchoolsId);
    }

}
