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
    public class ProfessionService : IProfessionService
    {
        private readonly IProfessionRepository _professionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUniqeCodeRepository _uniqeCodeRepository;
        private readonly IMapper _mapper;

        public ProfessionService(IProfessionRepository professionRepository, IUserRepository userRepository, IUniqeCodeRepository uniqeCodeRepository, IMapper mapper)
        {
            _professionRepository = professionRepository;
            _userRepository = userRepository;
            _uniqeCodeRepository = uniqeCodeRepository;
            _mapper = mapper;
        }

        //שליפת רשימת מקצועות לפי קוד מוסד
        public List<AppProfessionDTO> GetAllProfessionByIdSchool(string Schools)
        {
            var x = _mapper.Map<List<AppProfessionDTO>>(_professionRepository.GetAllProfessionByIdSchool(Schools));
            return x;
        }

        //שליפת פרטי מקצוע לפי קוד מקצוע
        public AppProfessionDTO GetProfessionDetailsByProfessionId(int ProfessionId)
        {
            return _mapper.Map<AppProfessionDTO>(_professionRepository.GetProfessionDetailsByProfessionId(ProfessionId));
        }

        //עדכון מקצוע
        public AppProfessionDTO UpdateProfession(AppProfessionDTO p, int userId, int SchoolId)
        {
            return _mapper.Map<AppProfessionDTO>(_professionRepository.UpdateProfession(_mapper.Map<AppProfession>(p), userId, SchoolId));
        }

        //הוספת מקצוע
        public AppProfessionDTO AddProfession(AppProfessionDTO newProfession, int userCreatedId, int schoolId)
        {
            return _mapper.Map<AppProfessionDTO>(_professionRepository.AddProfession(_mapper.Map<AppProfession>(newProfession), userCreatedId, schoolId));
        }

        //מחיקת מקצוע
        public int DeleteProfession(int ProfessionId)
        {
            return _professionRepository.DeleteProfession(ProfessionId);
        }

        //הוספת מקצוע תואם
        public Tuple<List<AppProfessionDTO>, List<SecUserDTO>, int> AddCoordinationsProfession(List<AppSchoolWhithYearbookDTO> ListSchool, AppProfessionDTO Profession, int CusomerId, int UserCreatedId, int YearbookId)
        {
            //בדיקה האם קיים מקצוע בשם זה באחת המוסדות המבוקשים
            if (_professionRepository.CheackIfExsistProfession(Profession.Name, ListSchool[0].school.CoordinationCode) == true)
                return null;

            AppProfession NewProfession;
            List<AppProfession> ListProfession = new List<AppProfession>();
            List<SecUserDTO> ListUser = new List<SecUserDTO>();

            int UniqueCodeToProfession = _uniqeCodeRepository.AddUniqeCode(CusomerId);
            int UniqueCodeToUserPerSchool = 0;
            foreach (var school in ListSchool)
            {
                var UserPerYearbook = _userRepository.AddCopyUserPerSchool(_mapper.Map<AppUserPerSchool>(Profession.Coordinator), _mapper.Map<AppSchool>(school.school), CusomerId, school.UserId, school.AppYearbookPerSchools.FirstOrDefault(f => f.YearbookId == YearbookId).IdyearbookPerSchool);
                if (UniqueCodeToUserPerSchool == 0) UniqueCodeToUserPerSchool = UserPerYearbook.Item2;
                NewProfession = new AppProfession()
                {
                    Name = Profession.Name,
                    CoordinatorId = UserPerYearbook.Item1.IduserPerSchool,
                    SchoolId = school.school.Idschool,
                    UserCreatedId = school.UserId,
                    DateCreate = DateTime.Today,
                    ProfessionCategoryId = Profession.ProfessionCategoryId,
                    IsActive = Profession.IsActive,
                    UniqueCodeId = UniqueCodeToProfession
                };
                ListProfession.Add(NewProfession);
                if (UserPerYearbook.Item3 == true)
                    ListUser.Add(_mapper.Map<SecUserDTO>(UserPerYearbook.Item1));
            }
            ListProfession = _professionRepository.AddCoordinationsProfession(ListProfession);
            var p = _mapper.Map<List<AppProfessionDTO>>(ListProfession);
            return Tuple.Create(p, ListUser, UniqueCodeToUserPerSchool);
        }

        //עריכת מקוצועות תואמים
        public Tuple<List<AppProfessionDTO>, List<SecUserDTO>, int> UpdateCoordinationProfession(List<AppSchoolWhithYearbookDTO> ListSchool, AppProfessionDTO Profession, int CustomerId, int UserCreatedId, int YearbookId)
        {
            List<DB.Repository.Classes.SchoolWithYearBookAndUserPerSchool> schools = new List<DB.Repository.Classes.SchoolWithYearBookAndUserPerSchool>();
            DB.Repository.Classes.SchoolWithYearBookAndUserPerSchool s = new DB.Repository.Classes.SchoolWithYearBookAndUserPerSchool();
            ListSchool.ForEach(f =>
            {
                s = new DB.Repository.Classes.SchoolWithYearBookAndUserPerSchool();
                s.SchoolId = f.school.Idschool;
                s.UserPerSchoolId = f.UserId;
                s.YearBookId = (int)f.AppYearbookPerSchools.FirstOrDefault(r => r.SchoolId == s.SchoolId && r.YearbookId == YearbookId)?.IdyearbookPerSchool;
                schools.Add(s);
            });
            Tuple<List<AppProfession>, List<AppUserPerSchool>, int> Result =_professionRepository.UpdateCoordinationProfession(schools,_mapper.Map<AppProfession>(Profession), CustomerId, YearbookId);
            if (Result == null) return null;
            return Tuple.Create(_mapper.Map<List<AppProfessionDTO>>(Result.Item1), _mapper.Map<List<SecUserDTO>>(Result.Item2), Result.Item3);
        }
    }
}
