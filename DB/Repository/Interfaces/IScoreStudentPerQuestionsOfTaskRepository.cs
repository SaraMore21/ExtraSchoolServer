﻿using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IScoreStudentPerQuestionsOfTaskRepository
    {
        void AddScoreStudentsOfQuestion(int TaskId, int CourseId, int UserCreatedId);
        public List<AppScoreStudentPerQuestionsOfTask> AddScoreToStudent(int QuestionId, List<AppStudent> ListStudent, int UserCreatedId);
    }
}
