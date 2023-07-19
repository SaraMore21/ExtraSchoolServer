using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly ExtraSchoolContext _context;
        private readonly IUniqeCodeRepository _uniqeCodeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICoordinationRepository _coordinationRepository;
        public ProfessionRepository(ExtraSchoolContext context, IUniqeCodeRepository uniqeCodeRepository, IUserRepository userRepository, ICoordinationRepository coordinationRepositor)
        {
            _context = context;
            _uniqeCodeRepository = uniqeCodeRepository;
            _userRepository = userRepository;
            _coordinationRepository = coordinationRepositor;
        }

        //שליפת מקצועות לפי מוסד
        public List<AppProfession> GetAllProfessionByIdSchool(string SchoolsId)
        {
            SchoolsId = SchoolsId.Remove(SchoolsId.Length - 1);
            var Array = SchoolsId.Split(",").ToList();
            var x = _context.AppProfessions.Include(s => s.School).Include(i => i.ProfessionCategory).Include(u => u.Coordinator).ThenInclude(u => u.User).Where(w => Array.Contains(w.SchoolId.ToString()) == true).ToList();
            return x;
        }

        //שליפת פרטי מקצוע לפי קוד מקצוע 
        public AppProfession GetProfessionDetailsByProfessionId(int ProfessionId)
        {
            var profession = _context.AppProfessions.Include(i => i.ProfessionCategory).Include(u => u.Coordinator).ThenInclude(u => u.User).Include(i => i.School).FirstOrDefault(f => f.Idprofession == ProfessionId);
            return profession;
        }

        //עדכון מקצוע
        public AppProfession UpdateProfession(AppProfession P, int UserId, int SchoolId)
        {
            if (_context.AppProfessions.FirstOrDefault(f => f.Name == P.Name && f.SchoolId == P.SchoolId) != null) return null;
            var profession = _context.AppProfessions.FirstOrDefault(f => f.Idprofession == P.Idprofession);
            if (profession != null)
            {
                profession.Name = P.Name;
                profession.CoordinatorId = P.CoordinatorId;
                profession.SchoolId = P.SchoolId;
                profession.UserCreated = P.UserCreated;
                profession.DateCreate = P.DateCreate;
                profession.ProfessionCategoryId = P.ProfessionCategoryId;
                profession.DateCreate = P.DateCreate;
                profession.DateUpdate = DateTime.UtcNow.AddHours(2);
                profession.UserUpdatedId = UserId;
                profession.IsActive = P.IsActive;

                _context.SaveChanges();

                return _context.AppProfessions.Include(s => s.School).Include(i => i.ProfessionCategory).Include(p => p.Coordinator).ThenInclude(u => u.User).FirstOrDefault(f => f.Idprofession == P.Idprofession);
            }
            else
                throw new Exception();
        }

        //הוספת מקצוע
        public AppProfession AddProfession(AppProfession NewProfession, int UserCreatedId, int SchoolId)
        {
            try
            {
                NewProfession.IsActive = true;
                NewProfession.UserCreatedId = UserCreatedId;
                NewProfession.DateCreate = DateTime.Today;
                NewProfession.Coordinator = null;
                NewProfession.ProfessionCategory = null;
                NewProfession.SchoolId = SchoolId;
                var np = _context.AppProfessions.FirstOrDefault(f => f.SchoolId == SchoolId && f.Name == NewProfession.Name && f.ProfessionCategoryId == NewProfession.ProfessionCategoryId);
                if (np != null)
                    return null;
                _context.AppProfessions.Add(NewProfession);
                _context.SaveChanges();

                var profession = _context.AppProfessions.Include(s => s.School).Include(i => i.ProfessionCategory).Include(p => p.Coordinator).ThenInclude(u => u.User).FirstOrDefault(f => f.Idprofession == NewProfession.Idprofession);
                return profession;
            }
            catch (Exception e)
            {
                _context.AppProfessions.Local.Remove(NewProfession);

                throw e;
            }
        }

        //מחיקת מקצוע
        public int DeleteProfession(int ProfessionId)
        {

            //הפונקציה מחזירה:
            //   0- כאשר לא נמצאו שיוכים והמקצוע נמחק בהצלחה
            //   1-כאשר נמצאו שיוכים פעילים ולא ניתן להפוך את המקצוע ללא פעיל  
            //   2-כאשר נמצאו שיוכים לא פעילים המקצוע נהפך ללא פעיל

            try
            {
                //שליפת המקצוע למחיקה לפי הקוד
                var profession = _context.AppProfessions.FirstOrDefault(p => p.Idprofession == ProfessionId);

                //שליפת השיוכים
                var coursesList = _context.AppCourses.Where(c => c.ProfessionId == ProfessionId).ToList();
                if (coursesList == null || coursesList.Count == 0)
                {
                    _context.AppProfessions.Remove(profession);
                    _context.SaveChanges();
                    return 0;
                }

                var k = _context.AppGroupSemesterPerCourses.Include(c => c.Course).Where(w => w.Course.ProfessionId == ProfessionId).ToList();

                foreach (var item in k)
                {
                    if (item.FromDate <= DateTime.Today && item.ToDate >= DateTime.Today)
                        return 1;
                }

                profession.IsActive = false;
                _context.SaveChanges()
; return 2;

            }
            catch (Exception )
            {
                return -1;
            }
        }

        //בהוספת קורסים תואמים-בדיקה האם קיים המקצוע -אם לא הוספה  
        public Tuple<AppProfession, bool, int, AppUserPerSchool, int> CheckIfExsistAndAddProfession(AppSchool school, string ProfessioName, int CoustomerId, int? UserCreatedId, int YearbookId)
        {
            int UniqeCodeIdToProfession;

            var professions = _context.AppProfessions.Include(p => p.ProfessionCategory).Include(s => s.School).Include(u => u.Coordinator.User).Where(f => f.School.CoordinationCode == school.CoordinationCode && f.Name == ProfessioName);
            var CurrentProfession = professions.FirstOrDefault(f => f.UniqueCodeId != null && f.UniqueCodeId != 0);
            if (CurrentProfession == null)
            {
                UniqeCodeIdToProfession = _uniqeCodeRepository.AddUniqeCode(CoustomerId);
                CurrentProfession = professions.FirstOrDefault();
            }
            else
                UniqeCodeIdToProfession = (int)CurrentProfession.UniqueCodeId;
            var newProfession = professions.FirstOrDefault(f => f.SchoolId == school.Idschool);
            if (newProfession == null)
            {
                var UserPerYearbook = _userRepository.AddCopyUserPerSchool(CurrentProfession.Coordinator, school, CoustomerId, UserCreatedId, YearbookId);
                newProfession = new AppProfession()
                {
                    Name = ProfessioName,
                    CoordinatorId = UserPerYearbook.Item1.IduserPerSchool,
                    SchoolId = school.Idschool,
                    UserCreatedId = UserCreatedId,
                    DateCreate = DateTime.Today,
                    ProfessionCategoryId = CurrentProfession.ProfessionCategoryId,
                    IsActive = true,
                    UniqueCodeId = UniqeCodeIdToProfession
                };
                _context.AppProfessions.Add(newProfession);
                _context.SaveChanges();
                newProfession = _context.AppProfessions.Include(c => c.ProfessionCategory).Include(s => s.School).Include(u => u.Coordinator.User).ToList().LastOrDefault(l => l.Idprofession == newProfession.Idprofession);
                if (UserPerYearbook.Item3 == true)
                    return Tuple.Create(newProfession, true, (int)newProfession.UniqueCodeId, UserPerYearbook.Item1, UserPerYearbook.Item2);
                else
                    return Tuple.Create(newProfession, true, (int)newProfession.UniqueCodeId, new AppUserPerSchool(), UserPerYearbook.Item2);
            }
            else
            {
                if (newProfession.UniqueCodeId == 0 || newProfession.UniqueCodeId == null)
                    newProfession.UniqueCodeId = UniqeCodeIdToProfession;
                if (newProfession.Coordinator.UniqueCodeId == 0 || newProfession.Coordinator.UniqueCodeId == null)
                    newProfession.Coordinator.UniqueCodeId = _uniqeCodeRepository.AddUniqeCode(CoustomerId);
                _context.SaveChanges();
                return Tuple.Create(newProfession, false, (int)newProfession.UniqueCodeId, new AppUserPerSchool(), (int)newProfession.Coordinator.UniqueCodeId);
            }
        }

        //בדיקה האם קיים מקצוע בשם זה באחת המוסדות המבוקשים
        public bool CheackIfExsistProfession(string ProfessionName, string CoordinationCode)
        {
            if (_context.AppProfessions.Include(s => s.School).FirstOrDefault(f => f.Name == ProfessionName && f.School.CoordinationCode == CoordinationCode) != null) return true;
            return false;
        }

        //הוספת מקצוע תואם
        public List<AppProfession> AddCoordinationsProfession(List<AppProfession> ListProfession)
        {
            _context.AppProfessions.AddRange(ListProfession);
            _context.SaveChanges();
            return _context.AppProfessions.Include(c => c.ProfessionCategory).Include(s => s.School).Include(u => u.Coordinator.User).ToList().Where(w => ListProfession.FirstOrDefault(f => f.Idprofession == w.Idprofession) != null).ToList();
        }
        //עריכת מקצוע תואם
        public Tuple<List<AppProfession>, List<AppUserPerSchool>, int> UpdateCoordinationProfession(List<SchoolWithYearBookAndUserPerSchool> schools, AppProfession Profession, int CustomerId, int YearbookId)
        {
            if (_context.AppProfessions.ToList().FirstOrDefault(f => f.Name == Profession.Name && schools.FirstOrDefault(s => s.SchoolId == f.SchoolId) != null && f.UniqueCodeId != Profession.UniqueCodeId) != null) return null;

            var ListProfession = _context.AppProfessions.Include(s => s.School).ToList().Where(w => w.UniqueCodeId == Profession.UniqueCodeId && schools.FirstOrDefault(f => f.SchoolId == w.SchoolId) != null).ToList();
            int UniqueCodeToUser = 0;
            List<AppUserPerSchool> ListNewUser = new List<AppUserPerSchool>();

            foreach (var item in ListProfession)
            {

                var school = schools.FirstOrDefault(f => f.SchoolId == item.SchoolId);
                Tuple<AppUserPerSchool, int, bool> Result = _userRepository.AddCopyUserPerSchool(Profession.Coordinator, item.School, CustomerId, school.UserPerSchoolId, school.YearBookId);
                if (Result.Item3 == true)
                    ListNewUser.Add(Result.Item1);
                if (UniqueCodeToUser == 0) UniqueCodeToUser = Result.Item2;
                item.CoordinatorId = Result.Item1.IduserPerSchool;
                item.Name = Profession.Name;
                item.ProfessionCategoryId = Profession.ProfessionCategoryId;
                item.UserUpdatedId = school.UserPerSchoolId;
                item.DateUpdate = DateTime.Today;
                item.IsActive = Profession.IsActive;
            }
            _context.SaveChanges();
            ListProfession = _context.AppProfessions.Include(pc => pc.ProfessionCategory).Include(s => s.School).Include(c => c.Coordinator.User).ToList().Where(w => ListProfession.FirstOrDefault(f => f.Idprofession == w.Idprofession) != null).ToList();
            return Tuple.Create(ListProfession, ListNewUser, UniqueCodeToUser);
        }
    
    
        //הפונקציה מחזירה את כל המקצועות לפי קוד תיאום לא לפי קוד סוג תיאום
        public List<AppProfession> GetAllProfessionsByCoordinationId(int coordinationId)
        {
            List<AppProfession> listProfessions = new List<AppProfession>();
            List<int> listProfessionId = _coordinationRepository.GetAllPrimaryKeyGenericTypeByCoordinationId(coordinationId, "App_Profession");
            if (listProfessionId!=null)
            {
                listProfessionId.ForEach(
                    p =>
                    listProfessions.Add(this.GetProfessionDetailsByProfessionId(p))
                    );
            }
            return listProfessions;
        }


        public int GetCoordinatedProfessionPerSchool(int coordinationTypeId, int schoolId)
        {
            return _context.AppProfessions.FirstOrDefault(p => p.CoordinationTypeId == coordinationTypeId && p.SchoolId == schoolId).Idprofession;
        }
    
    
    }

}





