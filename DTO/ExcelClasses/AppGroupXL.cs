using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ExcelClasses
{
    public class AppGroupXL
    {
        [JsonProperty("שם קבוצה")]
        public string nameGroup { get; set; }

        [JsonProperty("שכבת גיל")]
        public string AgeGroup{ get; set; }

        [JsonProperty("שנתון")]
        public string YearBook { get; set; }

        [JsonProperty("סוג קבוצה")]
        public string TypeGroup { get; set; }

        [JsonProperty("מ.ז. ראש קבוצה")]
        public string UserId { get; set; }
    }
}
