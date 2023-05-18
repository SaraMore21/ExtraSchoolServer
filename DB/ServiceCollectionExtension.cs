using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Repository.Classes;
using DB.Repository.Interfaces;

namespace DB
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterPayServicesRepositor(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
            serviceCollection.AddScoped<ISchoolRepository, SchoolRepository>();
            serviceCollection.AddScoped<IContactRepository, ContactRepository>();
            serviceCollection.AddScoped<IMailRepository, MailRepository>();
            serviceCollection.AddScoped<ICheckTZRepository, CheckTZRepository>();
            serviceCollection.AddScoped<IGroupRepository, GroupRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IStudentPerGroupRepository, StudentPerGroupRepository>();
            serviceCollection.AddScoped<IGroupPerYearbookRepository, GroupPerYearbookRepository>();
            serviceCollection.AddScoped<IYearbookPerSchoolRepository, YearbookPerSchoolRepository>();
            serviceCollection.AddScoped<IAgeGroupRepository, AgeGroupRepository>();
            serviceCollection.AddScoped<ITypeGroupRepository, TypeGroupRepository>();
            serviceCollection.AddScoped<IHebrewDateRepository, HebrewDateRepository>();
            serviceCollection.AddScoped<IProfessionRepository, ProfessionRepository>();
            serviceCollection.AddScoped<ITaskRepository, TaskRepository>();
            serviceCollection.AddScoped<ITaskExsistRepository, TaskExsistRepository>();
            serviceCollection.AddScoped<ITaskToStudentRepository, TaskToStudentRepository>();
            serviceCollection.AddScoped<ITypeTaskRepository, TypeTaskRepository>();
            serviceCollection.AddScoped<ICheckTypeRepository, CheckTypeRepository>();
            serviceCollection.AddScoped<ICourseRepository, CourseRepository>();
            serviceCollection.AddScoped<IDocumentPerGroupRepository, DocumentPerGroupRepository>();
            serviceCollection.AddScoped<IDocumentPerCourseRepository, DocumentPerCourseRepository>();
            serviceCollection.AddScoped<IDocumentPerSchoolRepository, DocumentPerSchoolRepository>();
            serviceCollection.AddScoped<IDocumentPerStudentRepository, DocumentPerStudentRepository>();
            serviceCollection.AddScoped<IDocumentPerTaskRepository, DocumentPerTaskRepository>();
            serviceCollection.AddScoped<IProfessinCategoryRepository, ProfessionCategoryRepository>();
            serviceCollection.AddScoped<ITypeContactRepository, TypeContactRepository>();
            serviceCollection.AddScoped<IStreetRepository, StreetRepository>();
            serviceCollection.AddScoped<IFatherCourseRepository, FatherCourseRepository>();
            serviceCollection.AddScoped<IDocumentPerFatherCourseRepository, DocumentPerFatherCourseRepository>();
            serviceCollection.AddScoped<IUniqeCodeRepository, UniqeCodeRepository>();
            serviceCollection.AddScoped<IExsistDocumentRepository, ExsistDocumentRepository>();
            serviceCollection.AddScoped<IDocumentPerTaskExsistRepository, DocumentPerTaskExsistRepository>();
            serviceCollection.AddScoped<IDocumentPerUserRepository, DocumentPerUserRepository>();
            serviceCollection.AddScoped<IDocumentPerProfessionRepository, DocumentPerProfessionRepository>();
            serviceCollection.AddScoped<IQuestionsOfTaskRepository, QuestionsOfTaskRepository>();
            serviceCollection.AddScoped<IScoreStudentPerQuestionsOfTaskRepository, ScoreStudentPerQuestionsOfTaskRepository>();
            serviceCollection.AddScoped<IDailyScheduleRepository, DailyScheduleRepository>();
            serviceCollection.AddScoped<IScheduleRegularRepository, ScheduleRegularRepository>();
            serviceCollection.AddScoped<ILessonPerGroupRepository, LessonPerGroupRepository>();
            serviceCollection.AddScoped<IAttendanceRepository, AttendanceRepository>();
            serviceCollection.AddScoped<IStatusTaskPerformanceRepository, StatusTaskPerformanceRepository>();
            serviceCollection.AddScoped<IPresenceRepository, PresenceRepository>();
            serviceCollection.AddScoped<ITypePresenceRepository, TypePresenceRepository>();
        }

        public static void RegisterPayContext(this IServiceCollection serviceCollection, IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            var connectionString = "Server=ravcevel.database.windows.net;Database=ExtraSchool;persist security info=True;user id=voicesystem;password=Sari-30020010;multipleactiveresultsets=True;";

            serviceCollection.AddDbContext<Model.ExtraSchoolContext>(options =>
          {
              options.UseLoggerFactory(loggerFactory).UseSqlServer(connectionString);
          });
        }
    }

}
