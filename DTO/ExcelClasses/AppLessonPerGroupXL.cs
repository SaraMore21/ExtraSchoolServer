using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ExcelClasses
{
    public class AppLessonPerGroupXL
    {
        [JsonProperty("מס קבוצה")]
        public string GroupId { get; set; }

        [JsonProperty("יום בשבוע")]
        public string DayOfWeek { get; set; }

        [JsonProperty("מס שיעור")]
        public string NumLesson { get; set; }

        [JsonProperty("שעת התחלה")]
        public string StartTime { get; set; }

        [JsonProperty("שעת סיום")]
        public string EndTime { get; set; }
    }
}

    