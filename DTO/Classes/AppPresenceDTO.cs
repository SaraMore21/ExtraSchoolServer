using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppPresenceDTO
    {
        public int Idpresence { get; set; }
        public int DailyScheduleId { get; set; }
        public int StudentId { get; set; }
        public short? TypePresenceId { get; set; }
        public short? Writeby { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public string TypePresenceName { get; set; }



    }
}
