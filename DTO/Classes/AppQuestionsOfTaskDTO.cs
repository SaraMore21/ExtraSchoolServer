using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppQuestionsOfTaskDTO
    {
        public int IdquestionOfTask { get; set; }
        public string Name { get; set; }
        public int? TaskId { get; set; }
        public int? Percent { get; set; }
        public int? Number { get; set; }
        public int? UniqeCodeId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
