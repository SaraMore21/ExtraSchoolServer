using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface ILessonPerGroupRepository
    {
         AppLessonPerGroup LessonPerGroupByGroupIdAndDayOfWeekAndNumLesson(short? dayOfWeek, short? NumLesson, int GroupId);
         AppLessonPerGroup addOrUpdateLessonPerGroup(int userId, AppLessonPerGroup LessonPerGroup);

    }
}
