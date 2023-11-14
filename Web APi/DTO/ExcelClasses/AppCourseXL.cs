using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace DTO.ExcelClasses
{
    public class AppCourseXL
    {

        [JsonProperty("קוד סמסטר")]
        public string SemesterId { get; set; }
        [JsonProperty("קוד קורס אב")]
        public string CourseId { get; set; }
        [JsonProperty("קוד קבוצה")]
        public string GroupId { get; set; }
        [JsonProperty("קוד")]
        public string Code { get; set; }
        [JsonProperty("תז מורה")]
        public string teacherTz { get; set; }
        [JsonProperty("מתאריך")]
        public string fromDate { get; set; }
        [JsonProperty("עד תאריך")]
        public string toDate { get; set; }

    }
}







