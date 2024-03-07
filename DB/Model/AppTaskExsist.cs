using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppTaskExsist
    {
        public AppTaskExsist()
        {
            AppDocumentPerTaskExsists = new HashSet<AppDocumentPerTaskExsist>();
            AppTaskToStudents = new HashSet<AppTaskToStudent>();
        }

        public int IdexsistTask { get; set; }
        public int? TaskId { get; set; }
        public DateTime? DateSubmitA { get; set; }
        public DateTime? DateSubmitB { get; set; }
        public DateTime? DateSubmitC { get; set; }
        public int? Percents { get; set; }
        public double? PassingGrade { get; set; }
        public double? Cost { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? SchoolId { get; set; }
        public int? CoordinatorId { get; set; }
        public int? YearBookId { get; set; }
        public string Name { get; set; }
        public string CodeTaskExsist { get; set; }
        public int? CourseId { get; set; }

        public virtual AppUserPerSchool Coordinator { get; set; }
        public virtual AppGroupSemesterPerCourse Course { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual AppTask Task { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual AppYearbookPerSchool YearBook { get; set; }
        public virtual ICollection<AppDocumentPerTaskExsist> AppDocumentPerTaskExsists { get; set; }
        public virtual ICollection<AppTaskToStudent> AppTaskToStudents { get; set; }
    }
}
