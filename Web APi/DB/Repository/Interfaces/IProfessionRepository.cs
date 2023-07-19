using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Repository.Classes;

namespace DB.Repository.Interfaces
{
    public interface IProfessionRepository
    {
        List<AppProfession> GetAllProfessionByIdSchool(string SchoolsId);
        AppProfession GetProfessionDetailsByProfessionId(int ProfessionId);
        AppProfession UpdateProfession(AppProfession Profession, int UserId, int SchoolId);
        AppProfession AddProfession(AppProfession P, int UserId, int SchoolId);
        int DeleteProfession(int ProfessionId);
        Tuple<AppProfession, bool,int, AppUserPerSchool,int> CheckIfExsistAndAddProfession(AppSchool school, string ProfessioName, int CoustomerId, int? UserCreatedId, int YearbookId);
        bool CheackIfExsistProfession(string ProfessionName, string CoordinationCode);
        List<AppProfession> AddCoordinationsProfession(List<AppProfession> ListProfession);
        Tuple<List<AppProfession>, List<AppUserPerSchool>, int> UpdateCoordinationProfession(List<SchoolWithYearBookAndUserPerSchool> schools,AppProfession Profession,int CustomerId,int YearbookId);
         List<AppProfession> GetAllProfessionsByCoordinationId(int coordinationId);
        int GetCoordinatedProfessionPerSchool(int coordinationTypeId, int schoolId);
    }
}
