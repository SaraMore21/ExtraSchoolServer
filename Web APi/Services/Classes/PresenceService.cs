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


        public PresenceService(IPresenceRepository presenceRepository, IMapper mapper, IGroupRepository groupRepository)
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
                
            });
            return lessons;
        }
        public List<AttendencePerDayDTO> GetNochectByDateIdgroup(DateTime date, int idGroup)
            {
                //GroupRepository gr = new GroupRepository();
                List<AttendencePerDayDTO> attendences = new List<AttendencePerDayDTO>();
                List<AppStudentPerGroupDTO> students = new List<AppStudentPerGroupDTO>();
                List<LessonDTO> lessons = GetLessonsByDate(date, idGroup);
                students = _mapper.Map<List<AppStudentPerGroupDTO>>(_groupRepository.GetStudentPerGroup(idGroup, 0));

                students.ForEach(s =>
                {
                    AttendencePerDayDTO attendenceDay = new AttendencePerDayDTO();
                    attendenceDay.NochecotPerLesson = new List<AttendancePerLessonDTO>();
                    lessons.ForEach(l =>
                    {

                        AppPresenceDTO presence = _mapper.Map<AppPresenceDTO>(_presenceRepository.GetPresenceByStudentIdAndSchedualId((int)s.StudentId, l.ScheduleId));

                        AttendancePerLessonDTO attendenceLesson = new AttendancePerLessonDTO(l, presence);
                        attendenceDay.NochecotPerLesson.Add(attendenceLesson);
                    }
                    );
                    attendenceDay.idStudent = (int)s.StudentId;
                    attendenceDay.nameStudent = s.Student.LastName + " " + s.Student.FirstName;
                    attendenceDay.tz = s.Student.Tz;
                    attendenceDay.date = date;
                    attendences.Add(attendenceDay);

                });


                return attendences;

            }

            public List<AttendencePerDayDTO> GetNochectByDay(DateTime date, int idGroup)
            {
                //GroupRepository gr = new GroupRepository();
                List<AttendencePerDayDTO> attendences = new List<AttendencePerDayDTO>();

                List<PresencePerDayDTO> LstPPDs = _mapper.Map<List<PresencePerDayDTO>>(_presenceRepository.GetPresenceByDay(date, idGroup));
                List<int> lessonsId = new List<int>();
                List<int> studentsId = new List<int>();
                lessonsId = LstPPDs.GroupBy(obj => obj.Lesson.ScheduleId)
                .Select(group => group.Key)
                .ToList();
                studentsId = LstPPDs.GroupBy(obj => obj.IdStudent)
               .Select(group => group.Key)
               .ToList();

              List<PresencePerDayDTO> students = new List<PresencePerDayDTO>();
               studentsId.ForEach(s => {
                   PresencePerDayDTO st = LstPPDs.FirstOrDefault(i => i.IdStudent == s);
                   students.Add(st);
                });





                students.ForEach(st =>
                {
                    AttendencePerDayDTO attendenceDay = new AttendencePerDayDTO();
                    attendenceDay.NochecotPerLesson = new List<AttendancePerLessonDTO>();
                    lessonsId.ForEach(l =>
                    {
                        PresencePerDayDTO PresencePerDay = LstPPDs.FirstOrDefault(o => o.Lesson.ScheduleId == l && o.IdStudent == st.IdStudent);
                        if (PresencePerDay != null)
                        {
                            AppPresenceDTO presence = PresencePerDay.Presence;
                            presence.StudentId = PresencePerDay.IdStudent;
                            presence.DailyScheduleId = PresencePerDay.Lesson.ScheduleId;

                            LessonDTO ld = PresencePerDay.Lesson;
                            AttendancePerLessonDTO attendenceLesson = new AttendancePerLessonDTO(ld, presence);
                            attendenceDay.NochecotPerLesson.Add(attendenceLesson);
                        }
                    }
                        );
                    if (attendenceDay != null)
                    {
                        attendenceDay.idStudent = st.IdStudent;
                        attendenceDay.nameStudent = st.LastName + " " + st.FirstName;
                        attendenceDay.tz = st.Tz;
                        attendenceDay.date = date;
                        attendences.Add(attendenceDay);

                    }

                });


                return attendences;

            }

        public List<AppPresenceDTO> addOrUpdateAttendance(string date, int userId, List<AppPresenceDTO> presences)
        {
            try
            {
                List<AppPresence> t = _presenceRepository.addOrUpdateAttendance(date, userId, _mapper.Map<List<AppPresence>>(presences), null);
                var a = _mapper.Map<List<AppPresenceDTO>>(t);
                return a;
            }
            catch (Exception e)
            {
                string contact_email = "more21soft@gmail.com";
                new MailService().SendEmail(contact_email, "הייתה בעיה בהעלאת הנוכחות:", e.Message + " \nבתאריך\n "+ date);
                return null;
            }


        }


        }
    } 
