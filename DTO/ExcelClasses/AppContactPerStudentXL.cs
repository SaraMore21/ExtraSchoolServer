using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ExcelClasses
{
    public class AppContactPerStudentXL
    {
        [JsonProperty("מספר זיהוי תלמידה")]
        public string StudentTZ { get; set; }  
        [JsonProperty("מספר זיהוי איש קשר")]
        public string ContactTZ { get; set; }
        [JsonProperty("סוג זיהוי")]
        public string TypeIdentity { get; set; }
        [JsonProperty("סוג קשר")]
        public string TypeContact { get; set; }
        [JsonProperty("פרטי")]
        public string FirstName { get; set; }
        [JsonProperty("משפחה")]
        public string LastName { get; set; }

        //
        [JsonProperty("עיר")]
        public string City { get; set; }
        [JsonProperty("שכונה")]
        public string Neighborhood { get; set; }
        [JsonProperty("רחוב")]
        public string Street { get; set; }
        [JsonProperty("בנין")]
        public string BuildingNum { get; set; }
        [JsonProperty("דירה")]
        public string HouseNum { get; set; }
        [JsonProperty("ת.ד.")]
        public string MailBox { get; set; }
        [JsonProperty("מיקוד")]
        public string Zip { get; set; }

        //
        [JsonProperty("טלפון1")]
        public string Telehone1 { get; set; }
        [JsonProperty("טלפון2")]
        public string Telehone2 { get; set; }
        [JsonProperty("נייד1")]
        public string Mobile1 { get; set; }
        [JsonProperty("נייד2")]
        public string Mobile2 { get; set; }
        [JsonProperty("נייד3")]
        public string Mobile3 { get; set; }
        [JsonProperty("מייל")]
        public string Mail { get; set; }
        [JsonProperty("פקס")]
        public string Fax { get; set; }


        [JsonProperty("הערה")]
        public string Comment { get; set; }
        [JsonProperty("עיסוק")]
        public string Job { get; set; }

    }
}
