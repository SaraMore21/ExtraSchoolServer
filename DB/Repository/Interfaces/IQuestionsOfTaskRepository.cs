using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IQuestionsOfTaskRepository
    {
        List<AppQuestionsOfTask> AddQuestionsOfTask(List<AppQuestionsOfTask> ListQuestion, int taskId);
        List<AppQuestionsOfTask> UpdateQuestionOfTask(List<AppQuestionsOfTask> ListQuestion, int taskId, bool isCoordination,int UserId);
        List<AppQuestionsOfTask> GetQuestionOfTask(int TaskId);

    }
}
