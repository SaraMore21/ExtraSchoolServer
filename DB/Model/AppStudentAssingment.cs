using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppStudentAssingment
    {
        public AppStudentAssingment()
        {
            AppAppeals = new HashSet<AppAppeal>();
        }

        public int IdstudentAssingment { get; set; }
        public int? AssingmentId { get; set; }
        public int? DeadlineId { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public double? Grade { get; set; }
        public int? PaymentStatusId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? ReceivingPaymentId { get; set; }
        public bool? FinalGrade { get; set; }
        public string NoteGrade { get; set; }
        public bool? ApprovalGradeByManager { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AppCourseAssignment Assingment { get; set; }
        public virtual TTypeDeadLine Deadline { get; set; }
        public virtual TPaymentMethod PaymentMethod { get; set; }
        public virtual TPaymentStatus PaymentStatus { get; set; }
        public virtual AppUserPerSchool ReceivingPayment { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppAppeal> AppAppeals { get; set; }
    }
}
