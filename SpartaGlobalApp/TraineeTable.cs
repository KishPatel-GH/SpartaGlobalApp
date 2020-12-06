using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaGlobalAppModel
{
    public partial class TraineeTable
    {
        public TraineeTable()
        {
            TraineeAnswersTables = new HashSet<TraineeAnswersTable>();
        }

        public int TraineeId { get; set; }
        public string TraineeName { get; set; }
        public string TraineeUsername { get; set; }
        public string Course { get; set; }
        public string TrainerId { get; set; }
        public string TraineePassword { get; set; }

        public virtual TrainerTable Trainer { get; set; }
    }
}
