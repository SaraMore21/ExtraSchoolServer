using AutoMapper;
using DB.Model;
using DB.Repository.Classes;
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
    public class PresenceService : IPresenceService
    {

        private readonly IPresenceRepository _presenceRepository;
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;


        public PresenceService(IPresenceRepository presenceRepository, IMapper mapper,IGroupRepository groupRepository)
        {
            _presenceRepository = presenceRepository;
            _mapper = mapper;
            _groupRepository = groupRepository;

        }

       

        public List<LessonDTO> GetLessonsByDate(DateTime date, int idGroup)
        {
            List<LessonDTO> lessons = _mapper.Map<List<LessonDTO>>(_presenceRepository.GetLessonsByDate(date, idGroup));
            int i = 1;
            lessons.ForEach(lesson =>
            {
                lesson.hebrewDate = HebrewDate.GetHebrewJewishDateString(lesson.Date);
                lesson.Id = i;
                i++;
            });
            return lessons;
        }

        public List<AttendencePerDay> GetNochectByDateIdgroup(DateTime date, int idGroup)
        {
            //GroupRepository gr = new GroupRepository();
            List<AttendencePerDay> attendences = new List<AttendencePerDay>();
            List<AppStudentPerGroupDTO> students = new List<AppStudentPerGroupDTO>();
            List<LessonDTO> lessons = GetLessonsByDate(date, idGroup);
            students = _mapper.Map<List<AppStudentPerGroupDTO>>( _groupRepository.GetStudentPerGroup(idGroup, 0));

            students.ForEach(s =>
            {
                AttendencePerDay attendenceDay = new AttendencePerDay();
                attendenceDay.NochecotPerLesson = new List<AttendancePerLesson>();
                lessons.ForEach(l =>
                {

                    AppPresenceDTO presence = _mapper.Map<AppPresenceDTO>(_presenceRepository.GetPresenceByStudentIdAndSchedualId((int)s.StudentId, l.ScheduleId));
            
                    AttendancePerLesson attendenceLesson = new AttendancePerLesson(l, presence);
                    attendenceDay.NochecotPerLesson.Add(attendenceLesson);
                }
                );
                attendenceDay.idStudent = (int)s.StudentId;
                attendenceDay.nameStudent = s.Student.LastName + " "+ s.Student.FirstName;
                attendenceDay.tz = s.Student.Tz;
                attendenceDay.date = date;
                attendences.Add(attendenceDay);
                
            });


            return attendences;

        }

        public List<AppPresenceDTO> addOrUpdateAttendance(string date, int userId, List<AppPresenceDTO> presences)
        {
            List<AppPresence> t = _presenceRepository.addOrUpdateAttendance(date, userId, _mapper.Map<List<AppPresence>>(presences));
            var a = _mapper.Map<List<AppPresenceDTO>>(t);
            return a;
        }

       
    }
}
