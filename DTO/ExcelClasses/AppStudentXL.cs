using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Classes;

namespace DTO.ExcelClasses
{
    public class AppStudentXL
    {
        [JsonProperty("מספר זיהוי")]
        public string Tz { get; set; }
        [JsonProperty("סוג זיהוי")]
        public string TypeIdentity { get; set; }
        [JsonProperty("קוד")]
        public string Code { get; set; }
        [JsonProperty("פרטי")]
        public string FirstName { get; set; }
        [JsonProperty("משפחה")]
        public string LastName { get; set; }
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
        [JsonProperty("מין")]
        public string Gender { get; set; }
        [JsonProperty("מצב משפחתי")]
        public string Status { get; set; }
        [JsonProperty("פרטי בלועזית")]
        public string ForeignFirstName { get; set; }
        [JsonProperty("משפחה בלועזית")]
        public string ForeignLastName { get; set; }
        [JsonProperty("שם משפחה קודם")]
        public string PreviusName { get; set; }
        [JsonProperty("מספר זיהוי אב")]
        public string FatherTz { get; set; }
        [JsonProperty("סוג זיהוי אב")]
        public string FatherTypeIdentity { get; set; }
        [JsonProperty("מספר זיהוי אם")]
        public string MotherTz { get; set; }
        [JsonProperty("סוג זיהוי אם")]
        public string MotherTypeIdentity { get; set; }
        [JsonProperty("מספר זיהוי אפוטרופוס")]
        public string ApotropusTz { get; set; }
        [JsonProperty("סוג זיהוי אפוטרופוס")]
        public string ApotropusTypeIdentity { get; set; }
        [JsonProperty("פעיל")]
        public string IsActive { get; set; }
        [JsonProperty("סטטוס תלמידה")]
        public string StatusStudentId { get; set; }
        [JsonProperty("סיבה")]
        public string ReasonForLeaving { get; set; }

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


        [JsonProperty("פרטים נוספים")]
        public string AnatherDetails { get; set; }
        [JsonProperty("הערה")]
        public string Note { get; set; }
        [JsonProperty("שדה 1")]
        public string Field1 { get; set; }
        [JsonProperty("שדה 2")]
        public string Field2 { get; set; }
        [JsonProperty("שדה 3")]
        public string Field3 { get; set; }
        [JsonProperty("שדה 4")]
        public string Field4 { get; set; }
        [JsonProperty("שדה 5")]
        public string Field5 { get; set; }

    }
}
