using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class גיליון3
    {
        public double? Idsemester { get; set; }
        public string Name { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string YearbookId { get; set; }
        public string UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
