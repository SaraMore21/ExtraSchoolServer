using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IScheduleRegularService
    {
        IEnumerable<IGrouping<short?, AppScheduleRegularDTO>> GetScheduleRegularPerWeek(DateTime ScheduleDate, int GroupId);
        AppScheduleRegularDTO UpdateScheduleRegularByWebsite(AppScheduleRegularDTO ScheduleRegular,int userId,DateTime date);
    }
}
