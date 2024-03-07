using DB.Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.Classes;
using DB.Model;
using DTO;

namespace Services.Classes
{


    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;
        public readonly IAgeGroupRepository _ageGroupRepository;
        public readonly IStudentsPerCourseRepository _StudentsPerCourseRepository;
        public readonly IStudentsPerCourseService _StudentsPerCourseService;

        public GroupService(IGroupRepository groupRepository, IMapper mapper ,ISchoolRepository schoolRepository, IAgeGroupRepository ageGroupRepository, IStudentsPerCourseService StudentsPerCourseService, IStudentsPerCourseRepository StudentsPerCourseRepository)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
            _schoolRepository = schoolRepository;
            _ageGroupRepository = ageGroupRepository;
            _StudentsPerCourseRepository = StudentsPerCourseRepository;
            _StudentsPerCourseService = StudentsPerCourseService;

        }

        //public List<AppGroupDTO> GetGroupsByIdSchool(int SchoolId, int YearbookId)
        //{
        //    try { 
        //       return _mapper.Map<List<AppGroupDTO>>(_groupRepository.GetGroupsByIdSchool(SchoolId,YearbookId));

        //    }
        //    catch(Exception e)
        //    {
        //        return null;
        //    }
        //}



        public List<AppGroupPerYearbookDTO> GetGroupsByIdSchool(string Schools, int YearbookId)
        {
             
            var x = _groupRepository.GetGroupsByIdSchool(Schools, YearbookId);
            return _mapper.Map<List<AppGroupPerYearbookDTO>>(x);
            //var group = _groupRepository.GetGroupsByIdSchool(SchoolId, YearbookId);
            //List<AppGroupDTO> list = new List<AppGroupDTO>();
            //group.ForEach(f => {
            //    var g = _mapper.Map<AppGroupDTO>(f.Group);
            //    g.IdgroupPeryearbook = f.IdgroupPerYearbook;
            //    list.Add(g);
            //});

            //return list;
        }
        public List<AppStudentPerGroupDTO> GetStudentPerGroup(int GroupId, int YearbookId)
        {
            return _mapper.Map<List<AppStudentPerGroupDTO>>(_groupRepository.GetStudentPerGroup(GroupId, YearbookId));
        }
        public int DeleteGroup(int GroupId, int YearbookId)
        {
            return _groupRepository.DeleteGroup(GroupId, YearbookId);
        }
        public bool EditGroup(int IdgroupPerYearbook, int UserUpdateId, List<AppUserPerGroupDTO> ListUsersPerGroup)
        {
            return _groupRepository.EditGroup(IdgroupPerYearbook, UserUpdateId, _mapper.Map<List<AppUserPerGroup>>(ListUsersPerGroup));
        }
        public AppGroupDTO EditGroup2(AppGroupDTO group, int userUpdatedId)
        {
            return _mapper.Map<AppGroupDTO>( _groupRepository.EditGroup2(_mapper.Map<AppGroup>(group), userUpdatedId));

        }
        public AppGroupPerYearbookDTO AddGroup(AppGroupDTO Group, int UserCreatedId, int SchoolId, int YearbookId, int userId)
        {
            return _mapper.Map<AppGroupPerYearbookDTO>(_groupRepository.AddGroup(_mapper.Map<AppGroup>(Group), UserCreatedId, SchoolId, YearbookId, userId));
        }

        public ReturnObjectOfAddStudentDTO AddStudentInGroup(int GroupId, int StudentId, int YearbookId, string FromDate, string ToDate, int UserCreatedId)
        {
            var result = _groupRepository.AddStudentInGroup(GroupId, StudentId, YearbookId, FromDate, ToDate, UserCreatedId);

            var r = new ReturnObjectOfAddStudentDTO()
            {
                ID = result[0],
                Name = result[1]
            };

            AppGroupPerYearbook appGroupPerYearbook = _groupRepository.IsGroupHasTasks(GroupId);
            if (appGroupPerYearbook != null &&
                appGroupPerYearbook.AppGroupSemesterPerCourses != null && appGroupPerYearbook.AppGroupSemesterPerCourses.Count() > 0 &&
                appGroupPerYearbook.AppGroupSemesterPerCourses.FirstOrDefault(f => f.AppTaskExsists != null && f.AppTaskExsists.Count() > 0) != null)
            {
                r.ListTaskToGroup = new List<TaskToGroupDTO>();
                appGroupPerYearbook.AppGroupSemesterPerCourses.ToList().ForEach(f =>
                {
                    f.AppTaskExsists.ToList().ForEach(e =>
                    {
                        r.ListTaskToGroup.Add(new TaskToGroupDTO() { IdexsistTask = e.IdexsistTask, NameTask = e.Name + ", " + f.Course.Name, isCheck = false });
                    });
                });
            }
            var x = _StudentsPerCourseRepository.GetLIstCoursePerGroupId(GroupId);
            x.ForEach(c => {
                _StudentsPerCourseRepository.AddStudentToCourse(StudentId, c.IdgroupSemesterPerCourse); 
            });
       
            return r;

        }

        public List<AppGroupDTO> GetAllNameGroup(int SchoolId)
        {
            try
            {
                return _mapper.Map<List<AppGroupDTO>>(_groupRepository.GetAllNameGroup(SchoolId));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public AppGroupPerYearbookDTO AddGroupInYearbook(int UserId, int GroupId, int YearbookId, int UserCreatedId)
        {
            return _mapper.Map<AppGroupPerYearbookDTO>(_groupRepository.AddGroupInYearbook(UserId, GroupId, YearbookId, UserCreatedId));
        }
        public List<AppUserPerGroupDTO> GetUsersPerGroupByGroupId(int GroupId)
        {
            return _mapper.Map<List<AppUserPerGroupDTO>>(_groupRepository.GetUsersPerGroupByGroupId(GroupId));
        }

        public AppStudentPerGroupDTO DeleteStudentInGroup(int StudentId, int GroupId)
        {
            return _mapper.Map<AppStudentPerGroupDTO>(_groupRepository.DeleteStudentInGroup(StudentId, GroupId));

        }

        public ReturnObjectOfStudentPerGroupDTO EditStudentInGroup(AppStudentPerGroupDTO StudentPerGroup, DateTime FromDate, DateTime ToDate, int UserUpdateId)
        {
            var student = _mapper.Map<AppStudentPerGroup>(StudentPerGroup);
            var result = _groupRepository.EditStudentInGroup(student, FromDate, ToDate, UserUpdateId);
            student.ToDate = ToDate;
            student.FromDate = FromDate;
            student.UserUpdatedId = UserUpdateId;

            var r = new ReturnObjectOfStudentPerGroupDTO()
            {
                ID = result[0],
                Name = result[1],
                StudentPerGroup = _mapper.Map<AppStudentPerGroupDTO>(student)
            };
            return r;

        }

        public List<AppGroupPerYearbookDTO> AddCoordinatedGroup(AppGroupDTO Group, int UserCreatedId, int YearbookId, int userId)
        {
          //List<int> ListSchools= _schoolRepository.GetSchoolIdsByCoordinationId(Group.CoordinationCode);
            List<AppGroupPerYearbookDTO> listGroups = new List<AppGroupPerYearbookDTO>();
            //ListSchools.ForEach(
            //    s =>
            //    {
            //        int yearbookIdPerSchool = _schoolRepository.GetSchoolIdYearbookPerSchoollByYearBookId(s,YearbookId);
            //        var ageGroup = _ageGroupRepository.GetAgeGroupByCoordinationCodeAndSchoolIdAndName(s, Group.CoordinationCode, Group.AgeGroupName);
            //        Group.AgeGroupId = ageGroup.IdageGroup;
            //       var group= _groupRepository.AddGroup(_mapper.Map<AppGroup>(Group), UserCreatedId,s, yearbookIdPerSchool, userId);
            //        listGroups.Add(_mapper.Map<AppGroupPerYearbookDTO>(group));
            //    });
            return null;
            //listGroups;
        }

        //public List<AppGroupPerYearbookDTO> GetGroupsByCoordinationCode(string coordinationCode)
        //{
        //    return _mapper.Map<List<AppGroupPerYearbookDTO>>(_groupRepository.GetGroupsByCoordinationCode(coordinationCode));
        //😀}
    }
}
