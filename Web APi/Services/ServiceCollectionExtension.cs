using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Classes;
using Services.Interfaces;

namespace DB
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterPayServicesService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IStudentService, StudentService>();
            serviceCollection.AddTransient<ISchoolService, SchoolService>();
            serviceCollection.AddTransient<IMailService, MailService>();
            serviceCollection.AddTransient<IExcelService, ExcelService>();
            serviceCollection.AddTransient<IGroupService, GroupService>();
            serviceCollection.AddTransient<ICourseService, CourseService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IGoogleDriveService, GoogleDriveService>();
            serviceCollection.AddTransient<IUploadService, UploadService>();
            serviceCollection.AddTransient<IDocumentPerStudentService, DocumentPerStudentService>();
            serviceCollection.AddTransient<IProfessionService, ProfessionService>();
            serviceCollection.AddTransient<ITaskService, TaskService>();
            serviceCollection.AddTransient<ITaskToStudentService, TaskToStudentService>();
            serviceCollection.AddTransient<ITaskExsistService, TaskExsistService>();
            serviceCollection.AddTransient<ITypeTaskService, TypeTaskService>();
            serviceCollection.AddTransient<ICheckTypeService, CheckTypeService>();
            serviceCollection.AddTransient<IDocumentPerGroupService, DocumentPerGroupService>();
            serviceCollection.AddTransient<IDocumentPerCourseService, DocumentPerCourseService>();
            serviceCollection.AddTransient<IDocumentPerSchoolService, DocumentPerSchoolService>();
            serviceCollection.AddTransient<IDocumentPerCourseService, DocumentPerCourseService>();
            serviceCollection.AddTransient<IDocumentPerStudentService, DocumentPerStudentService>();
            serviceCollection.AddTransient<IDocumentPerTaskService, DocumentPerTaskService>();
            serviceCollection.AddTransient<IAgeGroupService, AgeGroupService>();
            serviceCollection.AddTransient<IProfessionCategoryService, ProfessionCategoryService>();
            serviceCollection.AddTransient<IContactService, ContactService>();
            serviceCollection.AddTransient<ITypeContactService, TypeContactService>();
            serviceCollection.AddTransient<IStreetService, StreetService>();
            serviceCollection.AddTransient<IFatherCourseService, FatherCourseService>();
            serviceCollection.AddTransient<IDocumentPerFatherCourseService, DocumentPerFatherCourseService>();
            serviceCollection.AddTransient<IExsistDocumentService, ExsistDocumentService>();
            serviceCollection.AddTransient<IQuestionsOfTaskService, QuestionsOfTaskService>();
            serviceCollection.AddTransient<IDocumentPerTaskExsistService, DocumentPerTaskExsistService>();
            serviceCollection.AddTransient<IDocumentPerUserService, DocumentPerUserService>();
            serviceCollection.AddTransient<IDocumentPerProfessionService, DocumentPerProfessionService>();
            serviceCollection.AddTransient<IDailyScheduleService, DailyScheduleService>();
            serviceCollection.AddTransient<IScheduleRegularService, ScheduleRegularService>();
            serviceCollection.AddTransient<IAttendanceService, AttendanceService>();
            serviceCollection.AddTransient<IStatusTaskPerformanceService, StatusTaskPerformanceService>();
            serviceCollection.AddTransient<IPresenceService, PresenceService>();
            serviceCollection.AddTransient<ITypePresencesService, TypePresencesService>();
            serviceCollection.AddTransient<ICoordinationService, CoordinationService>();
            serviceCollection.AddTransient<IAttendanceMarkingService, AttendanceMarkingService>();
        }


    }

}
