using AutoMapper;
using DB.Model;
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
    public class FatherCourseService : IFatherCourseService
    {
        private readonly IFatherCourseRepository _fatherCourseRepositoy;
        private readonly IMapper _mapper;
        private readonly IUniqeCodeRepository _uniqeCodeRepository;
        public FatherCourseService(IMapper mapper, IFatherCourseRepository fatherCourseRepository, IUniqeCodeRepository uniqeCodeRepository)
        {
            _mapper = mapper;
            _fatherCourseRepositoy = fatherCourseRepository;
            _uniqeCodeRepository = uniqeCodeRepository;
        }

        public Tuple<List<AppCourseDTO>, List<AppProfessionDTO>, List<SecUserDTO>, int, int> AddCoordinationsFatherCourse(ObjectFatherCoursekAndListSchools objectFatherCoursekAndListSchools, int YearbookId, int CoustomerId)
        {
            var FatherCourse = objectFatherCoursekAndListSchools.FatherCourse;
            var listSchool = new List<int>();
            objectFatherCoursekAndListSchools.ListSchool.ForEach(f =>
             listSchool.Add(f.school.Idschool));
            if (_fatherCourseRepositoy.CheckIfExsistFatherCourseInSchool(listSchool, _mapper.Map<AppCourse>(FatherCourse)) == true)
                return null;
            else
            {
                var fahterCourse = objectFatherCoursekAndListSchools.FatherCourse;
                List<AppCourseDTO> ListNewCourse = new List<AppCourseDTO>();
                List<AppProfessionDTO> ListNewProfession = new List<AppProfessionDTO>();
                List<SecUserDTO> ListNewUserPerYearbook = new List<SecUserDTO>();
                var UniqeCodeIdToFatherCourse = _uniqeCodeRepository.AddUniqeCode(CoustomerId);
                int UniqeCodeToNewProfession = 0;
                int UniqeCodeToNewUser = 0;
                objectFatherCoursekAndListSchools.ListSchool.ForEach(f =>
                {
                    fahterCourse.DateCreate = DateTime.Today;
                    fahterCourse.SchoolId = f.school.Idschool;
                    fahterCourse.UserCreatedId = f.UserId;
                    fahterCourse.YearbookId = f.AppYearbookPerSchools.FirstOrDefault(f => f.YearbookId == YearbookId).IdyearbookPerSchool;
                    fahterCourse.UniqueCodeId = UniqeCodeIdToFatherCourse;
                    var Result = _fatherCourseRepositoy.AddCoordinationsFatherCourse(_mapper.Map<AppCourse>(fahterCourse), FatherCourse.ProfessionName, CoustomerId, _mapper.Map<AppSchool>(f.school), f.UserId, f.AppYearbookPerSchools.FirstOrDefault(f => f.YearbookId == YearbookId).IdyearbookPerSchool);
                    if (UniqeCodeToNewProfession == 0) UniqeCodeToNewProfession = Result.Item4;
                    if (UniqeCodeToNewUser == 0) UniqeCodeToNewUser = Result.Item5;
                    ListNewCourse.Add(_mapper.Map<AppCourseDTO>(Result.Item1));
                    if (Result.Item2.Idprofession != 0)
                        ListNewProfession.Add(_mapper.Map<AppProfessionDTO>(Result.Item2));
                    if (Result.Item3.IduserPerSchool != 0)
                        ListNewUserPerYearbook.Add(_mapper.Map<SecUserDTO>(Result.Item3));
                });

                return Tuple.Create(ListNewCourse, ListNewProfession, ListNewUserPerYearbook, UniqeCodeToNewProfession, UniqeCodeToNewUser);
            }

        }

        public AppCourseDTO AddFatherCourse(AppCourseDTO FatherCourse)
        {
            return _mapper.Map<AppCourseDTO>(_fatherCourseRepositoy.AddFatherCourse(_mapper.Map<AppCourse>(FatherCourse)));
        }

        public bool DeleteFatherCrouse(int FatherCourseId)
        {
            return _fatherCourseRepositoy.DeleteFatherCrouse(FatherCourseId);
        }

        public Tuple<List<AppCourseDTO>, List<AppProfessionDTO>, int, List<SecUserDTO>, int> EditCoordinatorCourseFather(AppCourseDTO fatherCourse, int UserId, int CoustomerId)
        {
            var Result = _fatherCourseRepositoy.EditCoordinatorCourseFather(_mapper.Map<AppCourse>(fatherCourse), UserId, CoustomerId);
            if (Result == null) return null;
            return Tuple.Create(_mapper.Map<List<AppCourseDTO>>(Result.Item1), _mapper.Map<List<AppProfessionDTO>>(Result.Item2), Result.Item3, _mapper.Map<List<SecUserDTO>>(Result.Item4), Result.Item5);
        }

        public AppCourseDTO EditFatherCourse(AppCourseDTO FatherCourse)
        {
            return _mapper.Map<AppCourseDTO>(_fatherCourseRepositoy.EditFatherCourse(_mapper.Map<AppCourse>(FatherCourse)));
        }

        public List<AppCourseDTO> GetListFatherCoursesBySchoolAndYearbook(string SchoolsId, int YearbookId)
        {
            var a = _fatherCourseRepositoy.GetListFatherCoursesBySchoolAndYearbook(SchoolsId, YearbookId);
            var c = _mapper.Map<List<AppCourseDTO>>(a);
            return c;
        }
        public AppCourseDTO getFatherCourseById(int fatherCourseId)
        {
            return _mapper.Map<AppCourseDTO>(_fatherCourseRepositoy.getFatherCourseById(fatherCourseId));
        }
    }
}
