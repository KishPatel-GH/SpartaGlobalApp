using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SpartaGlobalAppModel;
using SpartaGlobalAppBusiness;
using NUnit.Framework;

namespace SpartaGlobalAppBusiness
{
    public class Tests
    {
        CRUDManager _crudManager = new CRUDManager();

        [SetUp]

        public void Setup()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var selectedTraineeAnswerTable =
                (from t in db.TraineeAnswersTables
                where t.TrainerId == "NMAND"
                select t).FirstOrDefault();
                if (selectedTraineeAnswerTable != null)
                {
                    db.TraineeAnswersTables.RemoveRange(selectedTraineeAnswerTable);
                }
                var selectedQuestion =
                (from q in db.QuestionsTables
                where q.TrainerId == "NMAND"
                select q).FirstOrDefault();
                if (selectedQuestion != null)
                {
                        db.QuestionsTables.RemoveRange(selectedQuestion);
                }
                var selectedTrainee =
                (from t in db.TraineeTables
                where t.TrainerId == "NMAND"
                select t).FirstOrDefault();
                if (selectedTrainee != null)
                {
                        db.TraineeTables.RemoveRange(selectedTrainee);
                }
                var selectedTrainer =
                (from t in db.TrainerTables
                where t.TrainerId == "NMAND"
                select t).FirstOrDefault();
                if (selectedTrainer != null)
                {
                        db.TrainerTables.RemoveRange(selectedTrainer);
                }
                db.SaveChanges();
            }
        }

        [TearDown]

        public void TearDown()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var selectedTraineeAnswerTable =
                (from t in db.TraineeAnswersTables
                 where t.TrainerId == "NMAND"
                 select t).FirstOrDefault();
                if (selectedTraineeAnswerTable != null)
                {
                    db.TraineeAnswersTables.RemoveRange(selectedTraineeAnswerTable);
                }
                var selectedQuestion =
                (from q in db.QuestionsTables
                 where q.TrainerId == "NMAND"
                 select q).FirstOrDefault();
                if (selectedQuestion != null)
                {
                    db.QuestionsTables.RemoveRange(selectedQuestion);
                }
                var selectedTrainee =
                (from t in db.TraineeTables
                 where t.TrainerId == "NMAND"
                 select t).FirstOrDefault();
                if (selectedTrainee != null)
                {
                    db.TraineeTables.RemoveRange(selectedTrainee);
                }
                var selectedTrainer =
                (from t in db.TrainerTables
                 where t.TrainerId == "NMAND"
                 select t).FirstOrDefault();
                if (selectedTrainer != null)
                {
                    db.TrainerTables.RemoveRange(selectedTrainer);
                }
                db.SaveChanges();
            }
        }

        [Test] // TRAINER CREATE TEST
        public void WhenANewTrainerIsAdded_TheNumberOfTrainersIncreasesBy1()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var numberOfTrainersBefore = db.TrainerTables.ToList().Count();
                _crudManager.CreateTrainer("Nishant Mandal", "NMAND", "Sparta123", "Eng71", "nishman89");
                var numberOfTrainersAfter = db.TrainerTables.ToList().Count();

                Assert.AreEqual(numberOfTrainersBefore + 1, numberOfTrainersAfter);
            }
        }
        [Test] // TRAINEE CREATE TEST
        public void WhenANewTraineeIsAdded_TheNumberOfTraineesIncreasesBy1()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var newTrainer = new TrainerTable()
                {
                    TrainerName = "Nishant Mandal",
                    TrainerId = "NMAND",
                    TrainerUsername = "nishman89",
                    TrainerPassword = "Sparta123"
                };
                db.TrainerTables.Add(newTrainer);
                db.SaveChanges();
                var numberOfTraineesBefore = db.TraineeTables.ToList().Count();
                _crudManager.CreateTrainee("Kishan Patel", "kish123", "Eng71", "NMAND", "kishpat21");
                var numberOfTraineesAfter = db.TrainerTables.ToList().Count();
                Assert.AreEqual(numberOfTraineesBefore + 1, numberOfTraineesAfter);
            }
        }
        [Test] // QUESTION CREATE TEST
        public void WhenANewQuestionIsAdded_TheNumberOfQuestionsIncreasesBy1()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var newTrainer = new TrainerTable()
                {
                    TrainerName = "Nishant Mandal",
                    TrainerId = "NMAND",
                    TrainerUsername = "nishman89",
                    TrainerPassword = "Sparta123"
                };
                db.TrainerTables.Add(newTrainer);
                db.SaveChanges();
                var numberOfQuestionsBefore = db.QuestionsTables.ToList().Count();
                _crudManager.CreateQuestion("Test question?", "TESTING", "NMAND");
                var numberOfQuestionsAfter = db.QuestionsTables.ToList().Count();

                Assert.AreEqual(numberOfQuestionsBefore + 1, numberOfQuestionsAfter);
            }
        }

        [Test] // POSE QUESTION TEST
        public void TestWhenQuestionIsPosed()
        {
            using (var db = new SpartaGlobalDBContext())
            {
                var newTrainer = new TrainerTable()
                {
                    TrainerName = "Nishant Mandal",
                    TrainerId = "NMAND",
                    TrainerUsername = "nishman89",
                    TrainerPassword = "Sparta123"
                };
                var newTrainee = new TraineeTable()
                {
                    TraineeName = "Kishan Patel",
                    TrainerId = "NMAND",
                    TraineeUsername = "kishpat123",
                    TraineePassword = "kish123"
                };
                var newQuestion = new QuestionsTable()
                {
                    Question = "Test question?",
                    CategoryName = "TESTING", 
                    TrainerId = "NMAND"
                };
                db.TrainerTables.Add(newTrainer);
                db.TraineeTables.Add(newTrainee);
                db.QuestionsTables.Add(newQuestion);
                db.SaveChanges();
                var ThisQuestion = db.QuestionsTables.Where(q => q.TrainerId == "NMAND").FirstOrDefault();
                var ThisTrainee = db.TraineeTables.Where(t => t.TraineeName == "Kishan Patel").FirstOrDefault();
                _crudManager.SetSelectedQuestion(ThisQuestion);
                _crudManager.SetSelectedTrainee(ThisTrainee);
                _crudManager.TrainerPoseQuestion();
                Assert.IsNotNull(db.TraineeAnswersTables);
            }
        }

        //[Test] // RESPOND TO QUESTION TEST
        //public void TestWhenQuestionResponded()
        //{
        //    using (var db = new SpartaGlobalDBContext())
        //    {
        //        _crudManager.CreateQuestion("Test question?", "Test answer.", "TESTS", "Testing");
        //        _crudManager.CreateTrainer("Nishant Mandal", "NMAND", "nishman123", "Eng71");
        //        _crudManager.CreateTrainee("Kishan Patel", "kishpat123", "Eng71", "NMAND");
        //        var ThisQuestionID = db.QuestionsTables.Where(q => q.CategoryId == "TESTS").FirstOrDefault();
        //        int a = ThisQuestionID.QuestionId;
        //        var ThisTraineeID = db.TraineeTables.Where(t => t.TraineeName == "Kishan Patel").FirstOrDefault();
        //        int b = ThisTraineeID.TraineeId;
        //        _crudManager.TrainerPoseQuestion(a, b);
        //        _crudManager.TraineeRespondsToQuestion(a, "Test Response");
        //        Assert.IsNotNull(db.TraineeAnswersTables.Where(c => c.Response == "Test Response"));
        //    }
        //}
    }
}