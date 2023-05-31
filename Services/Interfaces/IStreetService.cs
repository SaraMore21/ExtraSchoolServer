using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStreetService
    {
        List<TAB_StreetDTO> GetStreetsByCityId(int CityId);
    }
}
