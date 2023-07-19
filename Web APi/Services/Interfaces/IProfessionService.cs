using DB.Model;
using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProfessionService
    {
        List<AppProfessionDTO> GetAllProfessionByIdSchool(string Schools);
        AppProfessionDTO GetProfessionDetailsByProfessionId(int ProfessionId);
        AppProfessionDTO UpdateProfession(AppProfessionDTO p, int userId, int SchoolId);
        AppProfessionDTO AddProfession(AppProfessionDTO newProfession, int userCreatedId, int schoolId);
        int DeleteProfession(int ProfessionId);
        Tuple<List<AppProfessionDTO>, List<SecUserDTO>, int> AddCoordinationsProfession(List<AppSchoolWhithYearbookDTO> ListSchool, AppProfessionDTO Profession, int CusomerId, int UserCreatedId, int YearbookId);
        Tuple<List<AppProfessionDTO>, List<SecUserDTO>, int> UpdateCoordinationProfession(List<AppSchoolWhithYearbookDTO> ListSchool, AppProfessionDTO Profession, int CustomerId, int UserCreatedId, int YearbookId);
         List<AppProfessionDTO> GetAllProfessionsByCoordinationId(int coordinationId);

    }
}
