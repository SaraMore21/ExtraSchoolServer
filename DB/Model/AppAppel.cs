using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppAppel
    {
        public int Idappeal { get; set; }
        public int? IdstudentAssingment { get; set; }
        public int? IdstatusAppeal { get; set; }
        public int? Iddocument { get; set; }
        public string Massege { get; set; }
        public int? Idschool { get; set; }
        public int? Idcreater { get; set; }
        public DateTime? DateCreate { get; set; }

        public virtual SecUser IdcreaterNavigation { get; set; }
        public virtual AppSchool IdschoolNavigation { get; set; }
        public virtual TStatusAppel IdstatusAppealNavigation { get; set; }
        public virtual AppStudentAssingment IdstudentAssingmentNavigation { get; set; }
    }
}
