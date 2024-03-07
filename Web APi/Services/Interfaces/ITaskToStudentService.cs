using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITaskToStudentService
    {
        public List<AppTaskToStudentDTO> GetAllTaskToStudentByTaskExsistID(int tasxExsistId, int schoolID, int yearbookId);
        AppTaskToStudentDTO AddOrUpdate(int schoolID, int yearbookId, AppTaskToStudentDTO TaskToStudent,bool isAotomat,int courseid);
        bool DeleteTaskToStudent(int schoolID, int yearbookId, int idTaskExsist);
        bool UpdateActiveTask(int schoolID, int taskToStudentId, bool isActive);
        bool EditScoreToStudents(List<AppTaskToStudentDTO> ListTaskToStudent);
        List<AppScoreStudentPerQuestionsOfTaskDTO> GetScoreStudentInQuestionOfTask(int QuestionId);
        List<AppScoreStudentPerQuestionsOfTaskDTO> EditScoreQuestionToStudents(List<AppScoreStudentPerQuestionsOfTaskDTO> ListScoreQuestionPerStudent);
    }
}
