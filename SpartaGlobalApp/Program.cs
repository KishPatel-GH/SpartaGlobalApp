using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpartaGlobalAppModel
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public partial class QuestionsTable
    {
        public override string ToString()
        {
            return $"{CategoryName} - {Question}";
        }
    }
    public partial class TraineeTable
    {
        public override string ToString()
        {
            return $"{TraineeName} - {TraineeId}";
        }
    }
}
