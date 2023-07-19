using AutoMapper;
using DB.Model;
using DB.Repository.Interfaces;
using DTO.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class DailyScheduleService : IDailyScheduleService
    {
        private readonly IDailyScheduleRepository _DailyScheduleRepository;
        private readonly IMapper _mapper;
        public DailyScheduleService(IDailyScheduleRepository dailyScheduleRepository, IMapper mapper)
        {
            _DailyScheduleRepository = dailyScheduleRepository;
            _mapper = mapper;
        }
        //שליפת המורות הפנויות לפי נתוני שיעור ספציפי במוסד
        public List<SecUserDTO> GetAvailableTeachers(DateTime scheduleDate, int numLesson, int SchoolId, int CourseId)
        {
            return _mapper.Map<List<SecUserDTO>>(_DailyScheduleRepository.GetAvailableTeachers(scheduleDate, numLesson, SchoolId, CourseId));
        }
        //שליפת המורות הפנויות לפי טווח שעות ושאר נתוני השיעור
        public List<SecUserDTO> GetAvailableTeachersByHourRange(DateTime ScheduleDate, TimeSpan FromTime, TimeSpan ToTime, int SchoolId, int CourseId)
        {
            return _mapper.Map<List<SecUserDTO>>(_DailyScheduleRepository.GetAvailableTeachersByHourRange(ScheduleDate, FromTime, ToTime, SchoolId, CourseId));
        }
       
        //שליפת מספרי השיעורים הפנויים לקבוצה בתאריך
        public List<AppLessonPerGroupDTO> GetNumLessonAvailable(int GroupId, DateTime ScheduleDate)
        {
            return _mapper.Map<List<AppLessonPerGroupDTO>>(_DailyScheduleRepository.GetNumLessonAvailable(GroupId, ScheduleDate));
        }
        //שליפת מורה לפי הקורס הנבחר
        public SecUserDTO GetTeacherBySelectCourse(int GroupSemesterPerCourseId, DateTime scheduleDate)
        {
            var u = _DailyScheduleRepository.GetTeacherBySelectCourse(GroupSemesterPerCourseId, scheduleDate);
            return _mapper.Map<SecUserDTO>(u);
        }
        //שליפת מערכת יומית לקבוצה בתאריך
        public List<AppDailyScheduleDTO> GetDailySchedulePerGroup(int GroupId, DateTime ScheduleDate)
        {
            var X = _DailyScheduleRepository.GetDailySchedulePerGroup(GroupId, ScheduleDate);
            return _mapper.Map<List<AppDailyScheduleDTO>>(X);
        }
        //עריכת מערכת יומית-שמירת פרטי השיעור 
        public AppDailyScheduleDTO EditDailySchedule(AppDailyScheduleDTO DailySchedule)
        {
            return _mapper.Map<AppDailyScheduleDTO>(_DailyScheduleRepository.EditDailySchedule(_mapper.Map<AppDailySchedule>(DailySchedule)));
        }
        //הוספת מערכת יומית
        public Tuple<AppDailyScheduleDTO, string> AddDailySchedule(AppDailyScheduleDTO DailySchedule)
        {
            var result = _DailyScheduleRepository.AddDailySchedule(_mapper.Map<AppDailySchedule>(DailySchedule));
            return Tuple.Create(_mapper.Map<AppDailyScheduleDTO>(result.Item1),result.Item2);
        }
        //שליפת נתוני מערכת יומית לפי מערכת קבועה 
        public Tuple<AppGroupSemesterPerCourseDTO, AppUserPerSchoolDTO,int> GetDailyScheduleDetailsByScheduleRegular(int GroupId, DateTime ScheduleDate, TimeSpan StartTime, TimeSpan EndTime)
        {
            var result = _DailyScheduleRepository.GetDailyScheduleDetailsByScheduleRegular(GroupId, ScheduleDate, StartTime, EndTime);
            if (result == null) return null;
            return Tuple.Create(_mapper.Map<AppGroupSemesterPerCourseDTO>(result.Item1), _mapper.Map<AppUserPerSchoolDTO>(result.Item2),result.Item3);
        }
        //מחיקת מערכת יומית
        public bool DeleteDailySchedule(int IdDailySchedule)
        {
            return _DailyScheduleRepository.DeleteDailySchedule(IdDailySchedule);
        }
    }
}
