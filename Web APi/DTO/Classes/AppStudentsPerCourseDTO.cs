using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
        public partial class AppStudentsPerCourseDTO
        {
            public int IdstudentsPerCourse { get; set; }
            public int? StudentId { get; set; }
            public int? GroupSemesterperCourseId { get; set; }
            public DateTime? FromDate { get; set; }
            public DateTime? ToDate { get; set; }
            public double? Grade { get; set; }
            public double? FinalScore { get; set; }
            public int? UserCreatedId { get; set; }
            public DateTime? DateCreated { get; set; }
            public int? UserUpdatedId { get; set; }
            public DateTime? DateUpdated { get; set; }


            public string? StudentName { get; set; }
            public string? StudentTz { get; set; }

        }
    
}
