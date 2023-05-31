using DB.Model;
using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class UniqeCodeRepository : IUniqeCodeRepository
    {
        private readonly ExtraSchoolContext _context;

        public UniqeCodeRepository(ExtraSchoolContext context)
        {
            _context = context;
        }
        //הוספת קוד ייחודי
        public int AddUniqeCode(int CoustomerId)
        {
            var UniqeCode = new AppUniqueCode()
            {
                CustomerId = CoustomerId,
                DateCreated = DateTime.Today
            };
            _context.AppUniqueCodes.Add(UniqeCode);
            _context.SaveChanges();
            return UniqeCode.IduniqueCode;
        }
    }
}
