using System;
using System.Collections.Generic;

#nullable disable

namespace DTO.Classes
{
    public partial class AppTaskToStudentDTO
    {
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

        public bool? IsEdit { get; set; }

        
        public string? studentName { get; set; }
        public string? StudentTz { get; set; }
        public string? PaymentStatusName { get; set; }
        public string? PaymentMethodName { get; set; }
        public string? ReceivePaymentName { get; set; }
        public string? Code { get; set; }
        public virtual List<AppScoreStudentPerQuestionsOfTaskDTO> AppScoreStudentPerQuestionsOfTasks { get; set; }
        public int StatusTaskPerformanceId { get; set; }
        public TStatusTaskPerformanceDTO StatusTaskPerformance { get; set; }

}
}
