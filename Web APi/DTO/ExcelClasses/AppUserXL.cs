using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ExcelClasses
{
    public class AppUserXL
    {
        [JsonProperty("מספר זיהוי")]
        public string Tz { get; set; }
        [JsonProperty("סוג זיהוי")]
        public string TypeIdentity { get; set; }
        [JsonProperty("פרטי")]
        public string FirstName { get; set; }
        [JsonProperty("משפחה")]
        public string LastName { get; set; }
        [JsonProperty("מין")]
        public string Gender { get; set; }
        [JsonProperty("תאריך לידה לועזי")]
        public string BirthDate { get; set; }
        [JsonProperty("תאריך עברי")]
        public string BirthHebrewDate { get; set; }
        [JsonProperty("ארץ לידה")]
        public string BirthCountryId { get; set; }
        [JsonProperty("אזרחות")]
        public string Citizenship { get; set; }
        [JsonProperty("תאריך עליה")]
        public string DateOfImmigration { get; set; }
        [JsonProperty("ארץ עליה")]
        public string CountryIdofImmigration { get; set; }
        [JsonProperty("פרטי בלועזית")]
        public string ForeignFirstName { get; set; }
        [JsonProperty("משפחה בלועזית")]
        public string ForeignLastName { get; set; }
        [JsonProperty("שם משפחה קודם")]
        public string PreviusName { get; set; }
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

        //
        [JsonProperty("עיר")]
        public string City { get; set; }
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

        [JsonProperty("פעיל")]
        public string IsActive { get; set; }

       
        [JsonProperty("הערה")]
        public string Note { get; set; }

    }
}
