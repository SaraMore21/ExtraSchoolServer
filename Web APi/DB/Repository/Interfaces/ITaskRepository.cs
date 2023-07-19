


using DB.Model;
using DB.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface ITaskRepository
    {
        public List<AppTask> GetAllTaskBySchoolId(string SchoolId,int YearbookId);
        AppTask AddOrUpdate(int schoolID, int yearbookId, AppTask appTask);
        bool DeleteTask(int schoolID, int yearbookId, int idTask);
        Tuple<List<AppTask>, List<AppUserPerSchool>,int> AddOrUpdateTasksOfSpecificCodeByCustomer( AppTask appTask, List<SchoolWithYearBookAndUserPerSchool> schools, int YearbookId, int IDcustomer,List<AppQuestionsOfTask> ListQuestion);
    }
}
