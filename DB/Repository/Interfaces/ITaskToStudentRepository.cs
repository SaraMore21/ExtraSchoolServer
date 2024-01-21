using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface ITaskToStudentRepository
    {
        public List<AppTaskToStudent> GetAllTaskToStudentByTaskExsistID(int SchoolId, int YearbookId, int TaskExsistID);
        AppTaskToStudent AddOrUpdate(int schoolID, int yearbookId, AppTaskToStudent TaskToStudent);
        bool DeleteTaskToStudent(int schoolID, int yearbookId, int idTaskToStudent);
        bool AddTaskForAllStudentInCourse(int schoolID, int yearbookId, AppTaskExsist AppTaskExsist);
        bool UpdateActiveTask(int schoolID, int taskToStudentId, bool isActive);
        bool EditScoreToStudents(List<AppTaskToStudent> ListTaskToStudent);
        List<AppScoreStudentPerQuestionsOfTask> GetScoreStudentInQuestionOfTask(int QuestionId);
        List<AppScoreStudentPerQuestionsOfTask> EditScoreQuestionToStudents(List<AppScoreStudentPerQuestionsOfTask> ListScoreQuestionPerStudent);

        void UpdateScoreStudentPerQuestions(List<AppScoreStudentPerQuestionsOfTask> appScoreStudentPerQuestionsOfTasks);
    }
}
