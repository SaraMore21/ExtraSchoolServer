using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppScoreStudentPerQuestionsOfTaskDTO
    {
        public int IdscoreStudentPerQuestionsOfTask { get; set; }
        public int? TaskToStudentId { get; set; }
        public int? QuestionOfTaskId { get; set; }
        public double? Score { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UserUpdatedId { get; set; }

        public string Name { get; set; }
        public int? Percent { get; set; }
        public int? Number { get; set; }


        public string StudentName { get; set; }
        public string StudentTz { get; set; }
        public string Code { get; set; }
    }
}
