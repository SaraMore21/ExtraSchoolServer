using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ExcelClasses
{
    public class AppStudentPerGroupXL
    {
        [JsonProperty("מספר זיהוי")]
        public string Tz { get; set; }

        [JsonProperty("קבוצה")]
        public string IdGroup { get; set; }

        [JsonProperty("תאריך תחילה")]
        public string StartDate { get; set; }

        [JsonProperty("תאריך סיום")]
        public string EndDate { get; set; }
    }
}
