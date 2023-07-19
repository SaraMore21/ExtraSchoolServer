using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DB.Repository.Classes
{
    public class FatherCourseRepository : IFatherCourseRepository
    {
        private readonly ExtraSchoolContext _context;
        private readonly IUniqeCodeRepository _uniqeCodeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProfessionRepository _professionRepository;
        private readonly ICoordinationRepository _coordinationRepository;
        public FatherCourseRepository(ExtraSchoolContext context, IUniqeCodeRepository uniqeCodeRepository, IUserRepository userRepository, IProfessionRepository professionRepository, ICoordinationRepository coordinationRepository)
        {
            _context = context;
            _uniqeCodeRepository = uniqeCodeRepository;
            _userRepository = userRepository;
            _professionRepository = professionRepository;
            _coordinationRepository = coordinationRepository;
        }


        public List<AppCourse> GetListFatherCoursesBySchoolAndYearbook(string SchoolsId, int YearbookId)
        {
            //using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            //{
            //    cmd.CommandText = "[dbo].[sp_CourseFatherBySchoolAndYearbook]";
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
            //    cmd.Parameters.Add(new SqlParameter("@YearbookId", 1));
            //    cmd.Parameters.Add(new SqlParameter("@SchoolsId", 2));
            //    var a = cmd.ExecuteScalar();
            //    //cmd.Connection.Close();
            //}

            string[] array;
            SchoolsId = SchoolsId.Remove(SchoolsId.Length - 1, 1);
            array = SchoolsId.Split(",");
            return _context.AppCourses.Include(i => i.Yearbook).Include(s => s.School).Include(p => p.Profession).Include(l => l.LearningStyle).Where(w => array.Any(f => f == w.SchoolId.ToString()) == true && w.Yearbook.YearbookId == YearbookId).ToList();
            //var a = _context.AppAplications.from<object>("storedProcedureName", 1,);‏
            ///  _context.Database.SqlQuery

            //return a;
            //_context.Database.SqlQuery<AppCourse>("exec usp_StoredProcedure").ToList()‏

            //object p = _context.Database.SqlQuery<object>("sp_CourseFatherBySchoolAndYearbook");

            //_context.Database.SqlQuery<AppCourse>("exec usp_StoredProcedure").ToList();
            //var blogs = _context.Blogs.FromSqlRaw("EXECUTE dbo.GetMostPopularBlogs") .ToList();
            //_context.ExecuteStoreQuery

            //                  this.Database.SqlQuery<YourEntityType>("storedProcedureName",params);‏

            //            בהרבה מקומות אני רואה כזה קוד
            //   context.Database.SqlQuery<YourType>("exec usp_StoredProcedure").ToList()‏
            //או
            //this.Database.SqlQuery<YourEntityType>("storedProcedureName",params);‏
            //השני יותר נכון

            return null;
        }

        public AppCourse AddFatherCourse(AppCourse FatherCourse)
        {
            if (_context.AppCourses.FirstOrDefault(f => f.Name == FatherCourse.Name && f.SchoolId == FatherCourse.SchoolId) != null) return null;
            _context.AppCourses.Add(FatherCourse);
            _context.SaveChanges();
            return _context.AppCourses.Include(s => s.School).Include(p => p.Profession).Include(l => l.LearningStyle).ToList().LastOrDefault(l => l.Idcourse == FatherCourse.Idcourse);
        }
        public bool CheckIfExsistFatherCourseInSchool(List<int> ListSchool, AppCourse FatherCourse)
        {
            return _context.AppCourses.FirstOrDefault(f => ListSchool.Contains((int)f.SchoolId) == true && f.Name == FatherCourse.Name) != null;
        }
        public AppCourse EditFatherCourse(AppCourse FatherCourse)
        {
            if (_context.AppCourses.FirstOrDefault(f => f.Name == FatherCourse.Name && f.SchoolId == FatherCourse.SchoolId && f.Idcourse!=FatherCourse.Idcourse) != null) return null;

            var FC = _context.AppCourses.FirstOrDefault(f => f.Idcourse == FatherCourse.Idcourse);
            FC.Name = FatherCourse.Name;
            FC.ProfessionId = FatherCourse.ProfessionId;
            FC.HoursPerWeek = FatherCourse.HoursPerWeek;
            FC.Hours = FatherCourse.Hours;
            FC.Credits = FatherCourse.Credits;
            FC.Cost = FatherCourse.Cost;
            FC.MinimumScore = FatherCourse.MinimumScore;
            FC.Code = FatherCourse.Code;
            FC.LearningStyleId = FatherCourse.LearningStyleId;
            FC.UserUpdatedId = FatherCourse.UserUpdatedId;
            FC.DateUpdate = FatherCourse.DateUpdate;
            _context.SaveChanges();
            FC = _context.AppCourses.Include(s=>s.School).Include(p=>p.Profession).Include(l=>l.LearningStyle).ToList().LastOrDefault(l => l.Idcourse == FC.Idcourse);
            return FC;
        }

        public bool DeleteFatherCrouse(int FatherCourseId)
        {
            var c = _context.AppCourses.Include(c => c.AppGroupSemesterPerCourses).FirstOrDefault(f => f.Idcourse == FatherCourseId);
            if (c.AppGroupSemesterPerCourses.Count() > 0)
                return false;
            _context.AppCourses.Remove(c);
            _context.SaveChanges();
            return true;
        }


        //public int AddCoordinationsFatherCourse( ListSchool, objectFatherCoursekAndListSchools.FatherCourse, YearbookId, CoustomerId)
        //{
        //    throw new NotImplementedException();
        //}
        public AppCourse AddCoordinationsFatherCourse(AppCourse fahterCourse, int ProfessioCoordinationId, int CoustomerId, AppSchool school, int UserCreatedId, int YearbookId, int coordinationId)
        {
            // var Result = _professionRepository.CheckIfExsistAndAddProfession(school, ProfessioName, CoustomerId, UserCreatedId, YearbookId);
            
            AppCoordinationType coordinationType = new AppCoordinationType();
            coordinationType.CoordinationType = "App_Course";
            coordinationType.DateCreated = DateTime.Today;
            coordinationType.UserCreatedId = UserCreatedId;
            coordinationType.IdCoordinationPerSchool = _coordinationRepository.getIdCoordinationPerSchoolByCoordinationIdAndSchoolId(
                coordinationId, school.Idschool);
            _coordinationRepository.AddCoordinationType(coordinationType);
            fahterCourse.CoordinationTypeId = coordinationType.IdCoordinationType;
            var professionId = _professionRepository.GetCoordinatedProfessionPerSchool(ProfessioCoordinationId, school.Idschool);
            fahterCourse.ProfessionId = professionId;
            _context.AppCourses.Add(fahterCourse);
            _context.SaveChanges();
            fahterCourse = _context.AppCourses.Include(l=>l.LearningStyle).Include(s=>s.School).ToList().LastOrDefault(l => l.Idcourse == fahterCourse.Idcourse);
            
                return fahterCourse;

        }










        //הפונקציה לפני תיאומים בחלקה

        //public Tuple<AppCourse, AppProfession, AppUserPerSchool, int, int> AddCoordinationsFatherCourse(AppCourse fahterCourse, string ProfessioName, int CoustomerId, AppSchool school, int UserCreatedId, int YearbookId, int coordinationId)
        //{
        //    // var Result = _professionRepository.CheckIfExsistAndAddProfession(school, ProfessioName, CoustomerId, UserCreatedId, YearbookId);
        //    var professionId = _professionRepository.GetCoordinatedProfessionPerSchool((int)fahterCourse.CoordinationTypeId, school.Idschool);
        //    fahterCourse.ProfessionId = professionId;
        //    AppCoordinationType coordinationType = new AppCoordinationType();
        //    coordinationType.CoordinationType = "AppCourses";
        //    coordinationType.DateCreated = DateTime.Today;
        //    coordinationType.UserCreatedId = UserCreatedId;
        //    coordinationType.IdCoordinationPerSchool = _coordinationRepository.getIdCoordinationPerSchoolByCoordinationIdAndSchoolId(
        //        coordinationId, school.Idschool);
        //    _coordinationRepository.AddCoordinationType(coordinationType);
        //    fahterCourse.CoordinationTypeId = coordinationType.IdCoordinationType;
        //    _context.AppCourses.Add(fahterCourse);
        //    _context.SaveChanges();
        //    fahterCourse = _context.AppCourses.Include(l => l.LearningStyle).Include(s => s.School).ToList().LastOrDefault(l => l.Idcourse == fahterCourse.Idcourse);
        //    if (Result.Item2 == true)
        //        return Tuple.Create(fahterCourse, Result.Item1, Result.Item4, Result.Item3, Result.Item5);
        //    else
        //        return Tuple.Create(fahterCourse, new AppProfession(), new AppUserPerSchool(), Result.Item3, Result.Item5);

        //}














        public Tuple<List<AppCourse>,List<AppProfession>,int,List<AppUserPerSchool>,int> EditCoordinatorCourseFather(AppCourse fatherCourse, int UserId,int CoustomerId)
        {

            var ListUniqueCodeFC = _context.AppCourses.Include(s=>s.School).Include(l=>l.LearningStyle).Include(p=>p.Profession).Where(w => w.UniqueCodeId == fatherCourse.UniqueCodeId).ToList();
            if (_context.AppCourses.ToList().FirstOrDefault(f => f.Name == fatherCourse.Name && ListUniqueCodeFC.FirstOrDefault(s=>s.SchoolId==f.SchoolId&& s.UniqueCodeId != f.UniqueCodeId) !=null) != null) return null;

            var profession = _context.AppProfessions.FirstOrDefault(f => f.Idprofession == fatherCourse.ProfessionId);
            List<AppProfession> ListNewProfession = new List<AppProfession>();
            List<AppUserPerSchool> ListNewUser = new List<AppUserPerSchool>();
            int CodeFatherCourse=0, CodeUserPerSchool=0;
            var LearningStyle = _context.TLearningStyles.FirstOrDefault(f => f.IdlearningStyle == fatherCourse.LearningStyleId);
            foreach (var FC in ListUniqueCodeFC)
            {
                var user = _context.AppUserPerSchools.FirstOrDefault(f => f.UserId == UserId && f.SchoolId == FC.SchoolId);
                var Result = _professionRepository.CheckIfExsistAndAddProfession(FC.School, profession.Name, CoustomerId,user!=null?user.IduserPerSchool:null, (int)FC.YearbookId);
                FC.Name = fatherCourse.Name;
                FC.HoursPerWeek = fatherCourse.HoursPerWeek;
                FC.Hours = fatherCourse.Hours;
                FC.Credits = fatherCourse.Credits;
                FC.Cost = fatherCourse.Cost;
                FC.MinimumScore = fatherCourse.MinimumScore;
                FC.Code = fatherCourse.Code;
                FC.LearningStyle = LearningStyle;
                FC.UserUpdatedId =user!=null?user.IduserPerSchool:null;
                FC.DateUpdate = DateTime.Today;
                FC.Profession=Result.Item1;
                

                if (Result.Item3 != 0) CodeFatherCourse = Result.Item3;
                if (Result.Item5 != 0) CodeUserPerSchool = Result.Item5;
                if (Result.Item2 == true)
                {
                    ListNewProfession.Add(Result.Item1);
                    if (Result.Item4.IduserPerSchool != 0 )
                        ListNewUser.Add(Result.Item4);
                }
            }
            _context.SaveChanges();
            return Tuple.Create(ListUniqueCodeFC, ListNewProfession, CodeFatherCourse, ListNewUser, CodeUserPerSchool);
        }
        public AppCourse getFatherCourseById(int fatherCourseId)
        {
            return _context.AppCourses.FirstOrDefault(c => c.Idcourse == fatherCourseId);
                 
        }

    }

}
