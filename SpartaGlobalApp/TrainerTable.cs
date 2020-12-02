using System;
using System.Collections.Generic;

#nullable disable

namespace SpartaGlobalAppModel
{
    public partial class TrainerTable
    {
        public TrainerTable()
        {
            TraineeTables = new HashSet<TraineeTable>();
        }

        public string TrainerId { get; set; }
        public string TrainerName { get; set; }
        public string Course { get; set; }
        public string TrainerPassword { get; set; }

        public virtual ICollection<TraineeTable> TraineeTables { get; set; }
    }
}
