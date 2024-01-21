using AutoMapper;
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
    public class QuestionsOfTaskService:IQuestionsOfTaskService
    {
        public IQuestionsOfTaskRepository _questionsOfTaskRepository;
        public IMapper _mapper;

        public QuestionsOfTaskService(IQuestionsOfTaskRepository questionsOfTaskRepository,IMapper mapper)
        {
            _questionsOfTaskRepository = questionsOfTaskRepository;
            _mapper = mapper;
        }
        public List<AppQuestionsOfTaskDTO> GetQuestionOfTask(int TaskId)
        {
            return _mapper.Map<List<AppQuestionsOfTaskDTO>>(_questionsOfTaskRepository.GetQuestionOfTask(TaskId)); 
        }

    }
}
