using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface ITypePresenceRepository
    {
        List<TTypePresence> GetAllPresence();
    }
}
