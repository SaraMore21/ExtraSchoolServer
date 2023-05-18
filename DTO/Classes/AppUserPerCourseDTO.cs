using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppUserPerCourseDTO
    {
        public int IduserPerCourse { get; set; }
        public int? GroupSemesterPerCourseId { get; set; }
        public int? UserId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? UserCreatedId { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateCreated { get; set; }

        public SecUserDTO User { get; set; }
    }
}
