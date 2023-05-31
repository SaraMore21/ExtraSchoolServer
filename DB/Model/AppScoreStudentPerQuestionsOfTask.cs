using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppScoreStudentPerQuestionsOfTask
    {
        public int IdscoreStudentPerQuestionsOfTask { get; set; }
        public int? TaskToStudentId { get; set; }
        public int? QuestionOfTaskId { get; set; }
        public double? Score { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UserUpdatedId { get; set; }

        public virtual AppQuestionsOfTask QuestionOfTask { get; set; }
        public virtual AppTaskToStudent TaskToStudent { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
