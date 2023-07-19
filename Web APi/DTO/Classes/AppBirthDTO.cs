using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppBirthDTO
    {
        public int Idbirth { get; set; }
        public int? BirthCountryId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthHebrewDate { get; set; }
        public int? CitizenshipId { get; set; }
        public DateTime? DateOfImmigration { get; set; }
        public int? CountryIdofImmigration { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

    }

}
