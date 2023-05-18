using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class VCodeTable
    {
        public string Table { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public int? StatusId { get; set; }
    }
}
