using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IHebrewDateRepository
    {
        string GetHebrewJewishDateString(DateTime anyDate);
        string GetHebrewYear(DateTime anyDate);
    }
}
