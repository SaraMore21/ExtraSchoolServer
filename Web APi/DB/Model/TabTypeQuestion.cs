using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabTypeQuestion
    {
        public TabTypeQuestion()
        {
            AppQuestionsOfTasks = new HashSet<AppQuestionsOfTask>();
        }

        public int IdtypeQuestion { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppQuestionsOfTask> AppQuestionsOfTasks { get; set; }
    }
}
