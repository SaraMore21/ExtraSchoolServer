using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TTypeLearning
    {
        public TTypeLearning()
        {
            AppDailySchedules = new HashSet<AppDailySchedule>();
        }

        public short IdtypeLearning { get; set; }
        public string TypeLearningDes { get; set; }

        public virtual ICollection<AppDailySchedule> AppDailySchedules { get; set; }
    }
}
