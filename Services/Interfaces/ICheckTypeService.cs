using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Classes;

namespace Services.Interfaces
{
    public interface ICheckTypeService
    {
        List<TCheckTypeDTO> GetAll();
    }
}
