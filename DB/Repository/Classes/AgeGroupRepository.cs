using DB.Model;
using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class AgeGroupRepository : IAgeGroupRepository
    {
        public readonly ExtraSchoolContext _context;

        public AgeGroupRepository(ExtraSchoolContext context)
        {
            _context = context;
        }
        //לא בשימוש כרגע- שליפת שמות שכבות גיל לפי קוד תיאום
        //public List<string> GetAllNameAgeGroupsByCoordinationCode(string coordinationCode)
        //{
        //  return  _context.TabAgeGroups.Where(ag => ag.CoordinationCode == coordinationCode).Select(t=>t.Name).Distinct().ToList();
        //}

        //שליפת שכבת גיל לפי קוד מוסד, קוד תיאום ושם
        //public TabAgeGroup GetAgeGroupByCoordinationCodeAndSchoolIdAndName(int schoolId, string coordinationCode, string name)
        //{
        //    return _context.TabAgeGroups.FirstOrDefault(ag => ag.Name == name && ag.SchoolId == schoolId && ag.CoordinationCode == coordinationCode);
        //}


        //שליפת שכבת גיל למוסדות
        public List<TabAgeGroup> GetAllAgeGroupsBySchools(string Schools)
        {
            Schools = Schools.Remove(Schools.Length - 1);
            var ArraySchool = Schools.Split(",").ToList();
            return _context.TabAgeGroups.Where(w => ArraySchool.Contains(w.SchoolId.ToString())).ToList();
        }

        public List<TabAgeGroup> GetLstAgeGroupBySchoolId(int schoolId)
        {
            try
            {
                return _context.TabAgeGroups.Where(w => w.SchoolId == schoolId).ToList();
            }
            catch (Exception)
            {
                return null;
            }     
        }
    }
}
