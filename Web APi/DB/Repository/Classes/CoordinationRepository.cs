using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DB.Repository.Classes
{
    public class CoordinationRepository : ICoordinationRepository
    {
        private readonly ExtraSchoolContext _context;
        private readonly IConfiguration _configuration;

        public CoordinationRepository(ExtraSchoolContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //שמחברת בין הטבלאות/JOIN/לפי רשימת קודי מוסד עי פעולת /coordination/הפונקציה מחזירה אוביקט מסוג
        public List<AppCoordination> GetAllCoordinationsByListSchoolId(List<int> schoolId)
        {
            List<AppCoordination> appCoordinations = new List<AppCoordination>();
                 schoolId.ForEach(s => {
                     var c =
                     _context.AppCoordinationPerSchools
                    .Join(_context.AppCoordinations, c => c.CoordinationId, co => co.CoordinationId,
                    (c, co) => new { coordination = co, coordinationPerSchool = c })
                    .Where(c => c.coordinationPerSchool.SchoolId == s)
                    .Select(coordination => coordination.coordination).ToList();
                     appCoordinations.AddRange(c);
                    });
            return appCoordinations.Distinct().ToList(); 
        }


        // של טבלה מסוימת לפי הקוד תיאום/ID/פונקציה המחזירה את כל ה
        //כלומר - אם לדוגמא רוצים לשלוף את כל המקצועות שקשורים לקוד תיאום מסוים
        // יש לשלוח את הקוד תיאום ואת השם של טבלת מקצועות - (כמו בדאטה בייס) והוא
        //יחזיר רשימת קודים של מקצועות
        //הפונקציה עושה שימוש בשתי פרוצדורות
        // מהטבלה המבוקשת/PK/הראשונה שולפת את השם של ה
        //והשניה שולפת את העמודה מהפרוצדורה הקודמת 
        //לפי שם הטבלה וקוד תיאום
        public List<int> GetAllPrimaryKeyGenericTypeByCoordinationId(int coordinationId, string tableName)
        {
            List<int> ListPrimaryKey = new List<int>();
            string columnName="";
            int primaryKey=-1;

            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {

                cmd.CommandText = "[dbo].[GetPrimaryKey]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                cmd.Parameters.Add(new SqlParameter("@TableName", tableName));
                


                SqlDataReader rdr = (SqlDataReader)cmd.ExecuteReader();


                if (rdr.HasRows)
                {

                    while (rdr.Read())
                    {
                        if (rdr["COLUMN_NAME"] != DBNull.Value) columnName = rdr["COLUMN_NAME"].ToString();
                    }
                }

                //gvGrid.DataSource = lessons;
                //gvGrid.DataBind();
                cmd.Connection.Close();
            }

            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {

                cmd.CommandText = "[dbo].[sp_GetPrimaryKeyGenericTypeByCoordinationId]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                cmd.Parameters.Add(new SqlParameter("@TableName", tableName));
                cmd.Parameters.Add(new SqlParameter("@CoordinationId", coordinationId));
                cmd.Parameters.Add(new SqlParameter("@PrimaryKey", columnName));


                SqlDataReader rdr = (SqlDataReader)cmd.ExecuteReader();


                if (rdr.HasRows)
                {

                    while (rdr.Read())
                    {

                        if (rdr["Primary_key"] != DBNull.Value) primaryKey = int.Parse(rdr["Primary_key"].ToString());
                        ListPrimaryKey.Add(primaryKey);
                    }
                }

                //gvGrid.DataSource = lessons;
                //gvGrid.DataBind();
                cmd.Connection.Close();
            }
            
            return ListPrimaryKey;
        }

        public List<AppSchool> getAllSchoolsByCoordinationId(int coordinationId)
        {
            return _context.AppCoordinationPerSchools.Include(s=>s.School).ThenInclude(a=>a.AppYearbookPerSchools).Where(c => c.CoordinationId == coordinationId)
                .Select(s=>s.School)
                .ToList();
        }

        public int getIdCoordinationPerSchoolByCoordinationIdAndSchoolId(int coordinationId, int schoolId)
        {
            var a= _context.AppCoordinationPerSchools.FirstOrDefault(c => c.CoordinationId == coordinationId && c.SchoolId == schoolId);
            if (a != null)
                return a.IdcoordinationPerSchool;
            return -1;
        }


        public AppCoordination GetCoordinationByCoordinationTypeId(int coordinationId)
        {
            //MVC דרך א
            //string constr = _configuration.GetConnectionString("ExtraSchool");
            //AppCoordination coordination = new AppCoordination();
            //using (SqlConnection con = new SqlConnection(constr))
            //{
            //    string query = "select c.* from App_Coordination c join App_CoordinationPerSchool cps" +
            //        "on c.CoordinationId = cps.CoordinationId" +
            //           "join App_CoordinationType ct" +
            //           "on ct.IdCoordinationPerSchool = cps.IDCoordinationPerSchool" +
            //           "where ct.IdCoordinationType = @coordinationId";
            //    using (SqlCommand cmd = new SqlCommand(query))
            //    {
            //        cmd.Connection = con;
            //        con.Open();
            //        using (SqlDataReader sdr = cmd.ExecuteReader())
            //        {
            //            while (sdr.Read())
            //            {
            //                coordination.CoordinationId = Convert.ToInt32(sdr["CoordinationId"].ToString());
            //                coordination.CoordinationName = sdr["CoordinationName"].ToString();
            //                coordination.DateCreated = Convert.ToDateTime(sdr["DateCreated"].ToString());
            //                coordination.DateUpdated = Convert.ToDateTime(sdr["DateUpdated"].ToString());
            //                coordination.UserCreatedId = Convert.ToInt32(sdr["UserCreatedId"].ToString());
            //                coordination.UserUpdatedId = Convert.ToInt32(sdr["UserUpdatedId"].ToString());

            //            }
            //        }
            //        con.Close();
            //    }
            //}
            //return coordination;


            //דרך ב לינק

            //var a = _context.AppCoordinationTypes
            //      .Join(_context.AppCoordinationPerSchools, ct => ct.IdCoordinationPerSchool, cps => cps.IdcoordinationPerSchool,
            //      (ct, cps) => new { coordTypes = ct, coordPerSchool = cps })
            //      .Join(_context.AppCoordinations, newObject => newObject.coordPerSchool.CoordinationId, c => c.CoordinationId,
            //      (newObject, c) => new { coordTypesPerSchool = newObject, coordination = c }).FirstOrDefault(c => c.coordTypesPerSchool.coordTypes.IdCoordinationType == coordinationId)
            //     .coordination;

            //return a;


            //דרך ג פרוצדורה
            AppCoordination coordination = new AppCoordination(); ;
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {

                cmd.CommandText = "[dbo].[sp_GetCoordinationByCoordinationTypeId]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                cmd.Parameters.Add(new SqlParameter("@CoordinationTypeId", coordinationId));
                

                SqlDataReader rdr = (SqlDataReader)cmd.ExecuteReader();


                if (rdr.HasRows)
                {

                    while (rdr.Read())
                    {

                        if (rdr["CoordinationId"] != DBNull.Value) coordination.CoordinationId = int.Parse(rdr["CoordinationId"].ToString());
                        if (rdr["CoordinationName"] != DBNull.Value) coordination.CoordinationName = rdr["CoordinationName"].ToString();
                        if (rdr["UserCreatedId"] != DBNull.Value) coordination.UserCreatedId = int.Parse(rdr["UserCreatedId"].ToString());
                        if (rdr["UserUpdatedId"] != DBNull.Value) coordination.UserUpdatedId = int.Parse(rdr["UserUpdatedId"].ToString());
                        if (rdr["DateCreated"] != DBNull.Value) coordination.DateCreated = DateTime.Parse(rdr["DateCreated"].ToString());
                        if (rdr["DateUpdated"] != DBNull.Value) coordination.DateUpdated = DateTime.Parse(rdr["DateUpdated"].ToString());
                    }
                }

                //gvGrid.DataSource = lessons;
                //gvGrid.DataBind();
                cmd.Connection.Close();
            }
            if (coordination.CoordinationId!=0)
                return coordination;
            return null;
        }


        public AppCoordinationType AddCoordinationType(AppCoordinationType coordinationType)
        {
            _context.AppCoordinationTypes.Add(coordinationType);
            _context.SaveChanges();
            return coordinationType;
        }
    }
   
}
