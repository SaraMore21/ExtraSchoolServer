using DB.Model;
using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class ExsistDocumentRepository: IExsistDocumentRepository
    {
        private readonly ExtraSchoolContext _context;

        public ExsistDocumentRepository(ExtraSchoolContext context)
        {
            _context = context;

        }

        public int AddAndGetTheNextExsistDocument(int UserId)
        {
            AppExsistDocument appExsistDocument = new AppExsistDocument()
            {
                UserCreatedId = UserId,
                DateCreated = DateTime.Today
            };
            _context.AppExsistDocuments.Add(appExsistDocument);
            _context.SaveChanges();
            return appExsistDocument != null ? appExsistDocument.IdexsistDocument : 0;

        }

    }
}
