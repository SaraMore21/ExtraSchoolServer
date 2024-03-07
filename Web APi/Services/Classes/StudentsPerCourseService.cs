using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DB.Model;
using DTO.Classes;
using DB.Repository.Interfaces;


namespace Services.Classes
{
    public class StudentsPerCourseService : IStudentsPerCourseService
    {

        public IStudentsPerCourseRepository _StudentsPerCourseRepository;
        public IMapper _mapper;

        public StudentsPerCourseService(IStudentsPerCourseRepository StudentsPerCourseRepository, IMapper Mapper)
        {
            _StudentsPerCourseRepository = StudentsPerCourseRepository;
            _mapper = Mapper;

        }
        public float AddOrUpdateGradePerCourse(int schoolID, int courseId, int taskexistId, float finelScorePerStudent, int studentId)
        {

            var x = _StudentsPerCourseRepository.AddOrUpdateGradePerCourse (schoolID, courseId, taskexistId, finelScorePerStudent, studentId);
            return x;
        }
        public List<AppStudentsPerCourseDTO> GetAllCourseToStudentBycoureID(int courseId)
        {
            var x = _mapper.Map<List<AppStudentsPerCourseDTO>>(_StudentsPerCourseRepository.GetAllCourseToStudentBycoureID(courseId));
            return x;
        }

        public AppStudentsPerCourseDTO UpdateCoursePerStudent(AppStudentsPerCourseDTO course)
        {


            AppStudentsPerCourse t = _StudentsPerCourseRepository.UpdateCoursePerStudent(_mapper.Map<AppStudentsPerCourse>(course));
            var a = _mapper.Map<AppStudentsPerCourseDTO>(t);
            return a;

        }
        public List<AppStudentsPerCourseDTO> AddListStudentsPerGroupToCourse(int idgroup, int idgroupsemesterpercourse, int yearbookid)
        {
            List<AppStudentsPerCourseDTO>  x = _mapper.Map<List<AppStudentsPerCourseDTO>>(_StudentsPerCourseRepository.AddListStudentsPerGroupToCourse(idgroup, idgroupsemesterpercourse, yearbookid));
            return x;
        }
        public AppStudentsPerCourseDTO AddStudentToCourse(int studentId, int idgroupsemesterpercourse)
        {
            AppStudentsPerCourseDTO x = _mapper.Map<AppStudentsPerCourseDTO>( _StudentsPerCourseRepository.AddStudentToCourse(studentId, idgroupsemesterpercourse));
            return x;
        }
        //object IStudentsPerCourseService.UpdateCoursePerStudent(AppStudentsPerCourseDTO appStudentsPerCourseDTO)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
