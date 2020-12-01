using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaGlobalAppModel
{
    public partial class CategoriesTable
    {
        public CategoriesTable()
        {
            QuestionsTables = new HashSet<QuestionsTable>();
        }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<QuestionsTable> QuestionsTables { get; set; }
    }
}
