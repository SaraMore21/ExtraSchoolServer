using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppTask
    {
        public AppTask()
        {
            AppDocumentPerTasks = new HashSet<AppDocumentPerTask>();
            AppQuestionsOfTasks = new HashSet<AppQuestionsOfTask>();
            AppTaskExsists = new HashSet<AppTaskExsist>();
        }

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
        public int? UniqueCodeId { get; set; }
        public int? TypeOfTaskCalculationId { get; set; }
        public int? ExecutionTypeOfTaskId { get; set; }
        public int? CheckTypeId { get; set; }
        public int? CoordinationTypeId { get; set; }

        public virtual TCheckType CheckType { get; set; }
        public virtual AppCoordinationType CoordinationType { get; set; }
        public virtual AppUserPerSchool Coordinator { get; set; }
        public virtual TabExecutionTypeOfTask ExecutionTypeOfTask { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual TabTypeOfTaskCalculation TypeOfTaskCalculation { get; set; }
        public virtual TabTypeTask TypeTask { get; set; }
        public virtual AppUniqueCode UniqueCode { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual AppYearbookPerSchool YearBook { get; set; }
        public virtual ICollection<AppDocumentPerTask> AppDocumentPerTasks { get; set; }
        public virtual ICollection<AppQuestionsOfTask> AppQuestionsOfTasks { get; set; }
        public virtual ICollection<AppTaskExsist> AppTaskExsists { get; set; }
    }
}
