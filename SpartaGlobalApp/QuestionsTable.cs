using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaGlobalAppModel
{
    public partial class QuestionsTable
    {
        public QuestionsTable()
        {
            TraineeAnswersTables = new HashSet<TraineeAnswersTable>();
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string ModelAnswer { get; set; }
        public string CategoryId { get; set; }

        public virtual CategoriesTable Category { get; set; }
        public virtual ICollection<TraineeAnswersTable> TraineeAnswersTables { get; set; }
    }
}
