using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppTaskToStudent
    {
        public AppTaskToStudent()
        {
            AppScoreStudentPerQuestionsOfTasks = new HashSet<AppScoreStudentPerQuestionsOfTask>();
        }

        public int IdtaskToStudent { get; set; }
        public int? TaskExsistId { get; set; }
        public int? StudentId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateNeedSubmit { get; set; }
        public string DateNeedSubmitStr { get; set; }
        public DateTime? DateSubmit { get; set; }
        public double? Grade { get; set; }
        public int? PaymentStatusId { get; set; }
        public int? PaymentMethodId { get; set; }
        public int? ReceivePaymentId { get; set; }
        public double? AmountReceived { get; set; }
        public string Comment { get; set; }
        public bool? AdministratorApproval { get; set; }
        public int? YearBookId { get; set; }
        public bool? IsActiveTask { get; set; }
        public double? FinalScore { get; set; }
        public int? StatusTaskPerformanceId { get; set; }

        public virtual TPaymentMethod PaymentMethod { get; set; }
        public virtual TPaymentStatus PaymentStatus { get; set; }
        public virtual AppUserPerSchool ReceivePayment { get; set; }
        public virtual TStatusTaskPerformance StatusTaskPerformance { get; set; }
        public virtual AppStudent Student { get; set; }
        public virtual AppTaskExsist TaskExsist { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual AppYearbookPerSchool YearBook { get; set; }
        public virtual ICollection<AppScoreStudentPerQuestionsOfTask> AppScoreStudentPerQuestionsOfTasks { get; set; }
    }
}
