using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ExcelClasses
{
    public class AppScheduleRegularXL
    {
        [JsonProperty("קוד קורס")]
        public string IDCourse { get; set; }

        [JsonProperty("יום בשבוע")]
        public string DayOfWeek { get; set; }

        [JsonProperty("מספר שיעור")]
        public string NumLesson { get; set; }

        //[JsonProperty("תאריך התחלה")]
        //public string StartDate { get; set; }

        //[JsonProperty("תאריך סיום")]
        //public string EndDate { get; set; }
    }
}