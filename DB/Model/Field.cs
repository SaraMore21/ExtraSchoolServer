using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class Field
    {
        public short FieldId { get; set; }
        public string FieldName { get; set; }
        public int Table { get; set; }
        public int Type { get; set; }
    }
}
