using AutoMapper;
using DB.Repository.Interfaces;
using DTO.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;

namespace Services.Classes
{
    public class ScheduleRegularService : IScheduleRegularService
    {
        private readonly IScheduleRegularRepository _scheduleRegularRepository;
        private readonly IMapper _mapper;
        public ScheduleRegularService(IScheduleRegularRepository scheduleRegularRepository,IMapper mapper)
        {
            _mapper = mapper;
            _scheduleRegularRepository = scheduleRegularRepository;
        }

        //שליפת מערכת קבועה לשבוע -לפי תאריך וקבוצה
        public IEnumerable<IGrouping<short?, AppScheduleRegularDTO>> GetScheduleRegularPerWeek(DateTime ScheduleDate, int GroupId)
        {
            var x = _mapper.Map<List<AppScheduleRegularDTO>>(_scheduleRegularRepository.GetScheduleRegularPerWeek(ScheduleDate, GroupId)).OrderBy(o => o.NumLesson);
            return x.GroupBy(g => g.DayOfWeek);
        }

        public AppScheduleRegularDTO UpdateScheduleRegularByWebsite(AppScheduleRegularDTO ScheduleRegular, int userId,DateTime date)
        {
            return _mapper.Map<AppScheduleRegularDTO>(_scheduleRegularRepository.UpdateScheduleRegularByWebsite(_mapper.Map<AppScheduleRegular>( ScheduleRegular), userId,date));
        }
    }
}
