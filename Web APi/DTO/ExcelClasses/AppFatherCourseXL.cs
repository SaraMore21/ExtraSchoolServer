using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DTO.ExcelClasses
{
    public class AppFatherCourseXL
    {
        [JsonProperty("שם")]
        public string Name { get; set; }
        [JsonProperty("קוד מקצוע")]
        public string ProfessionId { get; set; }
        [JsonProperty("מס' שעות שבועיות")]
        public int? HoursPerWeek { get; set; }
        [JsonProperty("מס' שעות")]
        public int? Hours { get; set; }
        [JsonProperty("נקודות זיכוי")]
        public double? Credits { get; set; }
        [JsonProperty("מחיר")]
        public int? Cost { get; set; }
        [JsonProperty("ציון מינימלי")]
        public double? MinimumScore { get; set; }
        [JsonProperty("צורת למידה")]
        public string LearningStyleId { get; set; }
        [JsonProperty("קוד")]
        public string Code { get; set; }



    
    }
}
