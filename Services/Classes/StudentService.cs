using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using DB.Repository.Interfaces;
//using DB.Model;
using DTO.Classes;
using Services.Interfaces;
using DB.Model;
using DTO;

namespace Services.Classes
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITaskExsistRepository _taskExsistRepository;
        private readonly IStudentPerGroupRepository _studentPerGroupRepository;
        private readonly IMapper _mapper;


        public StudentService(IStudentRepository studentRepository, ITaskExsistRepository taskExsistRepository, IMapper mapper, IStudentPerGroupRepository studentPerGroupRepository)
        {
            _studentRepository = studentRepository;
            _taskExsistRepository = taskExsistRepository;
            _studentPerGroupRepository = studentPerGroupRepository;
            _mapper = mapper;
        }
        //IDשליפת תלמידים במוסד עפ"י מוסד
        public List<AppStudentDTO> GetListStudentsBySchoolId(int schoolId)
        {
            try
            {
                var lstStudents = _studentRepository.GetListStudentsBySchoolId(schoolId);
                return _mapper.Map<List<AppStudentDTO>>(lstStudents);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            //_answerRepository.Add(_mapper.Map<List<AppStudentDTO>>(lstStudents));
            // return _mapper.Map<IEnumerable<AppStudent>, List<AppStudentDTO>>(lstStudents); // mapping models here
        }
        //מחיקת תלמיד
        public bool DeleteStudent(int SchoolID)
        {
            return _studentRepository.DeleteStudent(SchoolID);
        }
        // ID שליפת פרט תלמיד עפ"י 
        public AppStudentWhithDetailsDTO GetStudentDetailsByIDStudent(int StudentID)
        {
            var x = _mapper.Map<AppStudentWhithDetailsDTO>(_studentRepository.GetStudentDetailsByIDStudent(StudentID));
            return x;
        }
        //הוספת תלמיד
        public ReturnObjectOfAddStudentDTO AddStudent(AppStudentWhithDetailsDTO student, int UserCreatedId, int SchoolId, int YearbookId)
        {
            try
            {
                var s = _mapper.Map<AppStudent>(student);
                s.Address.UserCreatedId = UserCreatedId; s.Address.DateCreated = DateTime.UtcNow.AddHours(2);
                s.ContactInformation.UserCreatedId = UserCreatedId; s.ContactInformation.DateCreated = DateTime.UtcNow.AddHours(2);
                s.Birth.UserCreatedId = UserCreatedId; s.Birth.DateCreated = DateTime.UtcNow.AddHours(2);
                var String = _studentRepository.AddStudent(s, UserCreatedId, SchoolId, YearbookId);
                //a.Birth = null;
                //var Student = _mapper.Map<AppStudentDTO>(s);
                AppStudentDTO AppStudent = _mapper.Map<AppStudentDTO>(s);
                AppStudent.NumRequiredPerStudent = _studentRepository.getNumRequiredPerStudent(SchoolId);
                return new ReturnObjectOfAddStudentDTO() { AppStudent = AppStudent, ID = String[1], Name = String[0] };
            }
            catch (Exception)
            {
                return null;
            }


        }
        //עדכון תלמיד
        public AppStudentDTO UpdateStudent(AppStudentWhithDetailsDTO student, int UserCreatedId, int SchoolId)
        {
            var s = _mapper.Map<AppStudent>(student);
            return _mapper.Map<AppStudentDTO>(_studentRepository.updateStudent(s, SchoolId, UserCreatedId));
        }

        public bool UpdateProfilePathToStudent(int idStudent, string path, int SchoolId, int Userid)
        {
            return _studentRepository.UpdateProfilePathToStudent(idStudent, path, SchoolId, Userid);
        }

        public List<AppStudentDTO> GetListStudentsBySchoolIdAndYearbookId(string SchoolsId, int YearbookId)
        {

            var list1 = (_studentRepository.GetListStudentsBySchoolIdAndYearbookId(SchoolsId, YearbookId));
            var list = _mapper.Map<List<AppStudentDTO>>(list1);
            //if(list.Count != 0) list[0].YearbookId = YearbookId;
            return list;
        }
        //שליפת הקבוצות לפי תלמידה ושנתון
        public List<GroupWithCourseDTO> GetGroupsToStudent(int StudentId, int YearbookId)
        {
            var Result = _studentRepository.GetGroupsToStudent(StudentId, YearbookId);
            return _mapper.Map<List<GroupWithCourseDTO>>(Result);
        }
        //מחיקת שיוך תלמיד לקבוצה
        public AppStudentPerGroupDTO DeleteGroupToStudent(int StudentPerGroupId)
        {
            return _mapper.Map<AppStudentPerGroupDTO>(_studentRepository.DeleteGroupToStudent(StudentPerGroupId));
        }
        //הוספת שיוך קבוצה לתלמיד
        public new Tuple<bool, string, GroupWithCourseDTO, List<AppTaskExsistDTO>> AddGroupPerStudent(AppStudentPerGroupDTO StudentPerGroup)
        {
            var Result = _studentRepository.AddGroupPerStudent(_mapper.Map<AppStudentPerGroup>(StudentPerGroup));
            var ListTaskExsist = _taskExsistRepository.GetTaskExsistByGroupId((int)Result.Item3.GroupId);
            return Tuple.Create(Result.Item1, Result.Item2, _mapper.Map<GroupWithCourseDTO>(Result.Item3), _mapper.Map<List<AppTaskExsistDTO>>(ListTaskExsist));
        }

        public bool AddTasksToStudent(List<AppTaskExsistDTO> ListTaskExsist, int StudentId, int UserCreatedId)
        {
            var listTaskToStudent = new List<AppTaskToStudent>();
            foreach (var tastExsist in ListTaskExsist)
            {
                listTaskToStudent.Add(new AppTaskToStudent() { StudentId = StudentId, TaskExsistId = tastExsist.IdexsistTask, UserCreatedId = UserCreatedId, DateCreated = DateTime.Today });
            }
            return _studentRepository.AddTasksToStudent(listTaskToStudent);
        }

        public AppStudentPerGroupDTO GetStudentPerGroupById(int StudentPerGroupId)
        {
            return _mapper.Map<AppStudentPerGroupDTO>(_studentPerGroupRepository.GetStudentPerGroupById(StudentPerGroupId));
        }

        public List<TReasonForLeavingDTO> GetReasonForLeavingPerSchool(int SchoolId)
        {
            return _mapper.Map<List<TReasonForLeavingDTO>>(_studentRepository.GetReasonForLeavingPerSchool(SchoolId));
        }
    }
}
