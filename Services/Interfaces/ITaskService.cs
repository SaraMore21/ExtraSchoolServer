using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITaskService
    {
        public List<AppTaskDTO> GetAllTaskBySchoolId(string SchoolsId,int YearbookId);
        AppTaskDTO AddOrUpdate(int schoolID, int yearbookId, AppTaskDTO taskDTO);
        bool DeleteTask(int schoolID, int yearbookId, int idTask);
        Tuple<List<AppTaskDTO>, List<SecUserDTO>, AppUserPerSchoolWithDetailsDTO, int> AddOrUpdateTasksOfSpecificCodeByCustomer( AppTaskDTO taskDTO, List<AppSchoolWhithYearbookDTO> listSchool, int yearbookId, int IDcustomer);
    }
}
