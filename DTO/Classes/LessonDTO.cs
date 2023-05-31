using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }//מהמערכת היומית הID
        public DateTime Date { get; set; }
        public string hebrewDate { get; set; }
        public bool IsChanges { get; set; }
        public int TeacherId { get; set; }
        public int LessonNumber { get; set; }
        public string LessonName { get; set; }
    }
}
