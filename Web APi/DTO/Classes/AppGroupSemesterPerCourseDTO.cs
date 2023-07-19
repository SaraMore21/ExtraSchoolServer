using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppGroupSemesterPerCourseDTO
    {
        public int IdgroupSemesterPerCourse { get; set; }
        public int? SemesterId { get; set; }
        public int? CourseId { get; set; }
        public int? GroupId { get; set; }
        public string Code { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public int? SchoolId { get; set; }
        public int? YearbookId { get; set; }

        public AppCourseDTO Course { get; set; }
        //public string ProfessionName { get; set; }
        public string GroupName { get; set; }
        public string CourseName { get; set; }
        //public int? BasicGroupId { get; set; }
        public string SemesterName { get; set; }
    }
}
