using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface ITaskExsistRepository
    {
        List<AppTaskExsist> GetAllTaskExsistByTaskId(int taskId);
        AppTaskExsist AddOrUpdate(int schoolID, int yearbookId, AppTaskExsist AppTaskExsist);
        bool DeleteTaskExsist(int idTaskExsist, bool deleteTaskToStudents);
        int getSumPercentsOfCourse(int? CourseId, int taskId);
        List<AppTaskExsist> GetTaskExsistByTaskId(int taskId);
        List<AppTaskExsist> GetTaskExsistByGroupId(int GroupPerYearbookId);

    }
}
