using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
     class HebrewDate
    {
        public static string GetHebrewJewishDateString(DateTime anyDate)
        {
            System.Text.StringBuilder hebrewFormatedString = new System.Text.StringBuilder();
            // Create the hebrew culture to use hebrew (Jewish) calendar
            CultureInfo jewishCulture = CultureInfo.CreateSpecificCulture("he-IL");
            jewishCulture.DateTimeFormat.Calendar = new HebrewCalendar();

            // Day of the week in the format " "
            hebrewFormatedString.Append(anyDate.ToString("dddd", jewishCulture) + " ");
            // Day of the month in the format "'"
            hebrewFormatedString.Append(anyDate.ToString("dd", jewishCulture) + " ");
            // Month and year in the format " "
            hebrewFormatedString.Append("" + anyDate.ToString("y", jewishCulture));

            return hebrewFormatedString.ToString();
        }

    }
}
