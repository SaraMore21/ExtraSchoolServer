using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppCourseDTO
    {
        public int Idcourse { get; set; }
        public string Name { get; set; }
        public int? ProfessionId { get; set; }
        public int? HoursPerWeek { get; set; }
        public int? Hours { get; set; }
        public double? Credits { get; set; }
        public int? Cost { get; set; }
        public double? MinimumScore { get; set; }
        public int? LearningStyleId { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? UniqueCodeId { get; set; }
        public int? YearbookId { get; set; }
        public string Code { get; set; }
        public string? CoordinationCode { get; set; }

        public string SchoolName { get; set; }
        public string ProfessionName { get; set; }
        public string learningStyleName { get; set; }
    }
}
