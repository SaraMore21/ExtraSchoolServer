using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITaskExsistService
    {
        public List<AppTaskExsistDTO> GetAllTaskBySchoolId(int tasxExsistId);
        AppTaskExsistDTO AddOrUpdate(int schoolID, int yearbookId, AppTaskExsistDTO taskExsistDTO);
        bool DeleteTask(int idTaskExsist, bool deleteTaskToStudents);
        public int getSumPercentsOfCourse(int? CourseId, int  tasxExsistId);

    }
}
