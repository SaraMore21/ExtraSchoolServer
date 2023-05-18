using DB.Model;
using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class LessonPerGroupRepository : ILessonPerGroupRepository
    {
        private readonly ExtraSchoolContext _context;

        public LessonPerGroupRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public AppLessonPerGroup LessonPerGroupByGroupIdAndDayOfWeekAndNumLesson(short? dayOfWeek, short? NumLesson, int GroupId)
        {
            try
            {

                var s = _context.AppLessonPerGroups.FirstOrDefault(f => f.GroupId == GroupId && f.DayOfWeek == dayOfWeek && f.NumLesson == NumLesson);
                return s;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public AppLessonPerGroup addOrUpdateLessonPerGroup(int userId, AppLessonPerGroup LessonPerGroup)
        {
           
            {
                if (LessonPerGroup.IdlessonPerGroup == 0 || LessonPerGroup.IdlessonPerGroup == null)
                {
                    LessonPerGroup.DateCreated = DateTime.Now;
                    LessonPerGroup.UserCreatedId = userId;
                    
                    _context.AppLessonPerGroups.Add(LessonPerGroup);
                }
           

                
        //public int IdlessonPerGroup { get; set; }
        //public int? GroupId { get; set; }
        //public short? DayOfWeek { get; set; }
        //public short? NumLesson { get; set; }
        //public TimeSpan? StartTime { get; set; }
        //public TimeSpan? EndTime { get; set; }
        //public int? UserCreatedId { get; set; }
        //public DateTime? DateCreated { get; set; }
        //public int? UserUpdatedId { get; set; }
        //public DateTime? DateUpdated { get; set; }

                else
                {
                    var x = _context.AppLessonPerGroups.FirstOrDefault(pr => pr.IdlessonPerGroup == LessonPerGroup.IdlessonPerGroup);
                    if (x != null)
                    {
                      
                        x.IdlessonPerGroup = LessonPerGroup.IdlessonPerGroup;
                        x.GroupId = LessonPerGroup.GroupId;
                        x.DayOfWeek = LessonPerGroup.DayOfWeek;
                        x.NumLesson = LessonPerGroup.NumLesson;
                        x.StartTime = LessonPerGroup.StartTime;
                        x.EndTime = LessonPerGroup.EndTime;
                        x.UserUpdatedId = userId;
                        x.DateUpdated = DateTime.Now;

                    }
                }

            };
            _context.SaveChanges();
            //presences = _context.AppPresences.Include(i => i.DailySchedule).Include(i => i.Student).Include(i => i.TypePresence).Include(i => i.UserCreated).Include(i => i.UserCreated);

            return LessonPerGroup;

        }


    }
}

