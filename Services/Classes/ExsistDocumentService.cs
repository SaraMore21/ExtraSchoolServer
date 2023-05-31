using DB.Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class ExsistDocumentService : IExsistDocumentService
    {
        public readonly IExsistDocumentRepository _ExsistDocumentRepository;

        public ExsistDocumentService(IExsistDocumentRepository ExsistDocumentRepository)
        {
            _ExsistDocumentRepository = ExsistDocumentRepository;

        }
        public int AddAndGetTheNextExsistDocument(int UserId)
        {
            return _ExsistDocumentRepository.AddAndGetTheNextExsistDocument(UserId);
        }
    }
}
