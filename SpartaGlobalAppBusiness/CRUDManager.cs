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
        static void Main(string[] args)
        {
            
        }

        public QuestionsTable SelectedQuestion { get; set; }

        public void SetSelectedQuestion(object selectedItem)
        {
            SelectedQuestion = (QuestionsTable)selectedItem;
        }
        public TraineeTable SelectedTrainee { get; set; }

        public void SetSelectedTrainee(object selectedItem)
        {
            SelectedTrainee = (TraineeTable)selectedItem;
        }
        public TraineeAnswersTable SelectedTraineeQuestion { get; set; }

        public void SetSelectedTraineeQuestion(TraineeAnswersTable selectedItem)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                SelectedTraineeQuestion = (from q in db.TraineeAnswersTables
                                           join t in db.TraineeTables on q.TraineeId equals t.TraineeId
                                           join r in db.QuestionsTables on q.QuestionId equals r.QuestionId
                                           where q.ResponseId == selectedItem.ResponseId
                                           select q).First();
            }
        }

        // Read questions
        public List<QuestionsTable> RetrieveAllQuestions(string currentTrainer)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                return (from q in db.QuestionsTables
                        where q.TrainerId == currentTrainer
                        select q).ToList();
            }
        }
        // Read Trainees
        public List<TraineeTable> RetrieveAllTrainees(string currentTrainer)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                return (from q in db.TraineeTables
                        where q.TrainerId == currentTrainer
                        select q).ToList();
            }
        }
        // Read TraineeAnswer Table TRAINER INPUT
        public List<string> RetrieveAllTraineeQuestions(string currentTrainer)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var TraineeQs =  (from q in db.TraineeAnswersTables
                                 join t in db.TraineeTables on q.TraineeId equals t.TraineeId
                                 join r in db.QuestionsTables on q.QuestionId equals r.QuestionId
                                 where q.TrainerId == currentTrainer
                                 select new {q,t,r});
                List<string> newList = new List<string>();
                foreach (var item in TraineeQs)
                {
                    newList.Add($"{item.r.Question} - {item.t.TraineeName} - {item.q.ResponseId}");
                }
                return newList;
            }
        }
        // Read TraineeAnswer Table TRAINEE INPUT
        public List<string> RetrieveAllTraineeQuestions(int currentTrainee)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var TraineeQs = (from q in db.TraineeAnswersTables
                                 join t in db.TraineeTables on q.TraineeId equals t.TraineeId
                                 join r in db.QuestionsTables on q.QuestionId equals r.QuestionId
                                 where q.TraineeId == currentTrainee
                                 select new { q, t, r });
                List<string> newList = new List<string>();
                foreach (var item in TraineeQs)
                {
                    newList.Add($"{item.r.Question} - {item.r.TrainerId} - {item.q.ResponseId}");
                }
                return newList;
            }
        }

        // Create a trainer
        public void CreateTrainer(string trainerName, string trainerID, string password, string courseName, string trainerUsername)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var addTrainer = new TrainerTable()
                {
                    TrainerName = trainerName,
                    TrainerId = trainerID,
                    TrainerPassword = password,
                    TrainerUsername = trainerUsername,
                    Course = courseName
                };
                db.TrainerTables.Add(addTrainer);
                db.SaveChanges();
            }
        }
        // Create a trainee
        public void CreateTrainee(string traineeName, string password, string courseName, string trainerID, string traineeUsername)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var addTrainee = new TraineeTable()
                {
                    TraineeName = traineeName,
                    TraineePassword = password,
                    Course = courseName,
                    TraineeUsername = traineeUsername,
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
        public void CreateQuestion(string newQuestion, string categoryName, string trainerID)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var addQuestion = new QuestionsTable()
                {
                    Question = newQuestion,
                    CategoryName = categoryName,
                    TrainerId = trainerID
                };
                db.QuestionsTables.Add(addQuestion);
                db.SaveChanges();
            }
        }
        // Update an old question 
        public void UpdateQuestion(string updatedQuestion, string updatedCategoryName)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                SelectedQuestion = db.QuestionsTables.Where(c => c.QuestionId == SelectedQuestion.QuestionId).FirstOrDefault();
                SelectedQuestion.Question = updatedQuestion;
                SelectedQuestion.CategoryName = updatedCategoryName;
                db.SaveChanges();
            }
        }

        // Delete an old question
        public void DeleteQuestion()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var deleteQuestion =
                    (from q in db.QuestionsTables
                    where q.QuestionId == SelectedQuestion.QuestionId
                    select q);
                var deleteQuestion2 =
                    (from r in db.TraineeAnswersTables
                     where r.QuestionId == SelectedQuestion.QuestionId
                     select r).First();
                if (deleteQuestion2 == null)
                {
                    foreach (var q in deleteQuestion)
                    {
                        db.QuestionsTables.Remove(q);
                    }
                    db.SaveChanges();
                }
            }
        }
        // Delegate question to trainee
        public void TrainerPoseQuestion()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var poseQuestionTrainee = new TraineeAnswersTable()
                {
                    QuestionId = SelectedQuestion.QuestionId,
                    TraineeId = SelectedTrainee.TraineeId,
                    TrainerId = SelectedQuestion.TrainerId
                };
                db.TraineeAnswersTables.Add(poseQuestionTrainee);
                db.SaveChanges();
            }
        }
        // Trainees answer delegated question
        public void AddResponse(int responseID, string response)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var selectedPosedQuestion =
                    from a in db.TraineeAnswersTables
                    where a.ResponseId == responseID
                    select a;
                foreach (var a in selectedPosedQuestion)
                {
                    a.Response = response;
                }
                db.SaveChanges();
            }
        }
        // Trainer add feedback to delegated question
        public void AddFeedback(int responseID, string feedback)
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var selectedPosedQuestion =
                    from a in db.TraineeAnswersTables
                    where a.ResponseId == responseID
                    select a;
                foreach (var a in selectedPosedQuestion)
                {
                    a.Feedback = feedback;
                }
                db.SaveChanges();
            }
        }
    }
}
