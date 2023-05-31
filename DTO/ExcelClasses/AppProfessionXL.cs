using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ExcelClasses
{
    public class AppProfessionXL
    {
        [JsonProperty("שם מקצוע")]
        public string NameProfession { get; set; }

        [JsonProperty("קטגוריה")]
        public string Category { get; set; }

        [JsonProperty("מ.ז. רכז מקצוע")]
        public string CoordinatorTZ { get; set; }
    }
}
