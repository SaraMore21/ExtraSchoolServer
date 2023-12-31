﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Repository.Classes;
using DTO.Classes;

namespace Services.Interfaces
{
    public interface IPresenceService
    {
        public List<LessonDTO> GetLessonsByDate(DateTime date, int idGroup);
        public List<AttendencePerDay> GetNochectByDateIdgroup(DateTime date, int idGroup);
        public List<AppPresenceDTO> addOrUpdateAttendance(string date, int userId, List<AppPresenceDTO> presences);
    }
}
