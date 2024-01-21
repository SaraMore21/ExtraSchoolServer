using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class משתמשים
    {
        public double? IduserPerYearbook { get; set; }
        public double? UserId { get; set; }
        public double? YearbookId { get; set; }
        public double? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public string UserUpdatedId { get; set; }
        public string DateUpdated { get; set; }
    }
}
