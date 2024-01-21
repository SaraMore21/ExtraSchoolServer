using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppQuestionsOfTask
    {
        public AppQuestionsOfTask()
        {
            AppScoreStudentPerQuestionsOfTasks = new HashSet<AppScoreStudentPerQuestionsOfTask>();
        }

        public int IdquestionOfTask { get; set; }
        public string Name { get; set; }
        public int? TaskId { get; set; }
        public int? Percent { get; set; }
        public int? Number { get; set; }
        public int? UserCreatedId { get; set; }
        public int? UniqeCodeId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? TypeQuestionId { get; set; }
        public string ContentOfQuestion { get; set; }

        public virtual AppTask Task { get; set; }
        public virtual TabTypeQuestion TypeQuestion { get; set; }
        public virtual AppUniqueCode UniqeCode { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppScoreStudentPerQuestionsOfTask> AppScoreStudentPerQuestionsOfTasks { get; set; }
    }
}
