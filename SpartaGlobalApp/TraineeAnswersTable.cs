﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaGlobalAppModel
{
    public partial class TraineeAnswersTable
    {
        public int ResponseId { get; set; }
        public int? QuestionId { get; set; }
        public int? TraineeId { get; set; }
        public string TrainerId { get; set; }
        public string Response { get; set; }
        public string Feedback { get; set; }
        public bool? PassStatus { get; set; }

        public virtual QuestionsTable Question { get; set; }
        public virtual TraineeTable Trainee { get; set; }
        public virtual TrainerTable Trainer { get; set; }
    }
}
