using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DB.Model;
using DB.Repository.Classes;
using DB.Repository.Interfaces;
using DTO;
using DTO.Classes;
using Services.Interfaces;

namespace Services.Classes
{
    public class CourseService: ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IGroupRepository _groupRepository;

        public CourseService(IMapper mapper, ICourseRepository courseRepository, ISchoolRepository schoolRepository, IGroupRepository groupRepository) {
            _courseRepository = courseRepository;
            _mapper = mapper;
            _schoolRepository = schoolRepository;
            _groupRepository = groupRepository;
        }

        //public AppGroupSemesterPerCourseDTO AddCourse(int SchoolId, int SemesterId, int CourseId, int GroupId, DateTime SemesterFromDate, DateTime SemesterToDate, int TeacherId, int YearbookId,int UserCreatedId, AppCourseDTO Course)
        //{
        //    return _mapper.Map<AppGroupSemesterPerCourseDTO>(
        //        _courseRepository.AddCourse(SchoolId, SemesterId, CourseId, GroupId, SemesterFromDate, SemesterToDate, TeacherId,YearbookId, UserCreatedId, _mapper.Map<AppCourse>(Course)));
        //}

        public List<AppGroupSemesterPerCourseDTO> GetAllCourseBySchoolDAndYearbookId(string SchoolsId, int YearbookId)
        {
            var ListCourse=_mapper.Map<List<AppGroupSemesterPerCourseDTO>>(_courseRepository.GetAllCourseBySchoolDAndYearbookId(SchoolsId, YearbookId));
            //if (ListCourse.Count() > 0) ListCourse[0].YearbookId = YearbookId;
            return ListCourse;
        }
        public List<AppCourseDTO> GetAllCourseBySchoolId(int SchoolId)
        {
            return _mapper.Map<List<AppCourseDTO>>(_courseRepository.GetAllCourseBySchoolId(SchoolId));
        }
        public List<AppSemesterDTO> GetAllSemester(int YearbookId)
        {
            return _mapper.Map<List<AppSemesterDTO>>(_courseRepository.GetAllSemester(YearbookId));
        }
        public int DeleteCourse(int CourseId)
        {
            return _courseRepository.DeleteCourse(CourseId);
        }
        public List<AppUserPerCourseDTO> GetUsersPerCourse(int CourseId)
        {
            var Lc = _courseRepository.GetUsersPerCourse(CourseId);
            var a= _mapper.Map<List<AppUserPerCourseDTO>>(Lc);
            return a;
        }

        public bool EditCourse(int CourseId,string CourseCode, List<AppUserPerCourseDTO> ListUserPerCourse)
        {
            return _courseRepository.EditCourse(CourseId,CourseCode, _mapper.Map<List<AppUserPerCourse>>(ListUserPerCourse));
        }

        public AppCourseDTO AddFatherCourse(AppCourseDTO Course)
        {
            return _mapper.Map<AppCourseDTO>(_courseRepository.AddFatherCourse(_mapper.Map<AppCourse>(Course)));
        }

        public List<AppGroupSemesterPerCourseDTO> GetAllCourseByFatherCourseId(int FatherCourseId)
        {
            return _mapper.Map<List<AppGroupSemesterPerCourseDTO>>(_courseRepository.GetAllCourseByFatherCourseId(FatherCourseId));
        }

        public AppGroupSemesterPerCourseDTO AddCourse(AppGroupSemesterPerCourseDTO course, int TeacherId)
        {
            var result = _courseRepository.AddCourse(_mapper.Map<AppGroupSemesterPerCourse>(course),TeacherId);
           return  _mapper.Map<AppGroupSemesterPerCourseDTO>(result);
        }

        public List<AppGroupSemesterPerCourseDTO> GetCoursesForGroup(int GroupId, DateTime scheduleDate)
        {
            return _mapper.Map<List<AppGroupSemesterPerCourseDTO>>(_courseRepository.GetCoursesForGroup(GroupId, scheduleDate));
        }
        //שליפת המורה המשוייכת לקורס בטווח תאריכים
        public SecUserDTO GetUserPerCourse(int CourseId, DateTime Date)
        {
            return _mapper.Map<SecUserDTO>(_courseRepository.GetUserPerCourse(CourseId,Date));
        }

        public List<AppGroupSemesterPerCourseDTO> AddCoordinationsCourse(AppGroupSemesterPerCourseDTO Course, int YearbookId)
        {
            //var Course = objectCourseAndListSchools.Course;
            var listSchool = new List<int>();



            //List<int> ListSchools = _schoolRepository.GetSchoolIdsByCoordinationId(Course.Course.CoordinationCode);
            List<AppGroupSemesterPerCourseDTO> listCourses = new List<AppGroupSemesterPerCourseDTO>();
            //ListSchools.ForEach(
            //    s =>
            //    {
            //        int yearbookIdPerSchool = _schoolRepository.GetSchoolIdYearbookPerSchoollByYearBookId(s, YearbookId);
            //        Course.SchoolId = s;
            //        Course.YearbookId = yearbookIdPerSchool;
            //        var lgroup = _groupRepository.GetGroupsByCoordinationCode(Course.Course.CoordinationCode);
            //        Course.GroupId = lgroup.FirstOrDefault(g => g.Group.SchoolId == s).IdgroupPerYearbook;
            //        var course = _courseRepository.AddCordinatedCourse(_mapper.Map<AppGroupSemesterPerCourse>(Course));
            //        listCourses.Add(_mapper.Map<AppGroupSemesterPerCourseDTO>(course));
            //    });
            return null;
            //listCourses;








        }

        public ObjectCourseAndListSchools TestGetCoordinatedCourse()
        {
            var obj = new ObjectCourseAndListSchools();
            var result = _courseRepository.TestGetCoordinatedCourse();
            obj.Course = _mapper.Map<AppGroupSemesterPerCourseDTO>( result.Item1);
            obj.ListSchool = _mapper.Map<List<AppSchoolWhithYearbookDTO>>(result.Item2);
            return obj;

        }
    }

}
