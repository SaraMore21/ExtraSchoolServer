using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppTaskDTO
    {
        public int Idtask { get; set; }
        public string NameEnglish { get; set; }
        public string Name { get; set; }
        public int? TypeTaskId { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }
        public string CodeTask { get; set; }
        public int? YearBookId { get; set; }
        public int? CoordinatorId { get; set; }
        public int? TypeOfTaskCalculationId { get; set; }

        public string CoordinatorName { get; set; }
        public string typeTaskName { get; set; }
        public string checkTypeName { get; set; }
        public string TypeOfTaskCalculationName { get; set; }
        public int? UniqueCodeId { get; set; }
        public int? CoordinationTypeId { get; set; }

        public string SchoolName { get; set; }
        public int checkTypeId { get; set; }

        public List<AppQuestionsOfTaskDTO> ListQuestion { get; set; }
    }
}
