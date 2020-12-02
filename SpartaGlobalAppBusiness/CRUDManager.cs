using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SpartaGlobalAppModel;
using Microsoft.EntityFrameworkCore;

namespace SpartaGlobalAppBusiness
{
    public class CRUDManager
    {
        public QuestionsTable SelectedQuestion { get; set; }
        public TraineeAnswersTable SelectedQuestionTAT { get; set; }
        public void SetSelectedQuestion(object selectedItem)
        {
            SelectedQuestion = (QuestionsTable)selectedItem;
        }
        public void SetSelectedQuestionInTAT(object selectedItem)
        {
            SelectedQuestionTAT = (TraineeAnswersTable)selectedItem;
        }
        static void Main(string[] args)
        {

        }
        // Create a trainer
        public void CreateTrainer(string trainerName, string trainerID, string password, string courseName)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var addTrainer = new TrainerTable()
                {
                    TrainerName = trainerName,
                    TrainerId = trainerID,
                    TrainerPassword = password,
                    Course = courseName
                };
                db.TrainerTables.Add(addTrainer);
                db.SaveChanges();
            }
        }
        // Create a trainee
        public void CreateTrainee(string traineeName, string password, string courseName, string trainerID)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var addTrainee = new TraineeTable()
                {
                    TraineeName = traineeName,
                    TraineePassword = password,
                    Course = courseName
                };
                var assignTrainer = db.TrainerTables.Where(t => t.TrainerId == trainerID).FirstOrDefault();
                assignTrainer.TraineeTables.Add(addTrainee);
                db.TraineeTables.Add(addTrainee);
                db.SaveChanges();
            }
        }
        // Delete a trainer
        public void DeleteTrainer(string trainerID)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var deleteTrainer =
                    from t in db.TrainerTables
                    where t.TrainerId == trainerID
                    select t;
                foreach (var t in deleteTrainer)
                {
                    db.TrainerTables.Remove(t);
                }
                db.SaveChanges();
            }
        }
        // Delete a trainee
        public void DeleteTrainee(int traineeID)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var deleteTrainee =
                    from t in db.TraineeTables
                    where t.TraineeId == traineeID
                    select t;
                foreach (var t in deleteTrainee)
                {
                    db.TraineeTables.Remove(t);
                }
                db.SaveChanges();
            }
        }
        // Create a new question
        public void CreateQuestion(string newQuestion, string modelAnswer, string categoryID, string categoryName)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var addQuestion = new QuestionsTable()
                {
                    Question = newQuestion,
                    ModelAnswer = modelAnswer,
                    CategoryId = categoryID
                };
                db.QuestionsTables.Add(addQuestion);
                db.SaveChanges();
            }
        }
        // Update an old question 
        public void UpdateQuestion(int qID, string updatedQuestion, string updatedAnswer, string updatedCategoryID)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                SelectedQuestion = db.QuestionsTables.Where(q => q.QuestionId == qID).FirstOrDefault();
                SelectedQuestion.Question = updatedQuestion;
                SelectedQuestion.ModelAnswer = updatedAnswer;
                SelectedQuestion.CategoryId = updatedCategoryID; // Not sure if CategoryName will change when the ID changes
                db.SaveChanges();
            }
        }
        // Delete an old question
        public void DeleteQuestion(int questionID)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var deleteQuestion =
                    from q in db.QuestionsTables
                    where q.QuestionId == questionID
                    select q;
                foreach (var q in deleteQuestion)
                {
                    db.QuestionsTables.Remove(q);
                }
                db.SaveChanges();
            }
        }
        // Delegate question to trainee
        public void TrainerPoseQuestion(int questionID, int traineeID)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                //var posedQuestion =
                //    from q in db.TraineeAnswersTables
                //    where q.QuestionId == questionID
                //    select q;
                //foreach (var q in posedQuestion)
                //{
                //    SelectedQuestionTAT.TraineeId = traineeID;
                //}
                //var addPosedQuestion = new TraineeAnswersTable()
                //{
                //    QuestionId = questionID,
                //    TraineeId = traineeID
                //};
                //db.TraineeAnswersTables.Add(addPosedQuestion);
                var posedQuestion =
                    from a in db.TraineeAnswersTables
                    where a.TraineeId == traineeID
                    select a;
                foreach (var a in posedQuestion)
                {
                    a.QuestionId = questionID;
                }
                db.SaveChanges();
            }
        }
        // Trainees answer delegated question
        public void TraineeRespondsToQuestion(int traineeID, string response)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var responseAnswer =
                    from a in db.TraineeAnswersTables
                    where a.TraineeId == traineeID
                    select a;
                foreach (var a in responseAnswer)
                {
                    a.Response = response;
                }
                db.SaveChanges();
            }
        }
    }
}
