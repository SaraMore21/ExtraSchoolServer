using System;
using System.Collections.Generic;

#nullable disable

namespace DTO.Classes
{
    public partial class AppTaskExsistDTO
    {

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
        public int? PercentsCourse { get; set; }


        public string? CourseName { get; set; }
        public string? CoordinatorName { get; set; }

    }
}
