using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaGlobalAppModel
{
    public partial class TrainerTable
    {
        public TrainerTable()
        {
            QuestionsTables = new HashSet<QuestionsTable>();
            TraineeAnswersTables = new HashSet<TraineeAnswersTable>();
            TraineeTables = new HashSet<TraineeTable>();
        }

        public string TrainerId { get; set; }
        public string TrainerName { get; set; }
        public string TrainerUsername { get; set; }
        public string Course { get; set; }
        public string TrainerPassword { get; set; }

        public virtual ICollection<QuestionsTable> QuestionsTables { get; set; }
    }
}
