using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface ITypeGroupRepository
    {
        List<TabTypeGroup> GetLstTypeGroupByIdSchool(int idSchool);

    }
}
