using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppAddressDTO
    {
        public int Idaddress { get; set; }
        public int? CityId { get; set; }
        public int? StreetId { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public int? PoBox { get; set; }
        public int? ZipCode { get; set; }
      //  public int? NeighborhoodId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Comment { get; set; }
    }
}